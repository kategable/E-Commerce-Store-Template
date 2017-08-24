using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Models
{
    public class Pencil
    {
        public Pencil()
        {
            Buyers = new List<Buyer>();
        }

        public Pencil(string title, decimal price, string description)
        {
            Title = title;
            Price = price;
            Description = description;
            Buyers = new List<Buyer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<Buyer> Buyers { get; set; }
        public string ImagePath { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
