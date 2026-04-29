using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DO;

namespace Dal
{
    internal class SaleImplementation:Isale
    {
        public int Create(Sale item)
        {
            throw new objectNotFound(147);
        }
        public void Delete(int id)
        {
        }
        public Sale? Read(int id)
        {
            throw new objectNotFound(147);
        }
        public Sale? Read(Func<Sale, bool>? filter)
        {
            throw new objectNotFound(147);
        }

        public List<Sale?> ReadAll(Func<Sale, bool>? filter = null)
        {
            throw new objectNotFound(147);
        }
        public void Update(Sale item)
        {

        }
    }
}
