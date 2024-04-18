using System.Collections.Generic;
using Tutorial.Models;
using Tutorial.Services;

namespace Tutorial
{
    public class TutorialView
    {
        private readonly IBasicConsole console;

        public TutorialView(IBasicConsole console)
        {
            this.console = console;
        }

        public string GetMenuSelection(string menuTitle, string[] options)
        {
            console.PrintBanner(menuTitle);
            return console.GetMenuSelection(options);
        }

        public Customer GetCustomerSelection(IList<Customer> customers)
        {
            Customer selectedCustomer = null;

            if (customers.Count > 0)
            {
                console.PrintMessage("Customer List");
                console.PrintDivider();
                string[] options = new string[customers.Count];
                for (int i = 0; i < customers.Count; i++)
                {
                    options[i] = customers[i].FullName;
                }
                int? selection = console.GetMenuSelectionIndex(options, true);
                if (selection != null)
                {
                    selectedCustomer = customers[selection.Value];
                }
            }
            else
            {
                console.PrintError("No customers found.");
            }
            return selectedCustomer;
        }

        public Sale GetSaleSelection(IList<Sale> sales)
        {
            Sale selectedSale = null;

            if (sales.Count > 0)
            {
                console.PrintMessage("Sale List");
                console.PrintDivider();
                string[] options = new string[sales.Count];
                for (int i = 0; i < sales.Count; i++)
                {
                    options[i] = sales[i].ToString();
                }
                int? selection = console.GetMenuSelectionIndex(options, true);
                if (selection != null)
                {
                    selectedSale = sales[selection.Value];
                }
            }
            else
            {
                console.PrintError("No sales for customer.");
            }
            return selectedSale;
        }

        public Sale CreateSale(Customer customer)
        {
            Sale newSale = null;

            console.PrintMessage("Enter new sale information");
            console.PrintDivider();
            decimal total = console.PromptForDecimal("Total");
            bool delivery = console.PromptForYesNo("Delivery (Y/N)?");
            console.PrintDivider();

            console.PrintBlankLine();
            bool createNewSale = console.PromptForYesNo("Are you sure you wish to create the new sale (Y/N)?");
            if (createNewSale)
            {
                newSale = new Sale();
                newSale.Total = total;
                newSale.IsDelivery = delivery;
                newSale.CustomerId = customer.CustomerId;
            }
            return newSale;
        }

        public void DisplaySale(Sale sale)
        {
            console.PrintMessage("Current sale information");
            console.PrintDivider();
            DisplaySaleInfo(sale);
        }

        public void DisplayProposedUpdate(Sale sale)
        {
            console.PrintMessage("Proposed update to sale");
            console.PrintDivider();
            DisplaySaleInfo(sale);
        }

        public void DisplaySaleInfo(Sale sale)
        {
            console.PrintMessage("Sale Id: " + sale.SaleId);
            console.PrintMessage("Total: " + sale.Total);
            console.PrintMessage("Delivery: " + sale.IsDelivery);
            console.PrintMessage("Customer: " + sale.CustomerId);
        }

        public Sale UpdateSale(Sale sale)
        {
            DisplaySale(sale);
            console.PrintDivider();

            console.PrintBlankLine();
            console.PrintMessage("Update sale information");
            console.PrintDivider();
            Sale updatedSale = new Sale();
            updatedSale.SaleId = sale.SaleId;
            updatedSale.CustomerId = sale.CustomerId;
            updatedSale.Total = console.PromptForDecimal("Total", sale.Total);
            updatedSale.IsDelivery = console.PromptForYesNo("Delivery (Y/N)?", sale.IsDelivery);
            console.PrintDivider();

            DisplayProposedUpdate(updatedSale);
            console.PrintDivider();

            console.PrintBlankLine();
            bool okToUpdate = console.PromptForYesNo("Are you sure you wish to update the sale (Y/N)?");
            if (!okToUpdate)
            {
                updatedSale = null;
            }
            return updatedSale;
        }

        public bool DeleteSale(Sale sale)
        {
            DisplaySale(sale);
            console.PrintDivider();

            console.PrintBlankLine();
            return console.PromptForYesNo("Are you sure you wish to delete the sale (Y/N)?");
        }
    }
}
