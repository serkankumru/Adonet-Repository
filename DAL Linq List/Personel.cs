using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Personel
    {
        static int maxId = 0;
        public Personel()
        {
            Id = maxId;
            maxId++;
        }
        public int Id { get; set; }
        public string Isim { get; set; }
        public Double Maas { get; set; }
        public int Yas { get; set; }
        public bool Cinsiyet { get; set; }
        public string _Cinsiyet { 
            get 
            {
                if(Cinsiyet) { return "Erkek"; }
                else { return "Kadın"; }
            }
            set { }
        }
        public Departman Departmani { get; set; }
        public string _Departman {
            get {
                return Departmani.Ad;
            
            }
            set { }
        }

    }
}
