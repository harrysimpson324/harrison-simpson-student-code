# DAO testing tutorial

In this tutorial, you'll write integration tests for the Pizza Shop `SaleSqlDao`.

The tutorial includes a small console application, the `SaleSqlDao`, and a scaled-down version of the Pizza Shop database, `PizzaShopLite`. You don't need to make any modifications or perform any additional steps such as setting up the database to run the application.

> Note: typically you only use a scaled-down database for your tests, but this tutorial uses the database for the console application too so you can explore the data and help you write tests.

The only changes you'll make are to the `SaleSqlDaoTests.cs` test class file where you'll implement MSTest tests for the CRUD methods in `SaleSqlDao`.

If you need help on using the console application, you can read the [application walkthrough](application-walkthrough.md).

## Review mock database connection

DAO tests rely upon a connection to a *mock* database. The mock, or testing, database is an entirely separate database from the application database, although the two usually share the same structure in terms of tables and constraints. The difference between the two is usually in the amount of data each has. The application database typically contains a rich set of records, while the testing database has a limited number of records defining a handful of test cases.

The `BaseDaoTests.cs` class is responsible for setting up the test database, the connection for the integration tests, starting a transaction before every test, and rolling it back after every test.

### Setting up the test database

The `BeforeAllTests()` method runs before any test runs. It creates the test database using the `create-test-db.sql` script and populate the test data with `test-data.sql`. The `AdminConnectionString` connects to the default `master` database, allowing it to safely drop and re-create the `PizzaShopLiteTesting` database:

```c#
// BaseDaoTests.cs
[TestClass]
public class BaseDaoTests
{
    private const string DatabaseName = "PizzaShopLiteTesting";
    private static string AdminConnectionString;
    protected static string ConnectionString;

    [AssemblyInitialize]
    public static void BeforeAllTests(TestContext context)
    {
        // assign values to AdminConnectionString and ConnectionString
        SetConnectionStrings(DatabaseName);

        // load drop/create script, replace generic "test_db_name" placeholder
        string sql = File.ReadAllText("create-test-db.sql").Replace("test_db_name", DatabaseName);

        // drop (if exists) and create database
        using (SqlConnection conn = new SqlConnection(AdminConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        // populate test data
        sql = File.ReadAllText("test-data.sql");
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
        }
    }

    // ...
}
```

The `AfterAllTests()` method runs after the last test completes. It drops the temporary database using the `drop-test-db.sql` script:

```c#
// BaseDaoTests.cs

[AssemblyCleanup]
public static void AfterAllTests()
{
    // load drop script, replace generic "test_db_name" placeholder
    string sql = File.ReadAllText("drop-test-db.sql").Replace("test_db_name", DatabaseName);

    // drop the temporary database
    using (SqlConnection conn = new SqlConnection(AdminConnectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }
}
```

## Review DAO tests class

You'll add your DAO tests to `SaleSqlDaoTests`, but first take a look at the provided code:

```c#
[TestClass]
public class SaleSqlDaoTests : BaseDaoTests
{
    private SaleSqlDao saleSqlDao;

    [TestInitialize]
    public override void Setup()
    {
        // Arrange - new instance of SaleSqlDao before each and every test
        saleSqlDao = new SaleSqlDao(ConnectionString);
        base.Setup();
    }

    // Five empty tests ...

    // Convenience method in lieu of a Sale constructor with all the fields as parameters.
    // Similar to MapRowToSale() in SaleSqlDao.
    private static Sale MapValuesToSale(int saleId, decimal total, bool delivery, int? customerId)
    {
        Sale sale = new Sale();
        sale.SaleId = saleId;
        sale.Total = total;
        sale.IsDelivery = delivery;
        sale.CustomerId = customerId;
        return sale;
    }

    private void AssertSalesMatch(Sale expected, Sale actual, string message)
    {
        Assert.AreEqual(expected.SaleId, actual.SaleId, message);
        Assert.AreEqual(expected.Total, actual.Total, message);
        Assert.AreEqual(expected.IsDelivery, actual.IsDelivery, message);
        Assert.AreEqual(expected.CustomerId, actual.CustomerId, message);
    }
}
```

The `SaleSqlDaoTests` class extends the `BaseDaoTests` class so it can use its `ConnectionString`. This `ConnectionString` initializes the `saleSqlDao` in the `Setup()` method every time a test runs.

There are also two helper methods provided, `MapValuesToSale()` and `AssertSalesMatch()` to create new instances of `Sale` objects and to assert two `Sale` objects are equal.

In between the `Setup()` and two helper methods are five failing test methods. You'll replace each `Assert.Fail("Test not implemented.")` in the next five steps.

## Step One: Add the `GetSaleById_Returns_Correct_Sale` test

If you read the [application walkthrough](application-walkthrough.md), you'll remember that Madge Lampaert was the customer used for the examples.

Test `GetSaleById()` by asking for Madge Lampaert's first sale and asserting the returned sale isn't null and matches the expected values.

First, create constants for Madge's customer ID and the first sale ID to use where needed:

```c#
// Step One: Add constants for Madge
private const int MadgeCustomerId = 3;
private const int MadgeFirstSaleId = 5;
```

Then, fill out the test method:

```c#
[TestMethod]
public void GetSaleById_Returns_Correct_Sale()
{
    // Step One: Replace Assert.Fail("Test not implemented.")

    // Arrange - create an instance of Madge's first Sale object
    Sale madgeFirstSale = MapValuesToSale(MadgeFirstSaleId, 23.98M, true, MadgeCustomerId);

    // Act - retrieve Madge's first sale
    Sale sale = saleSqlDao.GetSaleById(MadgeFirstSaleId);

    // Assert - retrieved sale is not null and matches expected sale
    Assert.IsNotNull(sale, "GetSaleById(" + MadgeFirstSaleId + ") returned null");
    AssertSalesMatch(madgeFirstSale, sale, "GetSaleById(" + MadgeFirstSaleId + ") returned wrong or partial data");
}
```

As the comments in the preceding code describe, first you create an instance of Madge's first sale using the constants and other known values of that sale. Next, you call the `GetSaleById()` method using the constant for the first sale. Lastly, you check that the retrieved sale isn't null, and that it's equal to the expected value of Madge's first sale.

## Step Two: Add the `GetSalesByCustomerId_With_Valid_Id_Returns_Correct_Sales()` test

Test `GetSalesByCustomerId()` by asking for sales for Madge, a customer who has no sales, and a non-existent customer. With each customer's sales, asserting the size of the list returned. Madge has two known sales, while the customer without sales, and the unknown customer both return empty lists.

Add constants for the IDs of the other two customers:

```java
// Step Two: Add constants for customer without sale and non-existent customer
private const int CustomerWithoutSalesId = 5;
private const int NonExistentCustomerId = 7;
```

Then, fill out the test method:

```c#
[TestMethod]
public void GetSalesByCustomerId_With_Valid_Id_Returns_Correct_Sales()
{
    // Step Two: Replace Assert.Fail("Test not implemented.")

    // Act - retrieve sales for Madge
    IList<Sale> sales = saleSqlDao.GetSalesByCustomerId(MadgeCustomerId);
    // Assert - Madge has two existing sales
    Assert.AreEqual(2, sales.Count, "GetSalesByCustomerId(" + MadgeCustomerId + ") returned wrong number of sales");

    // Act - retrieve customer with no sales
    sales = saleSqlDao.GetSalesByCustomerId(CustomerWithoutSalesId);
    // Assert - list of sales is empty for customer with no sales
    Assert.AreEqual(0, sales.Count, "GetSalesByCustomerId(" + CustomerWithoutSalesId + ") without sales returned wrong number of sales");

    // Act - retrieve customer that doesn't exist
    sales = saleSqlDao.GetSalesByCustomerId(NonExistentCustomerId);
    // Assert - list of sales is empty for customer that doesn't exist
    Assert.AreEqual(0, sales.Count, "Customer doesn't exist, GetSalesByCustomerId(" + NonExistentCustomerId + ") returned the wrong number of sales");
}
```

Like in the first problem, the comments describe what each statement in the test is doing. Each pair of statements retrieves the sales for one of the three customers and asserts that the list is the correct size.

> Note: It's common to split the three different scenarios into separate tests. This tutorial intends to show you how to test the different scenarios in a concise way.

## Step Three: Add the `CreateSale_Creates_Sale()` test

Test `CreateSale()` by creating a `Sale` object for Madge and asserting the `saleId` for the returned `Sale` has a value set, and the `total`, `delivery`, and `customerId` are the expected values:

```c#
[TestMethod]
public void CreateSale_Creates_Sale()
{
    // Step Three: Replace Assert.Fail("Test not implemented.")

    // Arrange - instantiate a new Sale object for Madge
    Sale newSale = new Sale();
    newSale.Total = 34.56M;
    newSale.IsDelivery = true;
    newSale.CustomerId = MadgeCustomerId;

    // Act - create sale from instantiated Sale object
    Sale createdSale = saleSqlDao.CreateSale(newSale);

    // retrieve newly created sale
    int newId = createdSale.SaleId;
    Sale retrievedSale = saleSqlDao.GetSaleById(newId);

    // Assert - created sale is correct
    Assert.AreNotEqual(0, createdSale.SaleId, "SaleId not set when created, remained 0");
    Assert.AreEqual(createdSale.Total, retrievedSale.Total);
    Assert.AreEqual(createdSale.IsDelivery, retrievedSale.IsDelivery);
    Assert.AreEqual(createdSale.CustomerId, retrievedSale.CustomerId);
}
```

## Step Four: Add the `UpdateSale_Updates_Sale()` test

Test `UpdateSale()` by retrieving Madge's first sale, modifying the `total` and `delivery` properties, update with the modified sale object, and then retrieving the sale and asserting the updated sale has the expected modifications:

```c#
[TestMethod]
public void UpdateSale_Updates_Sale()
{
    // Step Four: Replace Assert.Fail("Test not implemented.")

    // Arrange - retrieve Madge's first sale and change values
    Sale saleToUpdate = saleSqlDao.GetSaleById(MadgeFirstSaleId);
    saleToUpdate.Total = 89.32M;
    saleToUpdate.IsDelivery = false;

    // Act - update the existing sale with changed values and re-retrieve
    Sale updatedSale = saleSqlDao.UpdateSale(saleToUpdate);
    Sale retrievedSale = saleSqlDao.GetSaleById(MadgeFirstSaleId);

    // Assert - sale has been updated correctly
    AssertSalesMatch(updatedSale, retrievedSale, "Updated Madge's first sale returned wrong or partial data");
}
```

## Step Five: Add the `DeleteSaleById_Deletes_Sale()` test

Test `DeleteSaleById()` by deleting Madge's first sale, and then attempting to retrieve it, asserting that the retrieved sale is null:

```c#
[TestMethod]
public void DeleteSaleById_Deletes_Sale()
{
    // Step Five: Replace Assert.Fail("Test not implemented.")

    // Act - delete existing first sale for Madge
    int rowsAffected = saleSqlDao.DeleteSaleById(MadgeFirstSaleId);

    // Assert - Madge's deleted sale can't be retrieved
    Assert.AreEqual(1, rowsAffected, "Sale not deleted");
    Sale retrievedSale = saleSqlDao.GetSaleById(MadgeFirstSaleId);
    Assert.IsNull(retrievedSale, "Deleted sale can still be retrieved");
}
```

## Next steps

Now that you've written an initial set of tests for `SaleSqlDao`, you could enrich them. For instance, you could add a test of `GetSaleById()` with the ID of a non-existent sale. Or, testing each sale item returned from `GetSalesByCustomerId()` rather than just checking the size of the list.

Another possibility would be to add tests for the two methods in `CustomerSqlDao`. They would follow the pattern of the `SaleSqlDaoTests` tests and added in a new `CustomerSqlDaoTests` class. Don't forget to extend `BaseDaoTests`.

Finally, the create, update, and delete tests of the corresponding methods in `SaleSqlDao` follow the happy path. Try testing deleting a non-existent sale, or updating a sale with an ID for an unknown customer.
