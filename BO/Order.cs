//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BO
//{
//    public class Order
//    {
//        public bool isSpecial;
//        public List<Prodact> ProdactInOrders;
//        public double finalPrice;
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    public class Order
    {
        public bool favorite { get; set; }
        public List<ProductInOrder> products { get; set; }
        public double finalPrice { get; set; }
        public string CustomerName { get; set; }

        //public override string ToString() => ToStringProperty();
        public Order() { }
        public Order(bool favorite, List<ProductInOrder> products, double finalPrice)
        {
            this.favorite = favorite;
            this.products = products;
            this.finalPrice = finalPrice;
            this.CustomerName = CustomerName;
        }
    }
}
