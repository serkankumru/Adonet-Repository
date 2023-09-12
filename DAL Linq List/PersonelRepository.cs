using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonelRepository
    {
        static List<Personel> Personeller = new List<Personel>();

        public void Add(Personel personel)
        {
            Personeller.Add(personel);
        }
        public void Remove(int id) 
        {
            Personel personel = new Personel();
            if (Personeller.Count(x=>x.Id==id)>0)
            {
                personel=Personeller.Where(x=>x.Id==id).First();
                Personeller.Remove(personel);
            }
        }

        public void Update(Personel personel)
        {
            Personel UpdateEdilecek = new Personel();
            UpdateEdilecek = Personeller.FirstOrDefault(c => c.Id == personel.Id);
            UpdateEdilecek.Isim = personel.Isim;
            UpdateEdilecek.Maas = personel.Maas;
            UpdateEdilecek.Yas = personel.Yas;
            UpdateEdilecek.Cinsiyet = personel.Cinsiyet;
            UpdateEdilecek.Departmani = personel.Departmani;
        }

        public List<Personel> List() 
        {
            return Personeller.ToList();
        }
    }
}
