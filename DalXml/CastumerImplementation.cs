using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;

namespace Dal
{
    internal class CastumerImplementation : ICastumer
    {
        private XElement root = XElement.Load("customers");
        private string CUSTOMER = "customer";
        private string ID = "CustomerId";
        private string NAME = "CustomerName";
        private string ADDRESS = "Adress";
        private string PHONE = "Phone";
        public int Create(Castumer item)
        {
            if (root.Descendants("Customer").Any(c => (int)c.Element("CustomerId") == item.CastumerId))
            {
                throw new objectAlreadyExsist(item.CastumerId);
            }
            root.Add(new XElement("Customer",
                               new XElement("CustomerId", item.CastumerId),
                               new XElement("CustomerName", item.name),
                               new XElement("Address", item.street),
                               new XElement("Phone", item.numCall)));
            root.Save("customers");

            return item.CastumerId;
        }

        public void Delete(int id)
        {
            if (root.Descendants("Customer").Any(c => (int)c.Element("CustomerId") == id))
            {
                throw new objectNotFound(id);
            }
            root.Descendants("Customer").FirstOrDefault(c => (int)c.Element("CustomerId") == id).Remove();
            root.Save("customers");
        }
        public Castumer? Read(int id)
        {
            if (root.Descendants(ID).FirstOrDefault(i => int.Parse(i.Value) == id) == null)
                throw new objectNotFound(id);
            var customerElement = root.Descendants(CUSTOMER)
                    .FirstOrDefault(c => (int?)c.Element("ID") == id);
            return new Castumer
            {
                name = (string)customerElement.Element(NAME),
                CastumerId = (int)customerElement.Element(ID),
                street = (string)customerElement.Element(ADDRESS),
                numCall = (int)customerElement.Element(PHONE)
            };
        }
        public Castumer? Read(Func<Castumer, bool>? filter)
        {
            return root.Elements(CUSTOMER)
                .Select(c => new Castumer
                {
                    name = (string?)c.Element(NAME),
                    CastumerId = (int)c.Element(ID),
                    street = (string?)c.Element(ADDRESS),
                    numCall = (int)c.Element(PHONE)
                })
                .FirstOrDefault(filter); // כאן מתבצע הסינון וההחזרה
        }
        public List<Castumer?> ReadAll(Func<Castumer, bool>? filter = null)
        {
            List<Castumer> customers = root.Elements(CUSTOMER).Select(c => new Castumer
            {
                name = (string)c.Element(NAME),
                CastumerId = (int)c.Element(ID),
                street = (string)c.Element(ADDRESS),
                numCall = (int)c.Element(PHONE)
            }).ToList();
            return customers;
        }


















        public void Update(Castumer item)
        {
            Delete(item.CastumerId);
            root.Add(new XElement(CUSTOMER, new XElement("CustomerId", item.CastumerId),
                                 new XElement("CustomerName", item.name),
                                 new XElement("Address", item.street),
                                 new XElement("Phone", item.numCall)));
            root.Save("customers");
        }
    }
}
