# Week 2 Review: National Park Campsite (Part 2)

In this exercise, you'll continue working with the National Park Campsite Reservation database. 

You'll create DAO methods and integration tests to continue practicing writing application code that interacts with a database.

## Getting started

1. In the folder with this README, there's a `campground.sql` SQL script that drops and recreates the `npcampground` database. You can run that script to create a copy of the database to reference while you work. Be aware, however, that the tests don't use that database. The tests use a temporary database with the same structure. You'll find the SQL for that temporary database in `CampgroundReservations.Tests/test-data.sql`.
2. Open the `CampgroundReservations.sln` solution in Visual Studio.

## Step One: Explore starting code and database schema

The models, DAO classes, and interfaces are already created for you. Take a moment to look through the classes and tests to familiarize yourself with them.

You'll write code to complete and test the data access methods in the `CampgroundSqlDao`, `ParkSqlDao`, `ReservationSqlDao`, and `SiteSqlDao` classes.

You can explore the database in SQL Server Management Studio, read through the `database/campground.sql`, and view the provided ERD diagram in the `database` folder to familiarize yourself with the database and its schema.

The integration tests are in the `CampgroundReservations.Tests` project. There's a `BaseDaoTests` class that all the tests inherit from. This class sets up the temporary database for the integration tests, rolls back any changes after each test, and drops the temporary database when done.

The `BaseDaoTests` class exposes a property called `ParkId`. You can use this ID in your integration tests where you need to supply a Park ID.

## Step Two: Implement the `CampgroundSqlDao` methods

Complete the data access methods in `CampgroundSqlDao`: `GetCampgroundById()` and `GetCampgroundsByParkId()`. Refer to the documentation comments in the `ICampgroundDao` interface for the expected input and output of these methods.

When you have `GetCampgroundById()` implemented correctly, the `GetCampgroundById_Should_ReturnSpecificCampground` integration test passes.

You'll need to write the integration test for `GetCampgroundsByParkId()`. Find the `GetCampgroundsByParkId_Should_ReturnAllCampgroundsForPark` integration test and replace the `Assert.Fail()` with an integration test that verifies your method functions properly.

Use the data in the `CampgroundReservations.Tests/test-data.sql` file to create your integration test.

## Step Three: Implement the `ParkSqlDao` methods

Complete the data access method in `ParkSqlDao`: `GetParks()`. Refer to the documentation comments in the `IParkDao` interface for the expected input and output of this method.

You'll need to write the integration test for `GetParks()`. Find the `GetParks_Should_ReturnAllParksInLocationAlphabeticalOrder` integration test and replace the `Assert.Fail()` with an integration test that verifies your method functions properly.

Use the data in the `CampgroundReservations.Tests/test-data.sql` file to create your integration test.

## Step Four: Implement the `ReservationSqlDao` methods

There are two methods to implement in `ReservationSqlDao`: `GetReservationById()` and `CreateReservation()`. Refer to the documentation comments in the `IReservationDao` interface for the expected input and output of these methods.

When you have `CreateReservation()` implemented correctly, the `CreateReservation_Should_ReturnReservationWithNewId` integration test passes.

You'll need to write the integration test for `GetReservationById()`. Find the `GetReservationById_Should_ReturnSpecificReservation` integration test and replace the `Assert.Fail()` with an integration test that verifies your method functions properly.

Use the data in the `CampgroundReservations.Tests/test-data.sql` file to create your integration test.

## Step Five: Implement the `SiteSqlDao` methods

There are two methods to implement in `SiteSqlDao`: `GetSitesWithRVAccessByParkId()` and `GetSitesAvailableTodayByParkId()`. Refer to the documentation comments in the `ISiteDao` interface for the expected input and output of these methods.

When you have `GetSitesAvailableTodayByParkId()` implemented correctly, the `GetSitesAvailableTodayByParkId_Should_ReturnAvailableParks` integration test passes.

You'll need to write the integration test for `GetSitesWithRVAccessByParkId()`. Find the `GetSitesWithRVAccessByParkId_Should_ReturnSitesWithPositiveRVLength` integration test and replace the `Assert.Fail()` with an integration test that verifies your method functions properly.

Use the data in the `CampgroundReservations.Tests/test-data.sql` file to create your integration test.
