using BL.BlApi;
using BL.BO;
using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public interface IBl
    {
        public Iproduct Prodact { get; }
        public ICastumer Customer { get; }
        public ISale Sale { get; }
        public IOrder Order { get; }


    }
}

