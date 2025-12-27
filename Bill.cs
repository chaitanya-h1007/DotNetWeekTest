using System;
using System.Collections.Generic;
using System.Text;

namespace Week1DotNet
{
    /// <summary>
    /// Represents a billing record for a patient, including charges, discounts, and final amount calculations.
    /// </summary>
    /// <remarks>The Bill class encapsulates information related to a patient's billing, such as consultation
    /// fees, laboratory charges, and medication charges. It also tracks whether the patient has insurance, which
    /// affects the discount applied to the total charges. Use the Calculate method to update the gross amount,
    /// discount, and final amount based on the current property values.</remarks>
    public class Bill
    {
        public string BillId { get; set; }
        public string PatientName { get; set; }
        public char HasInsurence { get; set; }
        public int ConsultationFees { get; set; }
        public int LabCharges { get; set; }
        public int Medicenecharges { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        /// <summary>
        /// Calculates the gross amount, discount, and final amount for the current consultation based on fees, charges,
        /// and insurance status.
        /// </summary>
        /// <remarks>This method updates the GrossAmount, DiscountAmount, and FinalAmount properties using
        /// the current values of ConsultationFees, LabCharges, Medicenecharges, and HasInsurence. If insurance is
        /// indicated, a 10% discount is applied to the gross amount.</remarks>
        public void Calculate()

        {

            GrossAmount = ConsultationFees + LabCharges + Medicenecharges;
            if (HasInsurence == 'Y')
            {
                DiscountAmount = GrossAmount * 0.10m;
            }
            else
            {
                DiscountAmount = 0;
            }
            FinalAmount = GrossAmount - DiscountAmount;

        }
        
    }
}
