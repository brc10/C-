using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DalApi;
using DO;
using Tools;//הוספנו רפרנס לפרויקט tool בשביל הכתיבה ללוג-זה בטוח נכון?

namespace Dal
{
    internal class ProdactImplementation : Iproduct
    {
        string PATHPRODACT = "prodacts.xml";

        //טעינת הרשימה של המוצרים
        public List<Prodact> Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Prodact>));
            using (StreamReader sr = new StreamReader(PATHPRODACT))
            {
                var products = (List<Prodact>)serializer.Deserialize(sr);
                return products ?? new List<Prodact>();
            }
        }
        public void Save(List<Prodact> listProdacts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Prodact>));

            using (StreamWriter sw = new StreamWriter(PATHPRODACT))
            {
                serializer.Serialize(sw, listProdacts);
            }
        }
        public int Create(Prodact item)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Create Customer");
            List<Prodact> prodacts = Load();

            if (prodacts.Any(p => p.ProductId == item.ProductId))
                throw new DO.objectAlreadyExsist(item.ProductId);

            prodacts.Add(item);
            Save(prodacts);
            LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Product");
            return item.ProductId;
        }
        public void Delete(int id)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            List<Prodact> prodacts = Load();
            var item = prodacts.FirstOrDefault(p => p.ProductId == id);
            if (item == null)
                throw new DO.objectNotFound(id);
            prodacts.Remove(item);
            Save(prodacts);
            LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Delete Customer");
        }
        public Prodact? Read(int id)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            var prodacts = Load();
            var item = prodacts.FirstOrDefault(m => m.ProductId == id);
            if (item == null)
                throw new DO.objectNotFound(id);
            LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Product");
            return item;
        }
        public Prodact? Read(Func<Prodact, bool>? filter)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            List<Prodact> prodacts = Load();
            if (filter == null)
                prodacts.Select(p => p).ToList();

            var item = prodacts.FirstOrDefault(filter);
            if (item == null)
                throw new DO.objectNotFound(147);
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            return item;

        }

        public List<Prodact?> ReadAll(Func<Prodact, bool>? filter = null)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            List<Prodact?> prodacts = Load();
            if (filter == null)
            {
                LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Product");
                return prodacts.Select(p => p).ToList();
            }
            LogManeger.WriteEnd(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "finish Create Product");

            return prodacts.Where(filter).ToList();
        }
        public void Update(Prodact item)
        {
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");
            List<Prodact> prodacts = Load();
            Prodact p = prodacts.FirstOrDefault(prodacts => prodacts.ProductId == item.ProductId);
            if (p == null)
                throw new DO.objectNotFound(item.ProductId);
            prodacts.Remove(p);
            prodacts.Add(item);
            Save(prodacts);
            LogManeger.WriteStart(MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, "Delete Customer");

        }

    }
}
