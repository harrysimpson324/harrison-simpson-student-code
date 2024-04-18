using System.Collections.Generic;
using TodosServer.Models;

namespace TodosServer.DAO;

public interface ITodosDao
{
    // Create
    Todo CreateTodo(Todo todo);

    // Read
    List<Todo> GetTodos(string user);
    Todo GetTodoById(int id);
    List<Todo> GetTodosByTask(string searchTerm, string user);

    // Update
    Todo UpdateTodo(Todo todo);

    // Delete
    int DeleteTodoById(int todoId);
}
