using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleSale.Models
{
    
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }

    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string ItemUrl { get; set; }

        public string Year { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
    public class Reciept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sum { get; set; }
        public string Total { get; set; }
        public string Tax { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date
        { get; set; }
        public string RecieptItems { get; set; }


    }
   
}
