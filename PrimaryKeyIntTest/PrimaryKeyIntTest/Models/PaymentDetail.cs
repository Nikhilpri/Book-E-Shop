using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyIntTest.Models
{
    public class PaymentDetail
    {
        [Key]
        public int txnId { get; set; }

        [Required]
        [Display(Name = "Card Type")]
        public string CardType { get; set; }

        [Required]
        [Display(Name = "Mode of Payment")]
        public string CardMode { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "CVV")]
        public string Cvv { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/yyyy}")]
        [Display(Name = "Valid Upto")]
        public DateTime ExpMonthYear { get; set; }

        [Required]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }
    }
}