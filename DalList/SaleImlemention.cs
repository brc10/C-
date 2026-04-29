using DO;
using static Dal.DataSource;
using DalApi;
namespace Dal;
public class SaleImlemention:Isale
{//לשנות שיהיה כמו הלקוחות עם הלוג
    //private List<Sail> sail = new List<Sail>();
    //מממש את כל הICRUD
    public int Create(Sale item)
    {
        if (sails.Any(s => s.SailId == item.SailId))
            throw new DO.objectAlreadyExsist(item.SailId);
        item = item with { SailId = Config.GetSailId };
        sails.Add(item);
        return item.SailId;

    }
    public Sale? Read(int id)
    {
        return sails.FirstOrDefault(s => s.SailId == id);
    }
    public List<Sale> ReadAll(Func<Sale, bool>filter)
    {
        if (filter == null)
        {
            // אם לא שלחו פילטר - מחזירים את כל הרשימה כעותק
            return sails.Select(s => s).ToList();
        }

        // אם שלחו פילטר - משתמשים ב-Where כדי לסנן לפי התנאי
        return  sails.Where(filter).ToList();
    }
    public void Update(Sale item)
    {
        Sale? existing = sails.FirstOrDefault(s => s.SailId == item.SailId);

        if (existing == null)
            throw new DO.objectNotFound(item.SailId);

        sails.Remove(existing); // הסרת הישן
        sails.Add(item);
    }
    public void Delete(int id)
    {
        var item = sails.FirstOrDefault(s => s.SailId == id);
        if (item == null)
            throw new DO.objectNotFound(id);

        sails.Remove(item);
    }
    public Sale? Read(Func<Sale, bool> filter)
    {
        return sails.FirstOrDefault(filter);
    }
}
