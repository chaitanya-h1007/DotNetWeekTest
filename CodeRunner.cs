using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    // Simple console app to create and view patient bills
    public class CodeRunner
    {
        // Store the last bill
        private static Bill LastBill = new(); 
        // Flag to check if a bill was created
        private static bool HasLastBill = false;

        // App entry point
        public static void Main(string[] args)

        {
            string User_Input;

            do
            {
                // Show menu options
                Console.WriteLine("================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Delete Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");
                User_Input = Console.ReadLine();
                CheckUser_Input(User_Input);
                SwitchCaseInput(User_Input);
            }
            while (User_Input != "4");
            if (User_Input == "4") Console.WriteLine("Thank You. Application closed normally.");

        }

        // Run action based on user choice
        private static void SwitchCaseInput(string user_Input)
        {
            switch (user_Input)
            {
                case "1":
                    NewBill();
                    break;
                case "2":
                    ViewLastBill();
                    break;
                case "3":
                    // Delete last bill
                    LastBill = null;
                    break;
                default:
                    break;

            }
        }

        // Print the last saved bill or a message if none exists
        private static void ViewLastBill()
        {
            if(HasLastBill != false)
            {
                Console.WriteLine("----------- Last Bill -----------");
                Console.WriteLine("BillId: " + LastBill.BillId);
                Console.WriteLine("PatientName " + LastBill.PatientName);
                Console.WriteLine("Insured " + LastBill.HasInsurence);
                Console.WriteLine("Transaction Saved: ");
                Console.WriteLine($"Status: {Math.Round(LastBill.GrossAmount, 2)}");
                Console.WriteLine($"Profit/Loss Amount: {Math.Round(LastBill.DiscountAmount, 2)}");
                Console.WriteLine($"Profit Margin (%) {Math.Round(LastBill.FinalAmount, 2)}");
            }
            else
            {
                Console.WriteLine("Create a new bill. NO BILL Found");
            }
        }

        // Check menu input is valid
        public static void CheckUser_Input(string input)
        {
            if (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("!!Please Enter the Valid Option.!!");
            }
        }

        // Read bill details from user and save as last bill
        public static void NewBill()
        {
            Bill newBill = new Bill();

            string billId;
            string patientName;
            char hasInsurance;
            int consultationFee;
            int labCharges;
            int mediceneCharges;


            Console.WriteLine("Enter bill Id: ");
            billId = Console.ReadLine();
            Console.WriteLine("Enter Patient Name: ");
            patientName = Console.ReadLine();
            Console.WriteLine("Has Insurence [Y/N]");
            hasInsurance = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Consultation Fee:  ");
            consultationFee = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Lab Charges:  ");
            labCharges = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Medicine Charges:  ");
            mediceneCharges = int.Parse(Console.ReadLine());


            if (ValidateInputs(billId, patientName, hasInsurance, consultationFee, labCharges, mediceneCharges))
            {
                LastBill.BillId= billId;
                LastBill.PatientName = patientName;
                LastBill.HasInsurence = hasInsurance;
                LastBill.ConsultationFees = consultationFee;
                LastBill.LabCharges= labCharges;
                LastBill.Medicenecharges = mediceneCharges;
                LastBill.Calculate();
                HasLastBill = true;


                Console.WriteLine("Bill Generated Successfully: ");
                Console.WriteLine($"Gross Amount: {Math.Round(LastBill.GrossAmount,2)}");
                Console.WriteLine($"Discount Amount: {Math.Round(LastBill.DiscountAmount,2)
                    }");
                Console.WriteLine($"Final Payable: {Math.Round(LastBill.FinalAmount, 2)}");

            }
            else
            {
                Console.WriteLine("Invalid Inputs!");
            }

        }

        // Validate inputs for the bill
        private static bool ValidateInputs(string billId, string patientName, char hasInsurance, int consultationFee, int labCharges, int mediceneCharges)
        {
            if (string.IsNullOrWhiteSpace(billId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(patientName))
            {
                Console.WriteLine("Patient Name cannot be empty.");
                return false;
            }
            if (hasInsurance != 'Y' && hasInsurance != 'N' && hasInsurance != 'y' && hasInsurance != 'n')
            {
                Console.WriteLine("Has Insurance must be 'Y' or 'N'.");
                return false;
            }
            if (consultationFee < 0)
            {
                Console.WriteLine("Consultation Fee cannot be negative.");
                return false;
            }
            if (labCharges < 0)
            {
                Console.WriteLine("Lab Charges cannot be negative.");
                return false;
            }
            if (mediceneCharges < 0)
            {
                Console.WriteLine("Medicine Charges cannot be negative.");
                return false;
            }
            return true;
        }
    }
}
