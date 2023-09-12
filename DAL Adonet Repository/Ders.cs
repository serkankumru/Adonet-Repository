using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
    public class Ders
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Kredi { get; set; }

        public List<Ogrenci> AlanOgrenciler
        {
            get;set;
        }

    }
}
