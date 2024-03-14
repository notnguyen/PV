using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_DS_Project
{
    internal interface IRepozitory<T>
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Delete(T element);
    }
}
