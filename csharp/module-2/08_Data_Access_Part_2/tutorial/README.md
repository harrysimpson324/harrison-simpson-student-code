# Data access part 2 tutorial

In this tutorial, you'll practice sending additional types of SQL statements to a database from C#. By the end of this tutorial, you'll have written code that:

- Sends `INSERT`, `UPDATE`, and `DELETE` SQL statements
- Retrieves the IDs of newly inserted rows
- Handles exceptions that can occur when interacting with a database

## Getting started

To get started, open the `DataAccessPart2Tutorial.sln` solution file in Visual Studio.

Expand the `Tutorial` project to see the files included with the starter code.

> Note: If you don't have the `PizzaShop` database, you can find the `PizzaShop.sql` file in your `resources/mssql` folder at the top of your repository or get it from your instructor.
> Once you have the `PizzaShop.sql` file, follow the instructions in the `Database setup` lesson in the `Microsoft SQL Server` unit of `Intro to Tools`.

## Before you begin

Take a moment to look through the starter code. This project starts where the previous tutorial ended. This project uses all of the code and concepts from that tutorial: the DAO pattern, loose coupling, `SqlConnection`, etc.

## Step One: Create a new customer

To complete this step, you'll add code to three C# files: `ICustomerDao`, `CustomerSqlDao`, and `Program`. 

Look for the following comment in each of the files:
```csharp
// Step One: Create a new customer
```
and add the code after it.

Currently, `ICustomerDao` can only retrieve `Customer` objects from the datastore. You can add additional methods to provide more features. 

Add this method to the `ICustomerDao` interface:

```csharp
/// <summary>
/// Create a new customer in the datastore with the given information.
/// </summary>
/// <param name="customer">Customer information to add.</param>
/// <returns>Customer object with the id populated.</returns>
Customer CreateCustomer(Customer customer);
```

Adding this method to the interface requires `CustomerSqlDao` which implements the interface to provide an implementation of the method.

Add this method to `CustomerSqlDao`:

```csharp
public Customer CreateCustomer(Customer customer)
{
    Customer newCustomer;

    int customerId;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        string sql = "INSERT INTO customer(first_name, last_name, street_address, city, phone_number, email_address, email_offers) " +
                "OUTPUT INSERTED.customer_id " +
                "VALUES (@first_name, @last_name, @street_address, @city, @phone_number, @email_address, @email_offers);";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@first_name", customer.FirstName);
        cmd.Parameters.AddWithValue("@last_name", customer.LastName);
        cmd.Parameters.AddWithValue("@street_address", customer.StreetAddress);
        cmd.Parameters.AddWithValue("@city", customer.City);
        cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
        cmd.Parameters.AddWithValue("@email_address", customer.EmailAddress);
        cmd.Parameters.AddWithValue("@email_offers", customer.EmailOffers);

        customerId = (int)cmd.ExecuteScalar();
    }

    newCustomer = GetCustomerById(customerId);
    return newCustomer;
}
```

Review the code of `CreateCustomer`. It contains a SQL `INSERT` statement with SQL parameters for all of the values. Even though the SQL inserts data, and you might expect the code to use the `SqlCommand.ExecuteNonQuery()` method, it uses the `ExecuteScalar()` method instead. This is due to the `OUTPUT INSERTED.customer_id` clause in the SQL. It causes SQL Server to return the `customer_id` of the new row as a result set just like a `SELECT` statement. `ExecuteScalar()` retrieves the value from the result set as an `object` so you must cast to the correct type for the value returned, `int` in this case.

> Note: `(int)cmd.ExecuteScalar()` has the same effect as `Convert.ToInt32(cmd.ExecuteScalar())` like you saw in the reading.

Add this code to `Program`. When executed it adds Lou Malnati to the datastore:

```csharp
Customer newCustomer = new Customer();
newCustomer.FirstName = "Lou";
newCustomer.LastName = "Malnati";
newCustomer.StreetAddress = "6649 North Lincoln Avenue";
newCustomer.City = "Lincolnwood";
newCustomer.PhoneNumber = "8476730800";
newCustomer.EmailAddress = "lou@loutmalnatis.com";
newCustomer.EmailOffers = true;

newCustomer = customerDao.CreateCustomer(newCustomer);
Console.WriteLine($"Customer with ID {newCustomer.CustomerId} created");
```

## Step Two: Update an existing customer

In Step Two, add code after the following comment in each of the three files:
```csharp
// Step Two: Update an existing customer
```

To update a customer you must again add a method declaration to the interface `ICustomerDao` and an implementation in `CustomerSqlDao`. 

Add this code to `ICustomerDao`:

```csharp
/// <summary>
/// Update an existing customer in the datastore with the given information.
/// </summary>
/// <param name="customer">Customer information to update.</param>
/// <returns>Updated Customer object.</returns>
Customer UpdateCustomer(Customer customer);
```

Add this code to `CustomerSqlDao`:

```csharp
public Customer UpdateCustomer(Customer customer)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        string sql = 
            "UPDATE customer " + 
            "SET first_name = @first_name, last_name = @last_name, street_address = @street_address, city = @city, " +
            "phone_number = @phone_number, email_address = @email_address, email_offers = @email_offers " + 
            "WHERE customer_id = @customer_id;";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@first_name", customer.FirstName);
        cmd.Parameters.AddWithValue("@last_name", customer.LastName);
        cmd.Parameters.AddWithValue("@street_address", customer.StreetAddress);
        cmd.Parameters.AddWithValue("@city", customer.City);
        cmd.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);
        cmd.Parameters.AddWithValue("@email_address", customer.EmailAddress);
        cmd.Parameters.AddWithValue("@email_offers", customer.EmailOffers);
        cmd.Parameters.AddWithValue("@customer_id", customer.CustomerId);

        cmd.ExecuteNonQuery();
    }

    return GetCustomerById(customer.CustomerId);
}
```
This implementation uses the `SqlCommand.ExecuteNonQuery()` method since the `UPDATE` statement doesn't return a result set.

Add this code to `Program` to call the new method and ensure it works properly.

```csharp
newCustomer.FirstName = "Louis";
customerDao.UpdateCustomer(newCustomer);

Customer updatedCustomer = customerDao.GetCustomerById(newCustomer.CustomerId);
Console.WriteLine($"In the datastore, updated customer's first name is now {updatedCustomer.FirstName}");
```

## Step Three: Delete a customer

As before add code to both `ICustomerDao` and `CustomerSqlDao` under the following comment:
```csharp
// Step Three: Delete a customer
```
Add this to `ICustomerDao`:

```csharp
// Step Three: Delete a customer
/// <summary>
/// Delete the customer with the given id.
/// </summary>
/// <param name="customerId">The id of the customer to delete.</param>
/// <returns>Number of customers deleted.</returns>
int DeleteCustomerById(int customerId);
```

Add this code to `CustomerSqlDao`:

```csharp
public int DeleteCustomerById(int customerId)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();

        string sql = "DELETE FROM customer WHERE customer_id = @customer_id";

        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@customer_id", customerId);

        return cmd.ExecuteNonQuery();
    }
}
```

The implementation again uses the `SqlCommand.ExecuteNonQuery()` method.

In `Program` add this code to remove Louis Malnati from the datastore:

```csharp
int numDeleted = customerDao.DeleteCustomerById(updatedCustomer.CustomerId);
if (numDeleted == 1 )
{
    Console.WriteLine("Customer successfully deleted");
}
else
{
    Console.WriteLine("Customer NOT deleted");
}
```

## Step Four: Delete a customer with sales

The customer Raquel Marcome has two sales in the datastore. Add this code to `Program` to delete Raquel Marcome from the datastore:

```csharp
IList<Customer> customers = customerDao.GetCustomersByName("Marcome", false);
customerDao.DeleteCustomerById(customers[0].CustomerId);
```

Run `Tutorial`. It throws a `SqlException` with the message:

```
The DELETE statement conflicted with the REFERENCE constraint "FK_sale_customer_id". The conflict occurred in database "PizzaShop", table "dbo.sale", column 'customer_id'.
The statement has been terminated.
```

The `DELETE` fails because there are rows in the `sale` table with foreign keys to Raquel Marcome. You could add code to `Program` to catch a `SqlException` but that would tightly couple `Program` with the SQL Server implementation of `ICustomerDao`. 

Note that the starter code contains the class `Tutorial.Exceptions.DaoException`. In `CustomerSqlDao` replace the implementation of `DeleteCustomerById` with this version:

```csharp
public int DeleteCustomerById(int customerId)
{
    try
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            string sql = "DELETE FROM customer WHERE customer_id = @customer_id";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@customer_id", customerId);

            return cmd.ExecuteNonQuery();
        }
    }
    catch (SqlException ex)
    {
        throw new DaoException("Error deleting customer", ex);
    }
}
```

The code catches a SQL-specific exception and throws a new exception not tied to a specific implementation.

In `Program` wrap the call to `customerDao.DeleteCustomerById` in a `try/catch`:

```csharp
try
{
    customerDao.DeleteCustomerById(customers[0].CustomerId);
}
catch (DaoException ex)
{
    Console.WriteLine(ex.Message);
}
```

Run `Tutorial` and note that it prints the exception's message.

## Next steps

`ICustomerDao` and `CustomerSqlDao` now handle all of the CRUD operations. `ISaleDao` and `SaleSqlDao`, however, only support reading. What methods can you add to these classes to support the other operations? What might the method names be and what would they return?
