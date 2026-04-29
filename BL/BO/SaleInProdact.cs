
namespace BO
{
    public class SaleInProdact
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public bool ForAllCustomers { get; set; }

        public SaleInProdact(int id, int amount, double price, bool forAllCustomers)
        {
            this.Id = id;
            this.Amount = amount;
            this.Price = price;
            this.ForAllCustomers = forAllCustomers;
        }
    }
}