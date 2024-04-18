using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using Tutorial.DAO;
using Tutorial.Exceptions;
using Tutorial.Models;
using Tutorial.Services;

namespace Tutorial
{
    public class TutorialController
    {
        private readonly TutorialView view;
        private readonly IBasicConsole console;
        private readonly ICustomerDao customerDao;
        private readonly ISaleDao saleDao;

        private Customer currentCustomer;
        private Sale currentSale;

        public TutorialController(string connectionString, IBasicConsole console)
        {
            this.console = console;
            view = new TutorialView(console);
            customerDao = new CustomerSqlDao(connectionString);
            saleDao = new SaleSqlDao(connectionString);

            ResetDatabase(connectionString);
        }

        public void Run()
        {
            DisplayMainMenu();
        }

        public void DisplayMainMenu()
        {
            const string CustomerSelect = "Customer - select";
            const string SaleSelect = "Sale - create, read, update, delete";
            const string Exit = "Exit the program";
            string[] MenuOptions = { CustomerSelect, SaleSelect, Exit };

            console.PrintBlankLine();
            console.PrintMessage("Welcome to the Pizza Shop.");

            bool finished = false;
            while (!finished)
            {
                console.PrintBlankLine();
                string mainMenuTitle = "Main Menu\n" + SelectedBreadCrumbs();
                string selection = view.GetMenuSelection(mainMenuTitle, MenuOptions);
                if (selection == CustomerSelect)
                {
                    console.PrintBlankLine();
                    IList<Customer> customers = customerDao.GetCustomers();
                    Customer selectedCustomer = view.GetCustomerSelection(customers);
                    if (selectedCustomer == null)
                    {
                        // Deselect current customer and sale
                        currentCustomer = null;
                        currentSale = null;
                    }
                    else if (selectedCustomer != currentCustomer)
                    {
                        // Switch to selected customer and deselect sale
                        currentCustomer = selectedCustomer;
                        currentSale = null;
                    }
                }
                else if (selection == SaleSelect)
                {
                    console.PrintBlankLine();
                    if (currentCustomer != null)
                    {
                        SaleMenu();
                    }
                    else
                    {
                        console.PrintError("No customer selected.");
                    }
                }
                else if (selection == Exit)
                {
                    finished = true;
                }
            }
        }

        private void SaleMenu()
        {
            const string SelectSale = "Select sale";
            const string CreateSale = "Create new sale";
            const string UpdateSale = "Update selected sale";
            const string DeleteSale = "Delete selected sale";
            const string ReturnMainMenu = "Return to Main Menu";
            string[] MenuOptions = { SelectSale, CreateSale, UpdateSale, DeleteSale, ReturnMainMenu };

            bool finished = false;
            while (!finished)
            {
                console.PrintBlankLine();
                string title = "Sale Menu\n" + SelectedBreadCrumbs();
                string selection = view.GetMenuSelection(title, MenuOptions);
                console.PrintDivider();
                console.PrintBlankLine();

                if (selection == SelectSale)
                {
                    IList<Sale> sales = new List<Sale>();
                    // DAO in action !!!
                    try
                    {
                        sales = saleDao.GetSalesByCustomerId(currentCustomer.CustomerId);
                    }
                    catch (DaoException ex)
                    {
                        console.PrintError("DAO error occurred: " + ex.Message);
                    }
                    Sale selectedSale = view.GetSaleSelection(sales);
                    if (selectedSale == null)
                    {
                        // Deselect sale
                        currentSale = null;
                    }
                    else if (selectedSale != currentSale)
                    {
                        // Switch to selected sale
                        currentSale = selectedSale;
                    }
                }
                else if (selection == CreateSale)
                {
                    Sale newSale = view.CreateSale(currentCustomer);
                    if (newSale != null)
                    {
                        // DAO in action !!!
                        try
                        {
                            newSale = saleDao.CreateSale(newSale);
                            console.PrintBlankLine();
                            console.PrintMessage(newSale.ToString() + " CREATED !!!");
                            currentSale = newSale;
                        }
                        catch (DaoException ex)
                        {
                            console.PrintError("DAO error occurred: " + ex.Message);
                        }
                    }
                }
                else if (selection == UpdateSale)
                {
                    if (currentSale != null)
                    {
                        Sale updatedSale = view.UpdateSale(currentSale);
                        if (updatedSale != null)
                        {
                            // DAO in action !!!
                            try
                            {
                                updatedSale = saleDao.UpdateSale(updatedSale);
                                console.PrintBlankLine();
                                console.PrintMessage(updatedSale.ToString() + " UPDATED !!!");
                                currentSale = updatedSale;
                            }
                            catch (DaoException ex)
                            {
                                console.PrintError("DAO error occurred: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        console.PrintError("No sale selected.");
                    }
                }
                else if (selection == DeleteSale)
                {
                    if (currentSale != null)
                    {
                        if (view.DeleteSale(currentSale))
                        {
                            // DAO in action !!!
                            try
                            {
                                saleDao.DeleteSaleById(currentSale.SaleId);
                                console.PrintBlankLine();
                                console.PrintMessage(currentSale.ToString() + " DELETED !!!");
                                currentSale = null;
                            }
                            catch (DaoException ex)
                            {
                                console.PrintError("DAO error occurred: " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        console.PrintError("No sale selected.");
                    }
                }
                else if (selection == ReturnMainMenu)
                {
                    finished = true;
                }
            }
        }

        private string SelectedBreadCrumbs()
        {
            return "Selected: " +
                    (currentCustomer != null ? "[ " + currentCustomer.CustomerId + " | " + currentCustomer.FullName + " ]" : "---") + " >> " +
                    (currentSale != null ? "[ " + currentSale.SaleId + " | $" + currentSale.Total + " | " + currentSale.IsDelivery + " ]" : "---");
        }

        private void ResetDatabase(string connectionString)
        {
            try
            {
                string sqlCreate = File.ReadAllText("scripts/PizzaShopLite-create.sql");
                string sqlLoad = File.ReadAllText("scripts/PizzaShopLite-data.sql");
                
                using (SqlConnection mainConn = new SqlConnection(connectionString.Replace("PizzaShopLite", "master")))
                {
                    mainConn.Open();
                    SqlCommand cmd = new SqlCommand(sqlCreate, mainConn);
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection pizzaConn = new SqlConnection(connectionString))
                {
                    pizzaConn.Open();
                    SqlCommand cmd = new SqlCommand(sqlLoad, pizzaConn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (IOException ex)
            {
                console.PrintError("Error reading reset script: " + ex.Message);
            }
            catch (SqlException ex)
            {
                console.PrintError("Error resetting database: " + ex.Message);
            }
        }
    }
}
