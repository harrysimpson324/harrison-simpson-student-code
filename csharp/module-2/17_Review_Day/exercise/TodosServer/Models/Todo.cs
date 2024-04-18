using System;
using System.Collections.Generic;

namespace TodosServer.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        public string CreatedBy { get; set; }
        public List<string> Collaborators { get; set; }

        public Todo(int id, string task, DateTime dueDate, bool completed, string createdBy, List<string> collaborators)
        {
            Id = id;
            Task = task;
            DueDate = dueDate;
            Completed = completed;
            CreatedBy = createdBy;
            Collaborators = collaborators != null ? collaborators : new List<string>();
        }

        public bool UserHasPermission(string user)
        {
            return CreatedBy.Equals(user) || Collaborators.Contains(user);
        }

        public override string ToString()
        {
            return $"Todo{{id={Id}, task='{Task}'}}";
        }
    }
}
