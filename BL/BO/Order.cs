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

<<<<<<< HEAD:BL/BO/Order.cs
        public override string ToString() => ToStringProperty();

=======
        //public override string ToString() => ToStringProperty();
        public Order() { }
>>>>>>> 694fd00deb8431271c3bf2bc0f54f2476e621e5c:BO/Order.cs
        public Order(bool favorite, List<ProductInOrder> products, double finalPrice)
        {
            this.favorite = favorite;
            this.products = products;
            this.finalPrice = finalPrice;
            this.CustomerName = CustomerName;
        }
    }
}
