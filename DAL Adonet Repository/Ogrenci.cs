using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
    public class Ogrenci
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public int ClsId { get; set; }

        public string ClassName { get; set; }

        public DateTime? CreateDate { get; set; }

        public String FormatedDate {
            get
            {
                if (CreateDate.HasValue)
                {
                    return CreateDate.Value.ToString("dd/MM/yyy");
                }
                else
                    return "No date time Found";
            }
        }
    }
}
