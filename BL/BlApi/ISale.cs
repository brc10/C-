using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DO;
using System.Threading.Tasks;

namespace BL.BlApi
{
    public interface ISale
    {
        int Create(BO.Sale item);
        BO.Sale? Read(int id);
        BO.Sale? Read(Func<BO.Sale, bool> filter);
        IEnumerable<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null);
        void Update(BO.Sale item);
        void Delete(int id);
    }
}

