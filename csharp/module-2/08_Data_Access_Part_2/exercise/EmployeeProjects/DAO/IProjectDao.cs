using EmployeeProjects.Models;
using System.Collections.Generic;

namespace EmployeeProjects.DAO
{
    public interface IProjectDao
    {
        /// <summary>
        /// Gets a project from the data store that has the given id.
	    /// If the id is not found, return null.
        /// </summary>
        /// <param name="id">The id of the project to get from the data store.</param>
        /// <returns>A filled out Project object.</returns>
        Project GetProjectById(int id);

        /// <summary>
        /// Gets all projects from the data store.
        /// </summary>
        /// <returns>All projects as Project objects in a List.</returns>
        List<Project> GetProjects();

        /// <summary>
        /// Inserts a new project into the data store.
        /// </summary>
        /// <param name="project">The project object to insert.</param>
        /// <returns>The Project object with its new id filled in.</returns>
        Project CreateProject(Project project);

        /// <summary>
        /// Link a project to an employee.
        /// </summary>
        /// <param name="projectId">The project to put the employee on.</param>
        /// <param name="employeeId">The employee to assign.</param>        
        void LinkProjectEmployee(int projectId, int employeeId);

        /// <summary>
        /// Unassign the project from an employee.
        /// </summary>
        /// <param name="projectId">The project to remove the employee from.</param>
        /// <param name="employeeId">The employee to remove.</param>
        void UnlinkProjectEmployee(int projectId, int employeeId);

        /// <summary>
        /// Updates an existing project in the data store.
        /// </summary>
        /// <param name="project">The project object to update.</param>
        /// <returns>The project object with its updated fields.</returns>
        Project UpdateProject(Project project);

        /// <summary>
        /// Removes a project from the data store, which requires deleting records from multiple tables.
        /// </summary>
        /// <param name="id">The id of the project to remove.</param>
        /// <returns>The number of projects deleted.</returns>
        int DeleteProjectById(int id);
    }
}
