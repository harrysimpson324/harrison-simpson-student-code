using EmployeeProjects.Models;
using System.Collections.Generic;

namespace EmployeeProjects.DAO
{
    public interface IEmployeeDao
    {
        /// <summary>
        /// Get an employee from the data store that has the given id.
        /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">The id of the employee to get from the data store.</param>
        /// <returns>An Employee object</returns>
        Employee GetEmployeeById(int id);

        /// <summary>
        /// Gets all employees from the data store.
        /// </summary>
        /// <returns>All the employees as Employee objects in a List.</returns>
        List<Employee> GetEmployees();

        /// <summary>
        /// Finds all employees whose names contain the search strings.
        /// Returned employees must match both first and last name search strings.
        /// If a search string is blank, ignore it. If both strings are blank, return all employees.
        /// </summary>
        /// <remarks>Be sure to use LIKE for proper search matching.</remarks>
        /// <param name="firstName">The string to search for in the first_name field, ignore if blank.</param>
        /// <param name="lastName">The string to search for in the last_name field, ignore if blank.</param>
        /// <returns>All employees whose name matches as Employee objects in a List.</returns>
        List<Employee> GetEmployeesByFirstNameLastName(string firstName, string lastName);

        /// <summary>
        /// Gets all of the employees that are on the project with the given id.
        /// </summary>
        /// <param name="projectId">The project id to get the employees from.</param>
        /// <returns>All the employees assigned to that project as Employee objects in a List.</returns>
        List<Employee> GetEmployeesByProjectId(int projectId);

        /// <summary>
        /// Gets all of the employees that aren't assigned to any project.
        /// </summary>
        /// <returns>All the employees not on a project as Employee objects in a List.</returns>
        List<Employee> GetEmployeesWithoutProjects();

        /// <summary>
        /// Inserts a new employee into the data store.
        /// </summary>
        /// <param name="employee">The employee object to insert.</param>
        /// <returns>The employee object with its new id filled in.</returns>
        Employee CreateEmployee(Employee employee);

        /// <summary>
        /// Updates an existing employee in the datastore.
        /// </summary>
        /// <param name="selectedEmployee">The employee object to update.</param>
        /// <returns>The employee object with its updated fields.</returns>
        Employee UpdateEmployee(Employee selectedEmployee);

        /// <summary>
        /// Removes an employee from the datastore, which requires deleting records from multiple tables.
        /// </summary>
        /// <param name=" id">The id of the employee to remove.</param>
        /// <returns>The number of employees deleted.</returns>
        int DeleteEmployeeById(int id);

        /// <summary>
        /// Removes employees from the datastore, which requires deleting records from multiple tables.
        /// </summary>
        /// <param name="departmentId">The id of the department to remove employees from.</param>
        /// <returns>The number of employees deleted.</returns>
        int DeleteEmployeesByDepartmentId(int departmentId);
    }
}
