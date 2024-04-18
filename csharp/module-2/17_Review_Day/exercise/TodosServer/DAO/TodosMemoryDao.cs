using System;
using System.Collections.Generic;
using TodosServer.Models;
using TodosServer.Exceptions;

namespace TodosServer.DAO;

public class TodosMemoryDao : ITodosDao
{
    private static List<Todo> todos = new List<Todo>();

    public TodosMemoryDao()
    {
        if (todos.Count == 0)
        {
            DateTime now = DateTime.Now.Date;
            todos.Add(new Todo(NextId(), "Decide on vacation location", now.AddDays(364), true, "mark", new List<string> { "sofia", "liam" }));
            todos.Add(new Todo(NextId(), "Research hotels", now.AddDays(371), false, "sofia", new List<string> { "mark", "liam" }));
            todos.Add(new Todo(NextId(), "Make reservations", now.AddDays(378), false, "liam", null));

            // Credit to https://www.homelight.com/blog/buyer-steps-to-building-a-house/
            todos.Add(new Todo(NextId(), "Find and purchase the lot", now.AddDays(-175), true, "jessa", new List<string> { "antoni" }));
            todos.Add(new Todo(NextId(), "Research the type of house", now.AddDays(-126), true, "jessa", new List<string> { "antoni" }));
            todos.Add(new Todo(NextId(), "Research and hire the building team", now.AddDays(-84), true, "jessa", new List<string> { "antoni" }));
            todos.Add(new Todo(NextId(), "Get the required permits from the township", now.AddDays(-56), true, "antoni", new List<string> { "jessa" }));
        }
    }

    public Todo CreateTodo(Todo todo)
    {
        if (todo == null)
        {
            throw new DaoException("Todo is null");
        }

        todo.Id = NextId();
        todos.Add(todo);
        return todo;
    }

    public List<Todo> GetTodos(string user)
    {
        List<Todo> userTodos = new List<Todo>();

        foreach (Todo todo in todos)
        {
            userTodos.Add(todo);
        }

        return userTodos;
    }

    public Todo GetTodoById(int id)
    {
        foreach (Todo todo in todos)
        {
            if (todo.Id == id)
            {
                return todo;
            }
        }

        throw new DaoException("Todo not found");
    }

    public List<Todo> GetTodosByTask(string searchTerm)
    {
        List<Todo> matchingTodos = new List<Todo>();

        foreach (Todo todo in todos)
        {
            if (todo.Task.ToLower().Contains(searchTerm.ToLower()))
            {
                matchingTodos.Add(todo);
            }
        }

        return matchingTodos;
    }

    public Todo UpdateTodo(Todo todo)
    {
        Todo existingTodo = GetTodoById(todo.Id);
        if (existingTodo != null)
        {
            // Can't update Id or CreatedBy
            existingTodo.Task = todo.Task;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.Completed = todo.Completed;
            existingTodo.Collaborators = todo.Collaborators;
            return existingTodo;
        }
        throw new DaoException("Todo to update not found");
    }

    public int DeleteTodoById(int todoId)
    {
        Todo todo = GetTodoById(todoId);
        if (todo != null)
        {
            todos.Remove(todo);
            return 1; // Indicates success
        }
        return 0; // Indicates failure
    }

    private int NextId()
    {
        // Find the current max
        int maxId = 0; // IDs are always positive
        foreach (Todo todo in todos)
        {
            if (todo.Id > maxId)
            {
                maxId = todo.Id;
            }
        }
        return maxId + 1;
    }
}
