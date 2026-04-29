using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal
{
    internal sealed class DalXml : IDal
    {
        private DalXml() { }
        private static readonly DalXml instance=new DalXml();

        public static DalXml Instance
        {
            get { return instance; }
        }

        public ICastumer castumer =>  new CastumerImplementation();

        public Iproduct product =>  new ProdactImplementation();

        public Isale sail => new SaleImplementation();
    }
}
