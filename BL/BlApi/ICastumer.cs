using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    internal interface ICastumer
    {
        int Create(Castumer item);
        T? Read(int id);
        T? Read(Func<Castumer, bool> filter);
        IEnumerable<Castumer?> ReadAll(Func<Castumer, bool>? filter = null);
        void Update(Castumer item);
        void Delete(int id);
        public bool IsCustomerExist();
    }
}

