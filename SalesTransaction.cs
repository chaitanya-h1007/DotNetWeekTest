using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    public class SalesTransaction
    {


        public string InvoiceNo { get; set; }
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal SellingAmount { get; set; }
        public string ProfitOrLossStatus { get; set; }
        public decimal ProfitOrLossAmount { get; set; }
        public decimal ProfitMarginPercent { get; set; }

        //Constructor
        public SalesTransaction() { }


        public void Calculate()
        {
            if(SellingAmount > PurchaseAmount)
            {
                ProfitOrLossStatus = "Profit";
                ProfitOrLossAmount = SellingAmount - PurchaseAmount;
                
            }
            else if(SellingAmount < PurchaseAmount) {
                ProfitOrLossStatus = "Loss";
                ProfitOrLossAmount = PurchaseAmount - SellingAmount;
            }
            else if(SellingAmount == PurchaseAmount)
            {
                ProfitOrLossStatus = "BREAK - EVEN";
                ProfitOrLossAmount = 0;
            }
            else
            {
                ProfitOrLossStatus = "Not Found";
                ProfitOrLossAmount = 0;
            }

            if(ProfitOrLossAmount > 0)
            {
                ProfitMarginPercent = (ProfitOrLossAmount / PurchaseAmount) * 100;
            }
;
              

        }
    }
}
