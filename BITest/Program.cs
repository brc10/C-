namespace BITest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            switch (IOrder)
            {
                case 1:
                    // עדכון המבצעים המתאימים למוצר בהזמנה
                    //ProductInOrder product, bool existsCustomer
                    SearchSaleForProduct();
                    break;
                case 2:
                    // הוספת מוצר להזמנה
                    //int productId, int amount, Order order
                    AddPoductToOrder();
                    break;
                case 3:
                    //ProductInOrder product
                    CalcTotalPriceForProduct();
                    break;
                case 4:
                    //Order order
                    CalcTotalPrice();
                    break;
                case 5:
                    //Order order
                    DoOrder();
                    break;
                default:
            }
        }
    }
}
