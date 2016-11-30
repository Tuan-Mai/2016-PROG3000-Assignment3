using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROG3000_asn3.Models
{

    public enum CurrencyType
    {
        CAD = 1,
        US,
        EUR
    }
    public class Invoice
    {
        private DateTime? dateNow;

        [Required(ErrorMessage = "Please enter the client name.")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Please enter the client address")]
        public string ClientAddress { get; set; }

        [Required(ErrorMessage = "Please enter the date of shipment")]
        [DisplayName("Date of Shipment")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DateOfShipment
        {
            
            get { return dateNow ?? DateTime.Now; }
            set { dateNow = value; }
        }

        [Required(ErrorMessage = "Please enter the payment due date")]
        [DisplayName("Payment Due Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime PaymentDueDate
        {

            get { return dateNow ?? DateTime.Now; }
            set { dateNow = value; }
        }

        [Required(ErrorMessage = "Please enter the product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter the product quantity")]
        public int ProductQuantity { get; set; }

        [Required(ErrorMessage = "Please enter the price of the unit")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Please select the currency type of your payment")]
        public CurrencyType Currency { get; set; }
    }
}