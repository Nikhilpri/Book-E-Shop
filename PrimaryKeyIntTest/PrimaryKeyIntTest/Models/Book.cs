using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrimaryKeyIntTest.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }  /// <summary>
        /// changed Id to BookId
        /// </summary>
        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookCode { get; set; }
         
               
        [Required]
        public string   BookDescription { get; set; }
        
        
        [Required]
        public string Author { get; set; }
        
        
        [Required]
        public string BookCategory { get; set; }
        
        
        [Required]
        public string BookType { get; set; }
        
        
        [Required]
        public  string Option { get; set; }
        
        
        [Required]
        public double Rate { get; set; }
        
        
        public double Discounts { get; set; }


        public DateTime TimeStamp { get; set; }

        public bool Archived { get; set; }



    }
}