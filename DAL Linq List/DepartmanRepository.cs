using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmanRepository
    {
        static List<Departman> Departmanlar = new List<Departman>();

        public void Add(Departman departman)
        {
            Departmanlar.Add(departman);
        }
        public void Delete(int id)
        {
            Departman departmanSilinecek = new Departman();
            if(Departmanlar.Count(x=> x.Id==id) > 0)
            {
                departmanSilinecek = Departmanlar.Where(item => item.Id == id).First();
                Departmanlar.Remove(departmanSilinecek);
            }
            
        }
        public List<Departman> List()
        {
            return Departmanlar.ToList();
        }
        public List<Personel> ListPersonel(String departmanAd)
        {
            PersonelRepository repo = new PersonelRepository();
            List<Personel> personelList = repo.List();

            personelList = personelList.Where(x => x.Departmani.Ad == departmanAd).ToList();
            return personelList;
        }
        public void Update(Departman departman)
        {
            Departman UpdateEdilecek = new Departman();
            UpdateEdilecek.Ad = Departmanlar.FirstOrDefault(x => x.Id == departman.Id).Ad;
            UpdateEdilecek.OdaNumarası = departman.OdaNumarası;
            UpdateEdilecek.Mudur = departman.Mudur;
            UpdateEdilecek.Ad= departman.Ad;
        }
        public Departman Get(int id)
        {
            Departman departman = new Departman();
            departman = Departmanlar.FirstOrDefault(x=>x.Id == id);
            return departman;
        }
    }
}
