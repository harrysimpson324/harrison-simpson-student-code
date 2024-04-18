using EmployeeProjects.DAO;
using EmployeeProjects.Models;
using EmployeeProjects.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeProjects
{
    public class EmployeeProjectsCLI
    {

        private static readonly string MAIN_MENU_OPTION_EMPLOYEES = "View and Manage Employees";
        private static readonly string MAIN_MENU_OPTION_DEPARTMENTS = "View and Manage Departments";
        private static readonly string MAIN_MENU_OPTION_PROJECTS = "View and Manage Projects";
        private static readonly string MAIN_MENU_OPTION_EXIT = "Exit";
        private static readonly string[] MAIN_MENU_OPTIONS = new string[] { MAIN_MENU_OPTION_DEPARTMENTS,
                                                                            MAIN_MENU_OPTION_EMPLOYEES,
                                                                            MAIN_MENU_OPTION_PROJECTS,
                                                                            MAIN_MENU_OPTION_EXIT };

        private static readonly string MENU_OPTION_RETURN_TO_MAIN = "Return to main menu";

        private static readonly string DEPT_MENU_OPTION_ALL_DEPARTMENTS = "Show all departments";
        private static readonly string DEPT_MENU_OPTION_CREATE_DEPARTMENT = "Create new department";
        private static readonly string DEPT_MENU_OPTION_UPDATE_NAME = "Update department name";
        private static readonly string DEPT_MENU_OPTION_DELETE_DEPARTMENT = "Delete department";
        private static readonly string[] DEPARTMENT_MENU_OPTIONS = new string[] { DEPT_MENU_OPTION_ALL_DEPARTMENTS,
                                                                                  DEPT_MENU_OPTION_CREATE_DEPARTMENT,
                                                                                  DEPT_MENU_OPTION_UPDATE_NAME,
                                                                                  DEPT_MENU_OPTION_DELETE_DEPARTMENT,
                                                                                  MENU_OPTION_RETURN_TO_MAIN };

        private static readonly string EMPL_MENU_OPTION_ALL_EMPLOYEES = "Show all employees";
        private static readonly string EMPL_MENU_OPTION_SEARCH_BY_NAME = "Employee search by name";
        private static readonly string EMPL_MENU_OPTION_EMPLOYEES_NO_PROJECTS = "Show employees without projects";
        private static readonly string EMPL_MENU_OPTION_CREATE_EMPLOYEE = "Create new employee";
        private static readonly string EMPL_MENU_OPTION_UPDATE_EMPLOYEE = "Update employee";
        private static readonly string EMPL_MENU_OPTION_DELETE_EMPLOYEE = "Delete employee";
        private static readonly string EMPL_MENU_OPTION_DELETE_EMPLOYEES_FROM_DEPARTMENT = "Delete all employees from a department";


        private static readonly string[] EMPL_MENU_OPTIONS = new string[] { EMPL_MENU_OPTION_ALL_EMPLOYEES,
                                                                            EMPL_MENU_OPTION_SEARCH_BY_NAME,
                                                                            EMPL_MENU_OPTION_EMPLOYEES_NO_PROJECTS,
                                                                            EMPL_MENU_OPTION_CREATE_EMPLOYEE,
                                                                            EMPL_MENU_OPTION_UPDATE_EMPLOYEE,
                                                                            EMPL_MENU_OPTION_DELETE_EMPLOYEE,
                                                                            EMPL_MENU_OPTION_DELETE_EMPLOYEES_FROM_DEPARTMENT,
                                                                            MENU_OPTION_RETURN_TO_MAIN };

        private static readonly string PROJ_MENU_OPTION_ALL_PROJECTS = "Show all projects";
        private static readonly string PROJ_MENU_OPTION_PROJECT_EMPLOYEES = "Show project employees";
        private static readonly string PROJ_MENU_OPTION_ASSIGN_EMPLOYEE_TO_PROJECT = "Assign an employee to a project";
        private static readonly string PROJ_MENU_OPTION_REMOVE_EMPLOYEE_FROM_PROJECT = "Remove employee from project";
        private static readonly string PROJ_MENU_OPTION_CREATE_PROJECT = "Create new project";
        private static readonly string PROJ_MENU_OPTION_UPDATE_PROJECT = "Update project information";
        private static readonly string PROJ_MENU_OPTION_DELETE_PROJECT = "Delete project";
        private static readonly string[] PROJ_MENU_OPTIONS = new string[] { PROJ_MENU_OPTION_ALL_PROJECTS,
                                                                            PROJ_MENU_OPTION_PROJECT_EMPLOYEES,
                                                                            PROJ_MENU_OPTION_ASSIGN_EMPLOYEE_TO_PROJECT,
                                                                            PROJ_MENU_OPTION_REMOVE_EMPLOYEE_FROM_PROJECT,
                                                                            PROJ_MENU_OPTION_CREATE_PROJECT,
                                                                            PROJ_MENU_OPTION_UPDATE_PROJECT,
                                                                            PROJ_MENU_OPTION_DELETE_PROJECT,
                                                                            MENU_OPTION_RETURN_TO_MAIN };

        private readonly IEmployeeDao employeeDao;
        private readonly IProjectDao projectDao;
        private readonly IDepartmentDao departmentDao;

        public EmployeeProjectsCLI(IEmployeeDao employeeDao, IProjectDao projectDao, IDepartmentDao departmentDao)
        {
            this.employeeDao = employeeDao;
            this.projectDao = projectDao;
            this.departmentDao = departmentDao;
        }

        public void Run()
        {
            DisplayBanner();

            bool running = true;
            while (running)
            {
                PrintHeading("Main Menu");
                string choice = (string)CLIHelper.GetChoiceFromOptions(MAIN_MENU_OPTIONS);
                if (choice == MAIN_MENU_OPTION_DEPARTMENTS)
                {
                    HandleDepartments();
                }
                else if (choice == MAIN_MENU_OPTION_EMPLOYEES)
                {
                    HandleEmployees();
                }
                else if (choice == MAIN_MENU_OPTION_PROJECTS)
                {
                    HandleProjects();
                }
                else if (choice == MAIN_MENU_OPTION_EXIT)
                {
                    running = false;
                }
            }
        }

        private void HandleDepartments()
        {
            PrintHeading("Departments");
            string choice = (string)CLIHelper.GetChoiceFromOptions(DEPARTMENT_MENU_OPTIONS);

            try
            {
                if (choice == DEPT_MENU_OPTION_ALL_DEPARTMENTS)
                {
                    HandleListAllDepartments();
                }
                else if (choice == DEPT_MENU_OPTION_CREATE_DEPARTMENT)
                {
                    HandleCreateDepartment();
                }
                else if (choice == DEPT_MENU_OPTION_UPDATE_NAME)
                {
                    HandleUpdateDepartmentName();
                }
                else if (choice == DEPT_MENU_OPTION_DELETE_DEPARTMENT)
                {
                    HandleDeleteDepartment();
                }
            }
            catch (DaoException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }

        private void HandleListAllDepartments()
        {
            PrintHeading("All Departments");
            List<Department> allDepartments = departmentDao.GetDepartments();
            ListDepartments(allDepartments);
        }

        private void ListDepartments(List<Department> departments)
        {
            Console.WriteLine();
            if (departments.Count > 0)
            {
                foreach (Department dept in departments)
                {
                    Console.WriteLine(dept);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleCreateDepartment()
        {
            PrintHeading("Create New Department");
            string newDepartmentName = GetUserInput("Enter new Department name");

            Department newDepartment = new Department();
            newDepartment.Name = newDepartmentName;
            newDepartment = departmentDao.CreateDepartment(newDepartment);

            Console.WriteLine("\n*** " + newDepartment.Name + " created ***");
        }

        private void HandleUpdateDepartmentName()
        {
            PrintHeading("Update Department Name");
            List<Department> allDepartments = departmentDao.GetDepartments();

            if (allDepartments.Count > 0)
            {
                Console.WriteLine("\n*** Choose a Department ***");
                Department selectedDepartment = (Department)CLIHelper.GetChoiceFromOptions(allDepartments.ToArray());

                string newDepartmentName = GetUserInput("Enter new Department name");
                selectedDepartment.Name = newDepartmentName;

                departmentDao.UpdateDepartment(selectedDepartment);
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleDeleteDepartment()
        {
            PrintHeading("Delete Department");
            Department selectedDepartment = GetDepartmentSelectionFromUser();

            departmentDao.DeleteDepartmentById(selectedDepartment.DepartmentId);
            Console.WriteLine("\n*** " + selectedDepartment.Name + " deleted ***");
        }

        private Department GetDepartmentSelectionFromUser()
        {
            Console.WriteLine("Choose a department:");
            List<Department> allDepartments = departmentDao.GetDepartments().ToList();
            return (Department)CLIHelper.GetChoiceFromOptions(allDepartments.ToArray());
        }

        private void HandleEmployees()
        {
            PrintHeading("Employees");
            string choice = (string)CLIHelper.GetChoiceFromOptions(EMPL_MENU_OPTIONS);

            try
            {
                if (choice == EMPL_MENU_OPTION_ALL_EMPLOYEES)
                {
                    HandleListAllEmployees();
                }
                else if (choice == EMPL_MENU_OPTION_SEARCH_BY_NAME)
                {
                    HandleEmployeeSearch();
                }
                else if (choice == EMPL_MENU_OPTION_EMPLOYEES_NO_PROJECTS)
                {
                    HandleUnassignedEmployeeSearch();
                }
                else if (choice == EMPL_MENU_OPTION_CREATE_EMPLOYEE)
                {
                    HandleCreateEmployee();
                }
                else if (choice == EMPL_MENU_OPTION_UPDATE_EMPLOYEE)
                {
                    HandleUpdateEmployee();
                }
                else if (choice == EMPL_MENU_OPTION_DELETE_EMPLOYEE)
                {
                    HandleDeleteEmployee();
                }
                else if (choice == EMPL_MENU_OPTION_DELETE_EMPLOYEES_FROM_DEPARTMENT)
                {
                    HandleDeleteEmployeesFromDepartment();
                }
            }
            catch (DaoException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }

        private void HandleListAllEmployees()
        {
            PrintHeading("All Employees");
            List<Employee> allEmployees = employeeDao.GetEmployees();
            ListEmployees(allEmployees);
        }

        private void HandleEmployeeSearch()
        {
            PrintHeading("Employee Search");
            string firstNameSearch = GetUserInput("Enter first name to search for");
            string lastNameSearch = GetUserInput("Enter last name to search for");
            List<Employee> employees = employeeDao.GetEmployeesByFirstNameLastName(firstNameSearch, lastNameSearch);
            ListEmployees(employees);
        }

        private void HandleUnassignedEmployeeSearch()
        {
            PrintHeading("Employees Without Projects");
            List<Employee> employees = employeeDao.GetEmployeesWithoutProjects();
            ListEmployees(employees);
        }

        private void HandleCreateEmployee()
        {
            PrintHeading("Create New Employee");
            Employee newEmployee = new Employee();
            List<Department> allDepartments = departmentDao.GetDepartments();

            if (allDepartments.Count > 0)
            {
                Console.WriteLine("\n*** Choose a department ***");
                Department selectedDepartment = GetDepartmentSelectionFromUser();

                newEmployee.DepartmentId = selectedDepartment.DepartmentId;
            }

            string newFirstName = GetUserInput("Enter employee's first name");
            string newLastName = GetUserInput("Enter employee's last name");
            string birthDate = GetUserInput("Enter birth date (YYYY-MM-DD)");
            string hireDate = GetUserInput("Enter hire date (YYYY-MM-DD)");

            newEmployee.FirstName = newFirstName;
            newEmployee.LastName = newLastName;
            newEmployee.BirthDate = DateTime.Parse(birthDate);
            newEmployee.HireDate = DateTime.Parse(hireDate);

            newEmployee = employeeDao.CreateEmployee(newEmployee);
            Console.WriteLine("\n*** " + newEmployee.FirstName + " " + newEmployee.LastName + " created ***");
        }

        private void HandleUpdateEmployee()
        {
            PrintHeading("Update Employee");

            Employee selectedEmployee = GetEmployeeSelectionFromUser();

            Department selectedDepartment = GetDepartmentSelectionFromUser();
            selectedEmployee.DepartmentId = selectedDepartment.DepartmentId;

            string newFirstName = GetUserInput("Enter employee's updated first name (leave blank to skip)");
            string newLastName = GetUserInput("Enter employee's updated first name (leave blank to skip)");
            string birthDate = GetUserInput("Enter updated birth date (YYYY-MM-DD) (leave blank to skip)");
            string hireDate = GetUserInput("Enter updated hire date (YYYY-MM-DD) (leave blank to skip)");

            if (!newFirstName.Equals(""))
            {
                selectedEmployee.FirstName = newFirstName;
            }
            if (!newLastName.Equals(""))
            {
                selectedEmployee.LastName = newLastName;
            }
            if (!birthDate.Equals(""))
            {
                selectedEmployee.BirthDate = DateTime.Parse(birthDate);
            }
            if (!hireDate.Equals(""))
            {
                selectedEmployee.HireDate = DateTime.Parse(hireDate);
            }

            selectedEmployee = employeeDao.UpdateEmployee(selectedEmployee);
            Console.WriteLine("\n*** " + selectedEmployee.FirstName + " " + selectedEmployee.LastName + " updated ***");
        }

        private void HandleDeleteEmployee()
        {
            PrintHeading("Delete Employee");
            Employee selectedEmployee = GetEmployeeSelectionFromUser();

            employeeDao.DeleteEmployeeById(selectedEmployee.EmployeeId);
            Console.WriteLine("\n*** " + selectedEmployee.FirstName + " " + selectedEmployee.LastName + " deleted ***");
        }

        private void HandleDeleteEmployeesFromDepartment()
        {
            Department selectedDepartment = GetDepartmentSelectionFromUser();

            int deletedCount = employeeDao.DeleteEmployeesByDepartmentId(selectedDepartment.DepartmentId);
            Console.WriteLine("\n*** " + deletedCount + " employees deleted ***");
        }

        private Employee GetEmployeeSelectionFromUser()
        {
            Console.WriteLine("Choose an employee:");
            List<Employee> allEmployees = employeeDao.GetEmployees();

            return (Employee)CLIHelper.GetChoiceFromOptions(allEmployees.ToArray());
        }

        private void ListEmployees(List<Employee> employees)
        {
            Console.WriteLine();
            if (employees.Count > 0)
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleProjects()
        {
            PrintHeading("Projects");
            string choice = (string)CLIHelper.GetChoiceFromOptions(PROJ_MENU_OPTIONS);

            try
            {
                if (choice == PROJ_MENU_OPTION_ALL_PROJECTS)
                {
                    HandleListActiveProjects();
                }
                else if (choice == PROJ_MENU_OPTION_PROJECT_EMPLOYEES)
                {
                    HandleProjectEmployeeList();
                }
                else if (choice == PROJ_MENU_OPTION_ASSIGN_EMPLOYEE_TO_PROJECT)
                {
                    HandleEmployeeProjectAssignment();
                }
                else if (choice == PROJ_MENU_OPTION_REMOVE_EMPLOYEE_FROM_PROJECT)
                {
                    HandleEmployeeProjectRemoval();
                }
                else if (choice == PROJ_MENU_OPTION_CREATE_PROJECT)
                {
                    HandleCreateProject();
                }
                else if (choice == PROJ_MENU_OPTION_UPDATE_PROJECT)
                {
                    HandleUpdateProject();
                }
                else if (choice == PROJ_MENU_OPTION_DELETE_PROJECT)
                {
                    HandleDeleteProject();
                }
            }
            catch (DaoException ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
        }

        private void HandleListActiveProjects()
        {
            PrintHeading("All Projects");
            List<Project> projects = projectDao.GetProjects();
            ListProjects(projects);
        }

        private void HandleCreateProject()
        {
            PrintHeading("Create New Project");
            string projectName = GetUserInput("Enter new Project name");
            string startDate = GetUserInput("Enter start date (YYYY-MM-DD) (leave blank if unknown)");
            string endDate = GetUserInput("Enter end date (YYYY-MM-DD) (leave blank if unknown)");
            Project newProject = new Project();
            newProject.Name = projectName;
            newProject.FromDate = null;
            if (startDate != "")
            {
                newProject.FromDate = DateTime.Parse(startDate);
            }
            newProject.ToDate = null;
            if (endDate != "")
            {
                newProject.ToDate = DateTime.Parse(endDate);
            }
            newProject = projectDao.CreateProject(newProject);
            Console.WriteLine("\n*** " + newProject.Name + " created ***");
        }

        private void HandleUpdateProject()
        {
            PrintHeading("Update Project");
            Project selectedProject = GetProjectSelectionFromUser();
            
            string newProjectName = GetUserInput("Enter updated project name (leave blank to skip)");
            string startDate = GetUserInput("Enter updated start date (YYYY-MM-DD) (leave blank to skip)");
            string endDate = GetUserInput("Enter updated end date (YYYY-MM-DD) (leave blank to skip)");
            
            if (!newProjectName.Equals(""))
            {
                selectedProject.Name = newProjectName;
            }
            if (!startDate.Equals(""))
            {
                selectedProject.FromDate = DateTime.Parse(startDate);
            }
            if (!endDate.Equals(""))
            {
                selectedProject.ToDate = DateTime.Parse(endDate);
            }

            selectedProject = projectDao.UpdateProject(selectedProject);
            Console.WriteLine("\n*** " + selectedProject.Name + " updated ***");
        }

        private void HandleEmployeeProjectRemoval()
        {
            PrintHeading("Remove Employee From Project");

            Project selectedProject = GetProjectSelectionFromUser();

            Console.WriteLine("Choose an employee to remove:");
            List<Employee> projectEmployees = employeeDao.GetEmployeesByProjectId(selectedProject.ProjectId);
            if (projectEmployees.Count > 0)
            {
                Employee selectedEmployee = (Employee)CLIHelper.GetChoiceFromOptions(projectEmployees.ToArray());
                projectDao.UnlinkProjectEmployee(selectedProject.ProjectId, selectedEmployee.EmployeeId);
                Console.WriteLine("\n*** " + selectedEmployee + " removed from " + selectedProject + " ***");
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void HandleEmployeeProjectAssignment()
        {
            PrintHeading("Assign Employee To Project");

            Project selectedProject = GetProjectSelectionFromUser();

            Console.WriteLine("Choose an employee to add:");
            List<Employee> allEmployees = employeeDao.GetEmployees();
            Employee selectedEmployee = (Employee)CLIHelper.GetChoiceFromOptions(allEmployees.ToArray());

            projectDao.LinkProjectEmployee(selectedProject.ProjectId, selectedEmployee.EmployeeId);
            Console.WriteLine("\n*** " + selectedEmployee + " added to " + selectedProject + " ***");
        }

        private void HandleDeleteProject()
        {
            PrintHeading("Delete Project");
            Project selectedProject = GetProjectSelectionFromUser();

            projectDao.DeleteProjectById(selectedProject.ProjectId);
            Console.WriteLine("\n*** " + selectedProject.Name + " deleted ***");
        }

        private void HandleProjectEmployeeList()
        {
            Project selectedProject = GetProjectSelectionFromUser();
            List<Employee> projectEmployees = employeeDao.GetEmployeesByProjectId(selectedProject.ProjectId);
            ListEmployees(projectEmployees);
        }

        private Project GetProjectSelectionFromUser()
        {
            Console.WriteLine("Choose a project:");
            List<Project> allProjects = projectDao.GetProjects();
            return (Project)CLIHelper.GetChoiceFromOptions(allProjects.ToArray());
        }

        private void ListProjects(List<Project> projects)
        {
            Console.WriteLine();
            if (projects.Count > 0)
            {
                foreach (Project proj in projects)
                {
                    Console.WriteLine(proj);
                }
            }
            else
            {
                Console.WriteLine("\n*** No results ***");
            }
        }

        private void PrintHeading(string headingText)
        {
            Console.WriteLine("\n" + headingText);
            for (int i = 0; i < headingText.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private string GetUserInput(string prompt)
        {
            Console.Write(prompt + " >>> ");
            return Console.ReadLine();
        }

        private void DisplayBanner()
        {
            Console.WriteLine(@" ______                 _                           _____           _           _       _____  ____  ");
            Console.WriteLine(@"|  ____|               | |                         |  __ \         (_)         | |     |  __ \|  _ \ ");
            Console.WriteLine(@"| |__   _ __ ___  _ __ | | ___  _   _  ___  ___    | |__) | __ ___  _  ___  ___| |_    | |  | | |_) |");
            Console.WriteLine(@"|  __| | '_ ` _ \| '_ \| |/ _ \| | | |/ _ \/ _ \   |  ___/ '__/ _ \| |/ _ \/ __| __|   | |  | |  _ < ");
            Console.WriteLine(@"| |____| | | | | | |_) | | (_) | |_| |  __/  __/   | |   | | | (_) | |  __/ (__| |_    | |__| | |_) |");
            Console.WriteLine(@"|______|_| |_| |_| .__/|_|\___/ \__, |\___|\___|   |_|   |_|  \___/| |\___|\___|\__|   |_____/|____/ ");
            Console.WriteLine(@"                 | |             __/ |                            _/ |                               ");
            Console.WriteLine(@"                 |_|            |___/                            |__/                                ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
