
//namespace DO;

//public record Prodact(int ProductId,string name,category category,int price,bool stok)
//{
//    public Prodact() : this(0, "null", category.גלידות, 0, false) { }

//    public Prodact(int productId, string name, category category, int price, int newAmount)
//    {
//        ProductId = productId;
//        this.name = name;
//        this.category = category;
//        this.price = price;
//    }
//}
namespace DO;

public record Prodact(int ProductId, string name, category category, double price, int amount)
{
    // בנאי ריק (ברירת מחדל)
    public Prodact() : this(0, "null", category.גלידות, 0, 0) { }
}