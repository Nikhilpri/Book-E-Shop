using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyIntTest.Models
{
    public class Cart
    {
       
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string OrderType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

 
        public string OrderStatus { get; set; }

     
        public int BookId { get; set; }
        public Book  Book { get; set; }

    }
}