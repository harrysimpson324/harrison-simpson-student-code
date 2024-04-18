using System.Collections.Generic;

namespace TEams
{
    class Project
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string DueDate { get; set; }
        public List<Employee> TeamMembers = new List<Employee>();

        public Project(string name, string description, string startDate, string dueDate)
        {
            this.Name = name;
            this.Description = description;
            this.StartDate = startDate;
            this.DueDate = dueDate;
        }
    }
}
