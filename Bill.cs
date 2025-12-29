using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    /// <summary>
    /// Simple bill record for a patient with charges and discount.
    /// </summary>
    public class Bill
    {
        // Unique bill identifier
        public string BillId { get; set; }
        // Name of the patient
        public string PatientName { get; set; }
        // 'Y' if patient has insurance, otherwise 'N'
        public char HasInsurence { get; set; }
        // Consultation fee amount
        public int ConsultationFees { get; set; }
        // Laboratory charges
        public int LabCharges { get; set; }
        // Medicine charges
        public int Medicenecharges { get; set; }

        // Total before discount
        public decimal GrossAmount { get; set; }
        // Discount amount applied (if any)
        public decimal DiscountAmount { get; set; }
        // Amount to pay after discount
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Calculate gross, discount, and final amounts.
        /// </summary>
        public void Calculate()

        {
            // Sum all charges to get gross amount
            GrossAmount = ConsultationFees + LabCharges + Medicenecharges;

            // Apply 10% discount if patient has insurance
            if (HasInsurence == 'Y')
            {
                DiscountAmount = GrossAmount * 0.10m;
            }
            else
            {
                DiscountAmount = 0;
            }

            // Final amount after discount
            FinalAmount = GrossAmount - DiscountAmount;

        }
        
    }
}
