using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Ders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Kredi { get; set; }
        public int Capacity { get; set; }
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
