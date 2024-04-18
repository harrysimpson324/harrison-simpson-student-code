# Data access part 2 exercise

For this exercise, you'll be responsible for implementing the data access objects for a CLI application that manages information for employees, departments, and projects. The purpose of this exercise is to practice writing application code that interacts with a database.

## Learning objectives

After completing this exercise, you'll understand:

* How to add custom exception handling to data access methods.
* How to execute SQL statements that insert new data.
* How to execute SQL statements that update existing data. 
* How to execute SQL statements that delete data.

## Evaluation criteria and functional requirements

* The project must not have any build errors.
* The unit tests pass as expected.
* Code is clean, concise, and readable.

You may use the provided CLI application to test your code. However, your goal is to make sure the tests pass.

## Getting started

1. If you haven't done so already, create the `EmployeeProjects` database. The script to do this is `database/EmployeeProjects.sql` included with this exercise. You can run the script to create the database so that you have it for reference while working. Be aware, however, that the tests don't use that database. The tests use a temporary database with the same schema. You'll find the SQL for the temporary database in `EmployeeProjects.Tests/test-data.sql`.
2. Open the `DataAccessPart2Exercise.sln` solution in Visual Studio.
3. Run all the tests and note that they all fail.

## Step One: Explore starting code and database schema

Before you begin, review the provided classes in the `EmployeeProjects.Models` and `EmployeeProjects.DAO` namespaces.

You'll write your code to complete the data access methods in the `DepartmentSqlDao`, `EmployeeSqlDao`, and `ProjectSqlDao` classes.

It's a good idea to also familiarize yourself with the database schema by looking through the `EmployeeProjects.sql` script.

## Step Two: Implement custom exception handling for get methods

While the provided get methods select data from the database, they don't account for any exceptions that may occur when working with DAOs. 

It's up to you to modify these methods to throw the provided DAO exception. 

After you complete this step, the tests `DepartmentDao_GetMethods_ThrowDaoException`, `EmployeeDao_GetMethods_ThrowDaoException`, and `ProjectDao_GetMethods_ThrowDaoException` pass.

## Step Three: Implement the `DepartmentSqlDao` methods

Complete the data access methods in `DepartmentSqlDao`. Refer to the documentation comments in the `IDepartmentDao` interface for the expected input and result of each method.

You can remove any existing code in the method when you start working on it.

Be sure to include exception handling in your implementation to handle situations like being unable to connect to the database so that the test `DepartmentDao_GetMethods_ThrowDaoException` passes.

After you complete this step, the tests in `DepartmentSqlDaoTests` pass.

## Step Four: Implement the `ProjectSqlDao` methods

Complete the data access methods in `ProjectSqlDao`. Refer to the documentation comments in the `IProjectDao` interface for the expected input and result of each method.

You can remove any existing code in the method when you start working on it.

Be sure to include exception handling in your implementation to handle situations like being unable to connect to the database so that the test `ProjectDao_InsertUpdateDeleteMethods_ThrowDaoException` passes.

After you complete this step, the tests in `ProjectSqlDaoTests` pass.

## Step Five: Implement the `EmployeeSqlDao` methods

Complete the data access methods in `EmployeeSqlDao`. Refer to the documentation comments in the `IEmployeeDao` interface for the expected input and result of each method.

You can remove any existing code in the method when you start working on it.

Be sure to include exception handling in your implementation to handle situations like being unable to connect to the database so that the test `EmployeeDao_InsertUpdateDeleteMethods_ThrowDaoException` passes.

After you complete this step, the tests in `EmployeeSqlDaoTests` pass.
