using System.ComponentModel;
using DalApi;
using DO;
namespace Dal;

internal sealed class DalList : IDal
{
    // 4. תכונה פרטית לקריאה בלבד שיוצרת את המופע היחיד של המחלקה
    private static readonly DalList instance = new DalList();

    // 5. תכונה ציבורית סטטית לקריאה בלבד שחשופה לשאר השכבות ומחזירה את המופע
    public static DalList Instance => instance;

    // 3. בנאי פרטי - מונע יצירת מופעים חדשים מחוץ למחלקה (new DalList())
    private DalList() { }
    public ICastumer castumer => new CastumerImplemantion();
    public Iproduct product => new ProdactImlemention();
    public Isail sail => new SailImlemention();
}

