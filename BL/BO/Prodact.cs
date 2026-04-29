using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;

namespace BO
{
    public class Prodact
    {

        public int id { get; set; }
        public string productName { get; set; }
        public category? productCategory { get; set; }
        public double price { get; set; }
        public int amount { get; set; }
        //????????????????????????????????????????????????????
<<<<<<< HEAD:BL/BO/Prodact.cs
        public override string ToString() => ToStringProperty();

=======
        //public override string ToString() => ToStringProperty();
        public Prodact() { }
>>>>>>> 694fd00deb8431271c3bf2bc0f54f2476e621e5c:BO/Prodact.cs
        public Prodact(int id, string productName, category? productCategory, double price, int amount)
        {
            this.id = id;
            this.productName = productName;
            this.productCategory = productCategory;
            this.price = price;
            this.amount = amount;
        }
    }
}
