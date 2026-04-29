using DO;
using DalApi;
using static Dal.DataSource;
using Microsoft.VisualBasic;

namespace Dal;

public class ProdactImlemention:Iproduct
{//לשנות שיהיה כמו הלקוחות עם הלוג
    //מממש את כל הICRUD
    public int Create(Prodact item)
    {
        if (prodacts.Any(p => p.ProductId== item.ProductId))
            throw new DO.objectAlreadyExsist(item.ProductId);
        item =item with { ProductId = Config.GetProductId };
        prodacts.Add(item);
       
        return item.ProductId;
    }
    public Prodact? Read(int id)
    {
        Prodact p = prodacts.FirstOrDefault(p => p.ProductId == id);
        if ( p==null)
            throw new DO.objectNotFound(id);
        return p;
    }
    public List<Prodact> ReadAll(Func<Prodact,bool>filter)
    {
        if (filter == null)
        {
            // אם לא שלחו פילטר - מחזירים את כל הרשימה כעותק
            return prodacts.Select(p => p).ToList();
        }

        // אם שלחו פילטר - משתמשים ב-Where כדי לסנן לפי התנאי
        return prodacts.Where(filter).ToList();
    }
    public void Update(Prodact item)
    {
        Prodact? existing = prodacts.FirstOrDefault(p => p.ProductId == item.ProductId);

        if (existing == null)
            throw new DO.objectNotFound(item.ProductId);

        prodacts.Remove(existing); // הסרת הישן
        prodacts.Add(item);
    }
    public void Delete(int id)
    {
        var item = prodacts.FirstOrDefault(p => p.ProductId == id);
        if (item == null)
            throw new DO.objectNotFound(id);

        prodacts.Remove(item);
    }
    public Prodact? Read(Func<Prodact, bool> filter)
    {
        return prodacts.FirstOrDefault(filter);
    }
}