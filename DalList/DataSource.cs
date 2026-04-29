
using DO;
namespace Dal;
public static class DataSource
{
    //יוצר רשימות גנריות 
    internal static List<Castumer>? castumers = new List<Castumer>();
    internal static List<Prodact>? prodacts = new List<Prodact>();
    internal static List<Sale>? sails = new List<Sale>();

    internal static  class Config
    {
        internal const int SailId = 0;
        private static int StaticSailId = SailId;
        public static int GetSailId
        {
            get { return StaticSailId++; }
        }
        internal const int ProductId = 0;
        private static int StaticProductId = ProductId;
        public static int GetProductId
        {
            get { return StaticProductId++; }
        }

    }

}
