using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni1_3
{
    internal class NapojProxy : IDAO<Napoj>
    {
        private NapojDAO napojDao = new NapojDAO();
        private List<Napoj> napojList = null;
        private Dictionary<int, Napoj> dictionary = new Dictionary<int, Napoj>();
        public void Delete(Napoj obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Napoj> GetAll()
        {
            throw new NotImplementedException();
        }

        public Napoj GetByID(int id)
        {
           Napoj napoj = null;
            if(dictionary.ContainsKey(id))
            {
                napoj = dictionary[id];
            }
            else
            {
                napoj = napojDao.GetByID(id);
                if(napoj != null)
                {
                    dictionary[id] = napoj;
                }
                
            }
            return napoj;
        }

        public void Save(Napoj obj)
        {
            napojDao.Save(obj);
            napojList = null;
            dictionary = new Dictionary<int, Napoj>();
        }
    }
}
