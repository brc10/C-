using System.Data.Common;
using DalApi;
using DO;
using Dal;

namespace DalTest
{
    internal class Program
    {
        //private static IDal s_dal = new Dal.DalList();
        private static IDal s_dal = DalApi.Factory.Get;
        private static void ProductMenue()
        {
            int choice = PrintSubMenue("Product");
            switch (choice)
            {
                case 0:// חזרה לתפריט ראשי
                    return;
                case 1:// הוספת מוצר
                    AddProdact();
                    break;
                case 2:// הצגת מוצר
                    Read(s_dal.product);
                    break;
                case 3:
                    ReadAll(s_dal.product);
                    break;
                case 4:// עדכון מוצר
                    UpdateProdact();
                    break;
                case 5:// מחיקת מוצר
                    Delete(s_dal.product);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
        private static void SaleMenue()
        {
            int choice = PrintSubMenue("Sale");
            switch (choice)
            {
                case 0: // חזרה לתפריט הראשי
                    return;

                case 1: // הוספת מבצע
                    AddSail();
                    break;

                case 2: // הצגת מבצע בודד (גנרי)
                    Read(s_dal.sail);
                    break;

                case 3: // הצגת כל המבצעים (גנרי)
                    ReadAll(s_dal.sail);
                    break;

                case 4: // עדכון מבצע
                    UpdateSail();
                    break;

                case 5: // מחיקת מבצע (גנרי)
                    Delete(s_dal.sail);
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
        private static void ClientMenue()
        {
            int choice = PrintSubMenue("Client");

            switch (choice)
            {
                case 0: // חזרה לתפריט הראשי
                    return;

                case 1: // הוספת לקוח
                    AddClient();
                    break;

                case 2: // הצגת לקוח בודד (גנרי)
                    Read(s_dal.castumer);
                    break;

                case 3: // הצגת כל הלקוחות (גנרי)
                    ReadAll(s_dal.castumer);
                    break;

                case 4: // עדכון לקוח
                    UpdateClient();
                    break;

                case 5: // מחיקת לקוח (גנרי)
                    Delete(s_dal.castumer);
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
        private static Prodact AskProdact(int code = 0)
        {
            string name;
            category cat;
            int price;
            int amount;

            Console.WriteLine("Enter the Name of the product:");
            name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter the category: (0-IceCream, 1-Waffles, 2-Drink, 3-Toppings)");
            int catInput;
            if (!int.TryParse(Console.ReadLine(), out catInput)) cat = 0;
            else cat = (category)catInput;

            Console.WriteLine("Enter Price:");
            if (!int.TryParse(Console.ReadLine(), out price)) price = 10;

            Console.WriteLine("How much is in stock?");
            if (!int.TryParse(Console.ReadLine(), out amount)) amount = 0;

            // קביעת ה-ID: חדש מהקונפיג או הקיים ששלחנו
            //int finalId = (code == 0) ? DataSource.Config.GetProductId : code;//TODO

            return new Prodact(code, name, cat, price,amount);
        }

        private static Sale AskSail(int code = 0)
        {
            int prodId, count, price;
            bool isForCustomer;
            DateTime start, end;

            Console.WriteLine("Enter Product ID:");
            int.TryParse(Console.ReadLine(), out prodId);

            Console.WriteLine("Enter Count:");
            int.TryParse(Console.ReadLine(), out count);

            Console.WriteLine("Enter Sale Price:");
            int.TryParse(Console.ReadLine(), out price);

            Console.WriteLine("Is it for specific customer? (true/false):");
            bool.TryParse(Console.ReadLine(), out isForCustomer);

            Console.WriteLine("Enter Start Date (yyyy-mm-dd):");
            if (!DateTime.TryParse(Console.ReadLine(), out start)) start = DateTime.Now;

            Console.WriteLine("Enter End Date (yyyy-mm-dd):");
            if (!DateTime.TryParse(Console.ReadLine(), out end)) end = DateTime.Now.AddDays(7);

            // קביעת ה-ID (חדש מהקונפיג או קיים)
            int finalId = (code == 0) ? DataSource.Config.GetSailId : code;

            // החזרה לפי הסדר המדויק שהבנאי דורש
            return new Sale(finalId, prodId, count, price, isForCustomer, start, end);
        }
        private static Castumer AskClient(int id = 0)
        {
            string name;
            string address;
            int phone;

            // אם אנחנו בהוספה (id == 0), נבקש תעודת זהות מהמשתמש
            if (id == 0)
            {
                Console.WriteLine("Enter Customer ID:");
                int.TryParse(Console.ReadLine(), out id);
            }

            Console.WriteLine("Enter Customer Name:");
            name = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Customer Address:");
            address = Console.ReadLine() ?? "";

            Console.WriteLine("Enter Phone Number:");
            if (!int.TryParse(Console.ReadLine(), out phone)) phone = 0;

            return new Castumer(id, name, address, phone);
        }
        private static void AddProdact()
        {
            try
            {
                Prodact p = AskProdact();
                s_dal.product.Create(p);
                Console.WriteLine(" ProductId: "+p.ProductId+ " name: "+p.name+ " category: " + p.category+ " price: " + p.price+ " stok: " + p.amount);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddSail()
        {
            try
            {
                Sale s = AskSail();
                s_dal.sail.Create(s);
                Console.WriteLine("SailId: " + s.SailId+ " count: " + s.RequiredAmount + " PriceSail: " + s.salePrice + " CastumerSail: " + s.onlyClub + " startDate: " + s.beginSale + " idProduct: " + s.productId + " FinishDate: " + s.endSale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void AddClient()
        {
            try
            {
                Castumer c = AskClient();
                s_dal.castumer.Create(c);
                Console.WriteLine("CastumerId: " + c.CastumerId+ " name: " + c.name+ " numCall: " + c.numCall+ " street: " + c.street);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void UpdateProdact()
        {
            try
            {
                Console.WriteLine("enter id");
                int id = int.Parse(Console.ReadLine());
                Prodact p = AskProdact(id);
                s_dal.product.Update(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void UpdateSail()
        {
            try
            {
                Console.WriteLine("enter id");
                int id = int.Parse(Console.ReadLine());
                Sale s = AskSail(id);
                s_dal.sail.Update(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void UpdateClient()
        {
            try
            {
                Console.WriteLine("enter id");
                int id = int.Parse(Console.ReadLine());
                Castumer c = AskClient(id);
                s_dal.castumer.Update(c);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void ReadAll<T>(ICrud<T> icrud)
        {
            try
            {
                List<T> list = icrud.ReadAll();
                foreach (T item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Read<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("enter Id");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine(crud.Read(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void Delete<T>(ICrud<T> crud)
        {
            try
            {
                Console.WriteLine("enter id you want to delete");
                int id= int.Parse(Console.ReadLine());
                crud.Delete(id);
                Console.WriteLine($"Item with ID {id} was deleted successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static int PrintMainMenue()
        {
            Console.WriteLine("press 0 Exit, press 1 Customers, press 2 Products, press 3 Promotions");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        public static int PrintSubMenue(string item)
        {
            Console.WriteLine(item);
            Console.WriteLine("Press: 0 Back, 1 Add, 2 View, 3 View All, 4 Update, 5 Delete");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        //private readonly static DalApi.IDal s_dal = new Dal.DalList();
        private static void Main(string[] args)
        {
            Initalisation.Initialize();
            int selection;
            do
            {
                selection = PrintMainMenue();

                switch (selection)
                {
                    case 1: ClientMenue(); break;  // קריאה לתפריט הלקוחות
                    case 2: ProductMenue(); break; // קריאה לתפריט המוצרים
                    case 3: SaleMenue(); break;    // קריאה לתפריט המבצעים
                    case 0: break;                 // יציאה
                    default: Console.WriteLine("Choose again"); break;
                }
            } while (selection != 0);
        }
    }
}
