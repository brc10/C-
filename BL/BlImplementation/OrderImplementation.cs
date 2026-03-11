using System;
using System.Collections.Generic;
using System.Linq;
using DO;
using DalApi;
using BO;
using BL.BO;

namespace BlImplementation
{
    internal class OrderImplementation 
        //: IOrder
    {
        private readonly IDal dal = Factory.Get;

        // עדכון המבצעים המתאימים למוצר בהזמנה
        public void SearchSaleForProduct(ProductInOrder product, bool existsCustomer)
        {
            var now = DateTime.Now;

            // שימוש ב-dal.sail (לפי ה-IDal שלך)
            var sales = from s in dal.sail.ReadAll()
                        where s.productId == product.id // וודאי שב-BO.ProductInOrder קראת לזה id
                        && s.beginSale <= now
                        && (s.endSale == null || s.endSale >= now)
                        && s.RequiredAmount <= product.amount
                        select s;

            if (!existsCustomer)
            {
                sales = sales.Where(s => s.onlyClub == false);
            }

            product.saleList = sales
                .OrderBy(s => s.salePrice)
                .Select(s => BO.Tools.ConvertSaleToProductInsale(s))
                .ToList();
        }

        // הוספת מוצר להזמנה
        public List<SaleInProdact> AddPoductToOrder(int productId, int amount, Order order)
        {
            // שימוש ב-dal.product (אות קטנה)
            var doProduct = dal.product.Read(productId) ?? throw new Exception("Product not found");

            if (doProduct.amount < amount)
                throw new Exception("Not enough in stock");

            var existingProduct = order.products?.FirstOrDefault(p => p.id == productId);

            if (existingProduct != null)
            {
                if (doProduct.amount < (existingProduct.amount + amount))
                    throw new Exception("Not enough in stock");

                existingProduct.amount += amount;
            }
            else
            {
                // יצירת מוצר חדש ברשימה
                existingProduct = new ProductInOrder(
                    doProduct.ProductId,
                    doProduct.name,
                    doProduct.price,
                    amount,
                    new List<SaleInProdact>(),
                    0);

                order.products ??= new List<ProductInOrder>();
                order.products.Add(existingProduct);
            }

            // קריאה לפונקציות העזר
            SearchSaleForProduct(existingProduct, !string.IsNullOrEmpty(order.CustomerName));
            CalcTotalPriceForProduct(existingProduct);
            CalcTotalPrice(order);

            return existingProduct.saleList;
        }

        public void CalcTotalPriceForProduct(ProductInOrder product)
        {
            int count = product.amount;
            double totalPrice = 0;
            product.finalPrice = 0; // איפוס לפני חישוב

            foreach (var s in product.saleList)
            {
                if (count < s.Amount) continue;

                int sumTimesGetSale = count / s.Amount;
                totalPrice += sumTimesGetSale * s.Price;
                count %= s.Amount; // משתמשים בשארית
            }

            totalPrice += (count * product.basePrice);
            product.finalPrice = totalPrice;
        }

        public void CalcTotalPrice(Order order)
        {
            order.finalPrice = order.products?.Sum(p => p.finalPrice) ?? 0;
        }

        public void DoOrder(Order order)
        {
            if (order.products == null || !order.products.Any())
                throw new Exception("Cannot process an empty order.");

            foreach (var p in order.products)
            {
                var doProduct = dal.product.Read(p.id);
                if (doProduct != null)
                {
                    int newAmount = doProduct.amount - p.amount;

                    // יצירת אובייקט DO.Prodact מעודכן
                    DO.Prodact updatedProduct = new DO.Prodact(
                        doProduct.ProductId,
                        doProduct.name,
                        doProduct.category,
                        doProduct.price,
                        newAmount
                    );

                    dal.product.Update(updatedProduct);
                }
            }
        }
    }
}
