
namespace BO
{
    public class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int RequiredAmount { get; set; }
        public double SalePrice { get; set; }
        public bool OnlyClub { get; set; }
        public DateTime BeginSale { get; set; }
        public DateTime? EndSale { get; set; }

        // הבנאי (Constructor)
        public Sale() { }
        public Sale(int id, int productId, int requiredAmount, double salePrice, bool onlyClub, DateTime beginSale, DateTime? endSale)
        {
            this.Id = id;
            this.ProductId = productId;
            this.RequiredAmount = requiredAmount;
            this.SalePrice = salePrice;
            this.OnlyClub = onlyClub;
            this.BeginSale = beginSale;
            this.EndSale = endSale;
        }
    }
}