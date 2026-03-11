//namespace DO;
//public record Sail(int SailId,int idProduct,int count,int PriceSail,bool CastumerSail,DateTime startDate,DateTime FinishDate)
//{
//    public Sail() : this(0, 0, 5, 8, true, DateTime.Now, DateTime.MaxValue) { }
//}

namespace DO;

public record Sale(
    int SailId,          // מזהה המבצע
    int productId,       // מזהה המוצר (שינינו מ-idProduct)
    int RequiredAmount,  // כמות נדרשת (שינינו מ-count)
    double salePrice,    // מחיר המבצע (שינינו מ-PriceSail)
    bool onlyClub,       // האם רק למועדון (שינינו מ-CastumerSail)
    DateTime beginSale,  // תאריך התחלה (שינינו מ-startDate)
    DateTime? endSale    // תאריך סיום (שינינו מ-FinishDate)
)
{
    // בנאי ריק (דיפולטיבי) לשימוש כללי
    public Sale() : this(0, 0, 0, 0, false, DateTime.Now, null) { }
}