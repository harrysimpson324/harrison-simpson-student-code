using EmployeeProjects.Models;
using System.Collections.Generic;

namespace EmployeeProjects.DAO
{
    public interface IDepartmentDao
    {
        /// <summary>
        /// Gets a department from the data store that has the given id.
	    /// If the id is not found, returns null.
        /// </summary>
        /// <param name="departmentId">The department id to get from the data store.</param>
        /// <returns>A filled out Department object.</returns>
        Department GetDepartmentById(int departmentId);

        /// <summary>
        /// Gets all departments from the data store.
        /// </summary>
        /// <returns>All departments as Department objects in a List.</returns>
        List<Department> GetDepartments();

        /// <summary>
        /// Inserts a new department into the data store.
        /// </summary>
        /// <param name="department">The department object to insert.</param>
        /// <returns>The department object with its new id filled in.</returns>
        Department CreateDepartment(Department department);

        /// <summary>
        /// Update a department to the data store. Only called on departments that are already in the data store.
        /// </summary>
        /// <param name="department">The department object to update.</param>
        /// <returns>The department object with its updated fields.</returns>
        Department UpdateDepartment(Department department);

        /// <summary>
        /// Removes a department from the data store.
        /// A department must not have any employees assigned to be deleted.
        /// 
        /// All employees assigned to the department to be deleted must first
        /// be assigned to a different department or "Unassigned" department.
        /// </summary>
        /// <param name="departmentId">The id of the department to remove.</param>
        /// <returns>The number of departments deleted.</returns>
        int DeleteDepartmentById(int departmentId);
    }
}
