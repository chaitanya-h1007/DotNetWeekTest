using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Week1DotNet
{
    public class Program
    {
        
        private static SalesTransaction LastTransaction = new();
        private static bool HasLastTransaction = false;

        public static void Main(string[] args)
        {
            string User_Input;

            do
            {
                Console.WriteLine("================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");
                User_Input = Console.ReadLine();
                CheckUser_Input(User_Input);
                SwitchCaseInput(User_Input);
            }
            while (User_Input != "4");
            if (User_Input == "4") Console.WriteLine("Thank You. Application closed normally.");


            
        }

        private static void SwitchCaseInput(string user_Input)
        {
            switch (user_Input)
            {
                case "1":
                    NewTransaction();
                    break;
                case "2":
                    ViewLastTransaction();
                    break;
                case "3":
                    LastTransaction.Calculate();
                    ViewLastTransaction();
                    break;
                default:
                    break;

            }
        }

        public static void CheckUser_Input(string input)
        {
            if (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("!!Please Enter the Valid Option.!!");
            }
        }

        public static void NewTransaction()
        {
            SalesTransaction newTransaction = new SalesTransaction();

            string invoiceNum;
            string customerName;
            string itemName;
            int quantity;
            decimal purchaseAmount;
            decimal sellingAmount;


            Console.WriteLine("Enter Invoice No: ");
            invoiceNum = Console.ReadLine();
            Console.WriteLine("Enter Customer Name: ");
            customerName = Console.ReadLine();
            Console.WriteLine("Enter Item Name:");
            itemName = Console.ReadLine();
            Console.WriteLine("Enter Quantity: ");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Purchase Amount (total): ");
            purchaseAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Selling Amount (total): ");
            sellingAmount = decimal.Parse(Console.ReadLine());


            if(ValidateInputs(invoiceNum,customerName,itemName,quantity,purchaseAmount, sellingAmount))
            {
                newTransaction.InvoiceNo = invoiceNum;
                newTransaction.CustomerName = customerName;
                newTransaction.ItemName = itemName;
                newTransaction.Quantity = quantity;
                newTransaction.PurchaseAmount = purchaseAmount;
                newTransaction.SellingAmount = sellingAmount;

                LastTransaction.InvoiceNo = invoiceNum;
                LastTransaction.CustomerName = customerName;
                LastTransaction.ItemName = itemName;
                LastTransaction.Quantity = quantity;
                LastTransaction.PurchaseAmount = purchaseAmount;
                LastTransaction.SellingAmount = sellingAmount;
                LastTransaction.Calculate();
                HasLastTransaction = true;
            }



        }


        public static bool ValidateInputs(string invoiceNum, string c_Name, string itemName, int quat, decimal purchaseamt, decimal sellingAmt)
        {
            if(invoiceNum != string.Empty && quat > 0 && purchaseamt > 0 && sellingAmt > 0)
            {
                return true;
            }
            return false;
        }

        public static void ViewLastTransaction()
        {
            Console.WriteLine("InvoiceNo: " + LastTransaction.InvoiceNo);
            Console.WriteLine("Customer: " + LastTransaction.CustomerName);
            Console.WriteLine("Item: " + LastTransaction.ItemName);
            Console.WriteLine("Quantity: " + LastTransaction.Quantity);
            Console.WriteLine("Purchase Amount: "+ LastTransaction.PurchaseAmount);
            Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount);
            Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
            Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount);
            Console.WriteLine($"Profit Margin (%) {Math.Round(LastTransaction.ProfitMarginPercent,2)}");
        }
    }
}
