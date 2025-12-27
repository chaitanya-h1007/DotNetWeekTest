using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    public class CodeRunner
    {
        private static Bill LastBill = new();
        private static bool HasLastBill = false;
        public static void Main(string[] args)

        {
            string User_Input;

            do
            {
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
        /// <summary>
        /// Processes the specified user input and performs the corresponding action based on predefined options.
        /// </summary>
        /// <remarks>If the input does not match any recognized option, no action is performed.</remarks>
        /// <param name="user_Input">The user input string that determines which action to execute. Expected values are "1", "2", or "3".</param>
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
                    LastBill = null;
                    break;
                default:
                    break;

            }
        }
        /// <summary>
        /// Displays the details of the most recently created bill in the console output.
        /// </summary>
        /// <remarks>If no previous bill exists, a message indicating that no bill was found is displayed.
        /// This method is intended for use in console applications to review the last bill's summary
        /// information.</remarks>
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
        /// <summary>
        /// Validates the specified user input and displays a message if the input is not a recognized option.
        /// </summary>
        /// <param name="input">The user input to validate. Expected values are "1", "2", "3", or "4".</param>
        public static void CheckUser_Input(string input)
        {
            if (input != "1" && input != "2" && input != "3" && input != "4")
            {
                Console.WriteLine("!!Please Enter the Valid Option.!!");
            }
        }
        /// <summary>
        /// Prompts the user to enter billing information, validates the input, and generates a new bill with the
        /// provided details.
        /// </summary>
        /// <remarks>If the input is valid, the method calculates the bill amounts and displays the gross
        /// amount, discount, and final payable amount to the console. If the input is invalid, an error message is
        /// displayed. The generated bill is stored as the last bill for subsequent access.</remarks>
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
        /// <summary>
        /// Validates the input values for a billing operation, ensuring that all required fields are present and meet
        /// expected constraints.
        /// </summary>
        /// <remarks>If any input is invalid, an error message is written to the console describing the
        /// issue.</remarks>
        /// <param name="billId">The unique identifier for the bill. Cannot be null, empty, or consist only of white-space characters.</param>
        /// <param name="patientName">The name of the patient. Cannot be null, empty, or consist only of white-space characters.</param>
        /// <param name="hasInsurance">A character indicating whether the patient has insurance. Must be 'Y' or 'N' (case-insensitive).</param>
        /// <param name="consultationFee">The consultation fee amount. Must be zero or a positive integer.</param>
        /// <param name="labCharges">The laboratory charges amount. Must be zero or a positive integer.</param>
        /// <param name="mediceneCharges">The medicine charges amount. Must be zero or a positive integer.</param>
        /// <returns>true if all input values are valid; otherwise, false.</returns>
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
