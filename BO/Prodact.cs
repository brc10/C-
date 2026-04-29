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
        //public override string ToString() => ToStringProperty();
        public Prodact() { }
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
