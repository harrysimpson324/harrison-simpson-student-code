using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodosServer.DAO;
using TodosServer.Exceptions;
using TodosServer.Models;
using Microsoft.AspNetCore.Authorization;

namespace TodosServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TodosController : ControllerBase
    {
        private readonly ITodosDao todosDao;

        public TodosController(ITodosDao todosDao)
        {
            this.todosDao = todosDao;
        }

        // GET: /todos
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> List()
        {
            List<Todo> todos = todosDao.GetTodos(User.Identity.Name);
            return Ok(todos);
        }

        // GET: /todos/{id}
        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            Todo todo = todosDao.GetTodoById(id);
            if (todo == null)
            {
                // 404 Not found
                return NotFound();
            }

            if (todo.UserHasPermission(User.Identity.Name))
            {
                return Ok(todo);
            } 
            else
            {
                // 403 Forbidden
                return Forbid();
            }
        }

        // GET: /todos/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Todo>> GetByTask(string task)
        {
            List<Todo> todos = todosDao.GetTodosByTask(task, User.Identity.Name);
            return Ok(todos);
        }

        // POST: /todos
        [HttpPost]
        public ActionResult<Todo> Add(Todo todo)
        {
            if (todo == null)
            {
                return NotFound();
            }
            todo.CreatedBy = User.Identity.Name;
            Todo createdTodo = todosDao.CreateTodo(todo);
            return Created($"/todos/{createdTodo.Id}", createdTodo);
        }

        // PUT: /todos/{id}
        [HttpPut("{id}")]
        public ActionResult<Todo> Update(int id, Todo todo)
        {
            // The id on the URL takes precedence over the one in the payload, if any
            todo.Id = id;

            Todo retrievedTodo = todosDao.GetTodoById(id);
            if (retrievedTodo == null)
            {
                return NotFound();
            }
            if (!retrievedTodo.UserHasPermission(User.Identity.Name))
            {
                return Forbid();
            }

            try
            {
                Todo updatedTodo = todosDao.UpdateTodo(todo);
                return updatedTodo;
            }
            catch (DaoException)
            {
                return NotFound();
            }
        }

        // DELETE: /todos/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            int deletedCount = todosDao.DeleteTodoById(id);

            if (deletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

