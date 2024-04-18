# DAO testing exercise

The `EmployeeTimesheets` database is very similar to the database used in the previous exercise, it includes a new `timesheet` table. A new DAO exists to handle creating, reading, updating, and deleting records from the `timesheet` table. For this exercise, you'll be responsible for writing integration tests and using them to identify bugs in this new DAO. You'll then fix the bugs you've found and report them in a bug report.

## Learning objectives

After completing this exercise, you'll understand:

* How to write integration tests.
* How to use integration tests to find bugs in a DAO.

## Evaluation criteria and functional requirements

The instruction team evaluates your code for this assignment based on the following criteria:

* The project must not have any build errors.
* You must fill out the provided `BugReport.txt` file for four bugs you found and fixed.
* The provided integration test methods must all be completed and passing.
* Code is clean, concise, and readable.

## Getting started

1. If you haven't done so already, create the `EmployeeTimesheets` database. The script to do this is `database/EmployeeTimesheets.sql` included with this exercise. You can run the script to create the database so that you have it for reference while working. Be aware, however, that the tests don't use that database. The tests use a temporary database with the same schema. You'll find the SQL for the temporary database in `EmployeeTimesheets.Tests/test-data.sql`.
2. Open the `DaoTestingExercise.sln` solution in Visual Studio.

## Step One: Explore starting material

Before you begin:
 - Review the provided classes in the `Models` and `DAO` folders.
 - Familiarize yourself with the provided test classes and the `test-data.sql` file.
 - Open the `BugReport.txt` file and note what steps you must take to report the bugs you find during this exercise.

## Step Two: Implement the `TimesheetSqlDaoTests` methods

In the eight test methods, replace the `Assert.Fail()` with the code necessary to implement the test described by the method name. You can refer to the comments in the `ITimesheetDao` interface for descriptions of what each DAO method does.

Use this unit's reading and the integration tests from the previous DAO exercises as examples to reference while working. Static constant `Timesheet`s have been provided that you can use in your tests.

When fully implemented, four of the tests pass, and four continue to fail due to bugs in `TimesheetSqlDao`.

## Step Three: Complete bug reports and fix bugs

Fill out `BugReport.txt` with information about the four bugs you've identified in `TimesheetSqlDao` using the integration tests.

---
### An example of reporting and fixing a bug

Consider the following `DeleteTimesheetById` method:

```csharp
public int DeleteTimesheetById(int timesheetId)
{
    string sql = "DELETE FROM timesheet WHERE timesheet_id = @timesheet_id;";

    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@timesheet_id", 1);

            return cmd.ExecuteNonQuery();
        }
    }
    catch (SqlException ex)
    {
        throw new DaoException("Error deleting timesheet", ex);
    }
}
```

This method contains a bug. It always deletes the record with a `timesheet_id` of 1 rather than using the value of `timesheetId`.

There are several ways this could cause the `DeleteTimesheetById_Deletes_Timesheet` test to fail.

If the test called `DeleteTimesheetById(2)` and then verified whether the timesheet was deleted using `GetTimesheetById(2)`, the timesheet will still be retrieved and the test would fail.

After that test fails, you'd fix the `DeleteTimesheetById` method like this:

```csharp
public int DeleteTimesheetById(int timesheetId)
{
    string sql = "DELETE FROM timesheet WHERE timesheet_id = @timesheet_id;";

    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@timesheet_id", timesheetId);

            return cmd.ExecuteNonQuery();
        }
    }
    catch (SqlException ex)
    {
        throw new DaoException("Error deleting timesheet", ex);
    }
}
```

Then, in this scenario you fill-out the fields in `BugReport.txt` like so:

```
Test that demonstrates problem:
    DeleteTimesheetById_Deletes_Timesheet
Expected output:
    GetTimesheetById(2) returns null after calling DeleteTimesheetById(2)
Actual output:
    GetTimesheetById(2) was still returning a Timesheet object
How did you fix this bug?
    Replaced hardcoded value of 1 in DeleteTimesheetById with timesheetId so it doesn't always delete the same timesheet.
```
---

After you've found, fixed, and documented the four bugs, all of the tests in `TimesheetSqlDaoTests` pass, and the exercise is ready to be submitted to your instructor.
