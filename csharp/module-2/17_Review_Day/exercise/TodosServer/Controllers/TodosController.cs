using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodosServer.DAO;
using TodosServer.Exceptions;
using TodosServer.Models;

namespace TodosServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
            // TODO: Replace this line to store the current user's username.
            List<Todo> todos = todosDao.GetTodos("unknown");
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

            return Ok(todo);
            
        }

        // GET: /todos/search
        [HttpGet("search")]
        public ActionResult<IEnumerable<Todo>> GetByTask(string task)
        {
            List<Todo> todos = todosDao.GetTodosByTask(task);
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

            Todo createdTodo = todosDao.CreateTodo(todo);
            return Created($"/todos/{createdTodo.Id}", createdTodo);
        }

        // PUT: /todos/{id}
        [HttpPut("{id}")]
        public ActionResult<Todo> Update(int id, Todo todo)
        {
            // The id on the URL takes precedence over the one in the payload, if any
            todo.Id = id;

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

