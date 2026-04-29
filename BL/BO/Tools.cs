using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T obj)
        {
            if (obj == null) return "null";
            StringBuilder sb = new StringBuilder();
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                object value = property.GetValue(obj);
                if (value != null)
                {
                    if (value is System.Collections.IEnumerable enumerableValue && !(value is string))
                    {
                        List<string> items = new List<string>();
                        foreach (var item in enumerableValue) items.Add(item.ToString()!);
                        sb.AppendLine($"{property.Name}: [{string.Join(", ", items)}]");
                    }
                    else
                    {
                        sb.AppendLine($"{property.Name}: {value}");
                    }
                }
                else
                {
                    sb.AppendLine($"{property.Name}: null");
                }
            }
            return sb.ToString();
        }

        // --- המרות לקוח (Castumer) ---
        public static BO.Castumer ConvertCustomerToBO(DO.Castumer customer)
        {
            // ב-DO זה: CastumerId, name, street, numCall
            return new BO.Castumer(customer.CastumerId, customer.name, customer.street, customer.numCall);
        }

        public static DO.Castumer ConvertToCustomerDO(BO.Castumer customer)
        {
            return new DO.Castumer(customer.id, customer.name, customer.adress ?? "null", customer.phone);
        }

        // --- המרות מכירה/מבצע (Sail) ---
        public static BO.Sale ConvertSaleToBO(DO.Sail sale)
        {
            // ב-DO זה: SailId, idProduct, count, PriceSail, CastumerSail, startDate, FinishDate
            return new BO.Sale(sale.SailId, sale.idProduct, sale.count, sale.PriceSail, sale.CastumerSail, sale.startDate, sale.FinishDate);
        }

        public static DO.Sail ConvertSaleToDO(BO.Sale sale)
        {
            return new DO.Sail(sale.Id, sale.ProductId, sale.RequiredAmount, (int)sale.SalePrice, sale.OnlyClub, sale.BeginSale, sale.EndSale ?? DateTime.MaxValue);
        }

        // --- המרות מוצר (Prodact) ---
        public static BO.Prodact ConvertProductToBO(DO.Prodact product)
        {
            // ב-DO קראת לזה: ProductId, name, category, price, stok
            return new BO.Prodact(product.ProductId, product.name, (BO.category)product.category, product.price, 0);
        }

        public static DO.Prodact ConvertProductToDO(BO.Prodact product)
        {
            // וודאי שהמחלקה ב-DO מאוייתת Prodact (עם א')
            return new DO.Prodact(product.id, product.productName, (DO.category)product.productCategory, (int)product.price, product.amount > 0);
        }


        public static BO.SaleInProdact ConvertSaleToProductInsale(DO.Sail sale)
        {
            return new BO.SaleInProdact(sale.SailId, sale.count, sale.PriceSail, !sale.CastumerSail);
        }
    }
}