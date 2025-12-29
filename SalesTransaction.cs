using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    /// <summary>
    /// Simple model for a sales transaction. Holds data and computes profit/loss.
    /// </summary>
    public class SalesTransaction
    {

        // Invoice number for this sale
        public string InvoiceNo { get; set; }
        // Name of the customer
        public string CustomerName { get; set; }
        // Sold item name
        public string ItemName { get; set; }
        // Quantity sold
        public int Quantity { get; set; }
        // Cost price per item or total purchase amount
        public decimal PurchaseAmount { get; set; }
        // Selling price per item or total selling amount
        public decimal SellingAmount { get; set; }
        // "Profit", "Loss", or "BREAK - EVEN"
        public string ProfitOrLossStatus { get; set; }
        // Absolute amount of profit or loss
        public decimal ProfitOrLossAmount { get; set; }
        // Profit margin as a percent
        public decimal ProfitMarginPercent { get; set; }

        // Default constructor
        public SalesTransaction() { }

        // Calculate profit/loss and margin from purchase and selling amounts
        public void Calculate()
        {
            // Determine if this transaction is a profit, loss, or break-even
            if (SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "Profit";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
            }
            else if (SellingAmount < PurchaseAmount)
            {
                ProfitOrLossStatus = "Loss";
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else if (SellingAmount == PurchaseAmount)
            {
                ProfitOrLossStatus = "BREAK - EVEN";
                ProfitOrLossAmount = 0;
            }
            else
            {
                // Fallback case (should not normally happen)
                ProfitOrLossStatus = "Not Found";
                ProfitOrLossAmount = 0;
            }

            // If there is any profit or loss, calculate margin percent
            if (ProfitOrLossAmount > 0)
            {
                // Margin based on purchase amount
                ProfitMarginPercent = (ProfitOrLossAmount / PurchaseAmount) * 100;
            }
        }
    }
}
