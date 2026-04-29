using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dal
{
    internal static class Config
    {
        private static string nameConfigFile = "data-config";
        private static int staticSaleId;
        public static int GetSaleId
        {
            get
            {

                XElement root = XElement.Load(nameConfigFile);
                int currentId = int.Parse(root.Element("SaleId").Value);

                root.Element("SaleId").SetValue((currentId + 1).ToString());

                root.Save(nameConfigFile);
                return currentId;
            }
        }
        private static int staticProductId;
        public static int GetProductId
        {
            get
            {
                XElement root = XElement.Load(nameConfigFile);
                int currentProductId = int.Parse(root.Element("ProductId").Value);
                root.Element("ProductId").SetValue((currentProductId + 1).ToString());
                return currentProductId;
            }
        }
    }
}
