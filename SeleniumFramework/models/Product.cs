using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary3.models
{
    public class Product
    {
        public Product(string Description, string Price)
        {
            this.Description = Description;
            this.Price = Price;
        }
        public Product()
        {

        }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
