using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni1_3
{
    internal interface IDAO <T> where T : IBaseClass
    {
        //stara se o zapis a cteni
        public T GetByID(int id);
        public IEnumerable<T> GetAll();
        public void Save(T obj);
        public void Delete(T obj);
    }
}
