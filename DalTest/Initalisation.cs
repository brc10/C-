namespace DalTest;
using DO;
using DalApi;
public static class Initalisation
{
    //private static IDal s_dal = new Dal.DalList();
    private static IDal s_dal = DalApi.Factory.Get;
    private static void CreateCastumer()
    {
        s_dal.castumer.Create(new Castumer(123456789, ",תמר", "החשמונאים", 0528964752));
        s_dal.castumer.Create(new Castumer(987456321, "נדב", "לב העיר", 0504785654));
        s_dal.castumer.Create(new Castumer(698547852, "יעל", "מנחם בגין", 0548796584));
    }
    static List<int> list = new List<int>();
    private static void CreateProduct()
    {
        list.Add(s_dal.product.Create(new Prodact(123, "אייס קפה", category.אייסים, 14, 2)));
        list.Add(s_dal.product.Create(new Prodact(456, "אייס שוקולד", category.אייסים, 14, 3)));
        list.Add(s_dal.product.Create(new Prodact(789, "אייס וניל", category.אייסים, 14, 4)));
        list.Add(s_dal.product.Create(new Prodact(147, "כדור אחד", category.גלידות, 8, 5)));
        list.Add(s_dal.product.Create(new Prodact(258, "שני כדורים", category.גלידות, 14, 6)));
        list.Add(s_dal.product.Create(new Prodact(369, "שלושה כדורים", category.גלידות, 19, 7)));
        list.Add(s_dal.product.Create(new Prodact(741, "וופל בלגי", category.וופלים, 18, 8)));
        list.Add(s_dal.product.Create(new Prodact(852, "וופל בלגי + גלידה", category.וופלים, 24, 9)));
        list.Add(s_dal.product.Create(new Prodact(963, "קרפ צרפתי", category.וופלים, 22, 10)));
        list.Add(s_dal.product.Create(new Prodact(753, "שתיה קלה", category.שתיה, 8, 11)));
        list.Add(s_dal.product.Create(new Prodact(159, "מיילק שייק", category.שתיה, 18, 12)));
        list.Add(s_dal.product.Create(new Prodact(987, "מיץ טבעי", category.שתיה, 16, 13)));
        list.Add(s_dal.product.Create(new Prodact(654, "קפה הפוך", category.שתיה, 14, 14)));
        list.Add(s_dal.product.Create(new Prodact(321, "שוקו מקופלת", category.שתיה, 12, 15)));
        list.Add(s_dal.product.Create(new Prodact(135, "אספרסו", category.שתיה, 8, 16)));
        list.Add(s_dal.product.Create(new Prodact(759, "פקאן", category.תוספות, 3, 17)));
        list.Add(s_dal.product.Create(new Prodact(468, "שוקולד חם", category.תוספות, 4, 18)));
        list.Add(s_dal.product.Create(new Prodact(198, "סוכריות", category.תוספות, 2, 19)));
        list.Add(s_dal.product.Create(new Prodact(723, "ריבת חלב", category.תוספות, 4, 20)));
    }
    private static void CreateSail()
    {
        s_dal.sail.Create(new Sale(1234, 123, 100, 10, true, DateTime.Now, DateTime.MaxValue));
        s_dal.sail.Create(new Sale(5698, 159, 150, 12, true, DateTime.Now, DateTime.MaxValue));
        s_dal.sail.Create(new Sale(4563, 321, 80, 8, true, DateTime.Now, DateTime.MaxValue));
        s_dal.sail.Create(new Sale(8524, 852, 200, 20, true, DateTime.Now, DateTime.MaxValue));
    }
    public static void Initialize()
    {
        s_dal = DalApi.Factory.Get;
        CreateCastumer();
        CreateProduct();
        CreateSail();
    }       
}
