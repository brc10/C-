using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;

namespace BO
{
    internal interface IProdact
    {
        int Create(Prodact item);
        T? Read(int id);
        T? Read(Func<Prodact, bool> filter);
        IEnumerable<Prodact?> ReadAll(Func<Prodact, bool>? filter = null);
        void Update(Prodact item);
        void Delete(int id);
        //פונקציה שבודקת מוצר במבצע ולקוח מועדף
        void Chek(ProductInOrder p, bool isSpecial);
    }
}
