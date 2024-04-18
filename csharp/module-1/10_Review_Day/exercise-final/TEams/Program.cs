using System;
using System.Collections.Generic;

namespace TEams
{
    class Program
    {
        private List<Department> departments = new List<Department>();
        private List<Employee> employees = new List<Employee>();
        private Dictionary<string, Project> projects = new Dictionary<string, Project>();

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            // create some departments
            CreateDepartments();

            // print each department by name
            PrintDepartments();

            // create employees
            CreateEmployees();

            // give Angie a 10% raise, she is doing a great job!
            Employee angie = employees[1];
            angie.RaiseSalary(10);

            // print all employees
            PrintEmployees();

            // create the TEams project
            CreateTeamsProject();

            // create the Marketing Landing Page Project
            CreateLandingPageProject();

            // print each project name and the total number of employees on the project
            PrintProjectsReport();
        }

        /**
         * Create departments and add them to the collection of departments
         */
        private void CreateDepartments()
        {
            Department marketing = new Department(1, "Marketing");
            Department sales = new Department(2, "Sales");
            Department engineering = new Department(3, "Engineering");

            departments.Add(marketing);
            departments.Add(sales);
            departments.Add(engineering);
        }

        /**
         * Print out each department in the collection.
         */
        private void PrintDepartments()
        {
            Console.WriteLine("------------- DEPARTMENTS ------------------------------");
            foreach (Department department in departments)
            {
                Console.WriteLine(department.Name);
            }
        }

        /**
         * Create employees and add them to the collection of employees
         */
        private void CreateEmployees()
        {
            Department engineering = departments[2];
            Department marketing = departments[0];

            //*** Part of bonus challenge solution:
            //Department engineering = GetDepartmentByName("Engineering");
            //Department marketing = GetDepartmentByName("Marketing");
            //***

            // Employee #1 - using no args constructor
            Employee dean = new Employee();
            dean.EmployeeId = 1;
            dean.FirstName = "Dean";
            dean.LastName = "Johnson";
            dean.Email = "djohnson@teams.com";
            dean.Salary = Employee.DEFAULT_STARTING_SALARY;
            dean.Department = engineering;
            dean.HireDate = "08/21/2020";

            // Employee #2 - using all args constructor
            Employee angie = new Employee(2, "Angie", "Smith", "asmith@teams.com", engineering, "08/21/2020");
            // Employee #3 - using all args constructor
            Employee margaret = new Employee(3, "Margaret", "Thompson", "mthompson@teams.com", marketing, "08/21/2020");

            employees.Add(dean);
            employees.Add(angie);
            employees.Add(margaret);
        }

        /**
         * Print out each employee in the collection.
         */
        private void PrintEmployees()
        {
            Console.WriteLine("\n------------- EMPLOYEES ------------------------------");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.FullName} ({employee.Salary.ToString("C2")}) {employee.Department.Name}");
            }
        }

        /**
         * Create the 'TEams' project.
         */
        private void CreateTeamsProject()
        {
            // Project #1 - TEams Project Management
            Project teams = new Project("TEams", "Project Management Software", "10/10/2020", "11/10/2020");

            // add all employees where department is engineering to the teams project
            List<Employee> engineeringTeam = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.Department.Name == "Engineering")
                {
                    engineeringTeam.Add(employee);
                }
            }
            teams.TeamMembers = engineeringTeam;

            // the key should be the name of the project
            projects[teams.Name] = teams;
        }

        /**
         * Create the 'Marketing Landing Page' project.
         */
        private void CreateLandingPageProject()
        {
            // Project #2 - Marketing Landing Page
            Project landingPage = new Project("Marketing Landing Page",
                    "Lead Capture Landing Page for Marketing",
                    "10/10/2020",
                    "10/17/2020");


            // add all employees where department is marketing to the landing page project
            List<Employee> marketingTeam = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (employee.Department.Name == "Marketing")
                {
                    marketingTeam.Add(employee);
                }
            }
            landingPage.TeamMembers = marketingTeam;

            projects[landingPage.Name] = landingPage;
        }

        /**
         * Print out each project in the collection.
         */
        private void PrintProjectsReport()
        {
            Console.WriteLine("\n------------- PROJECTS ------------------------------");
            foreach (KeyValuePair<string, Project> project in projects)
            {
                Console.WriteLine($"{project.Value.Name}: {project.Value.TeamMembers.Count}");
            }
        }

        /**
         * Bonus challenge: Find a department by name.
         */
        private Department GetDepartmentByName(string departmentName)
        {
            foreach (Department department in departments)
            {
                if (department.Name == departmentName)
                {
                    return department;
                }
            }
            return null;
        }
    }
}
