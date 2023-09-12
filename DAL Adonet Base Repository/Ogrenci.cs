using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int ClassId { get; set; }
        public int DersId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string DateFormat
        {
            get
            {
                if (CreateDate.HasValue)
                {
                    return CreateDate.ToString();
                }
                return "dont value";
            }
            set { }
        }
    }
}
