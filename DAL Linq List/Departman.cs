using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Departman
    {
        static int maxId = 0;
        public Departman()
        {
            Id = maxId;
            maxId++;
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Mudur { get; set; }
        public int OdaNumarası { get; set; }
        public List<Personel> Personeller { get; set; }

    }
}
