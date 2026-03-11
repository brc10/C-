
﻿using DO;
using DalApi;
using static Dal.DataSource;
using Tools;
using System.Xml;
using System.Reflection;
using System.Linq;

namespace Dal;
public class CastumerImplemantion : ICastumer
{
    // יצירת לקוח חדש
    public int Create(Castumer item)
    {
        LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName,MethodBase.GetCurrentMethod().Name, "Create Customer");
        if (castumers.Any(c => c.CastumerId == item.CastumerId))
            throw new objectAlreadyExsist(item.CastumerId);
        castumers.Add(item);
        LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Customer");
        return item.CastumerId;

    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //שינוי
    public Castumer? Read(int id)
    {
        return castumers.FirstOrDefault(c => c.CastumerId == id);

    }

    // קריאת נתוני לקוח לפי תנאי כלשהוא
    public Castumer? Read(Func<Castumer, bool> filter)
    {
        LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Read Customer");
        LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Read Customer");


        return castumers.FirstOrDefault(filter);
    }
   

    // החזרת רשימת הלקוחות - עם אפשרות לסינון
    public List<Castumer> ReadAll(Func<Castumer, bool>? filter = null)
    {
        LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "ReadAll Customer");

        // אם לא נשלח פילטר, נחזיר את כל הרשימה כפי שהיה קודם
        if (filter == null)
        {
            return new List<Castumer>(castumers);
        }

        // שימוש ב-LINQ (Query Syntax) כדי לסנן את הרשימה לפי הפילטר
        var result = from item in castumers
                     where filter(item)
                     select item;
        LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish ReadAll Customer");

        // LINQ מחזיר משהו שנקרא IEnumerable, לכן חייבים להפוך אותו ל-List בסוף
        return result.ToList();
    }
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    // עדכון נתוני לקוח קיים
    public void Update(Castumer item)
    {
        LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Update Customer");

        Castumer? existing = castumers.FirstOrDefault(c => c.CastumerId == item.CastumerId);
        if (existing == null)
            throw new objectNotFound(item.CastumerId);

        castumers.Remove(existing);
        castumers.Add(item);
        LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Update Customer");

    }

    // מחיקת לקוח 
    public void Delete(int barcode)
    {
        LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");

        Castumer? existing = castumers.FirstOrDefault(c => c.CastumerId == barcode);
        if (existing == null)
            throw new objectNotFound(barcode);

        castumers.Remove(existing);
        LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Delete Customer");
    }
}