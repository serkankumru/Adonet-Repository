using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OgrRepository:BaseRepository<Ogrenci>
    {
        public override void Add(Ogrenci ogrenci)
        {
            string SqlCmd = string.Format("INSERT INTO Student VALUES('{0}','{1}',{2},{3},'{4}')", ogrenci.Name, ogrenci.Surname, ogrenci.Age, ogrenci.ClassId, ogrenci.CreateDate);
            Connect(SqlCmd);
        }
        public override bool Remove(Ogrenci o)
        {
            string SqlCmd = string.Format("DELETE FROM Student WHERE Id={0}", o.Id);
            Connect(SqlCmd);
            return false;
        }
        public override void Update(Ogrenci o)
        {
            string SqlCmd = string.Format("UPDATE Student SET  Name='{0}',Surname='{1}',Age={2},ClsId={3},CreateDate='{4}',DersId='{5}' WHERE Id={6}", o.Name, o.Surname, o.Age, o.ClassId, o.CreateDate,o.DersId, o.Id);
            Connect(SqlCmd);
        }
        public override List<Ogrenci> List()
        {
            List<Ogrenci> students = new List<Ogrenci>();
            DataTable dt = Connect("select s.*,c.Name as 'ClassName' from Student s left join ClassRoom c on s.ClsId = c.Id");

            foreach (DataRow d in dt.Rows)
            {
                Ogrenci s = new Ogrenci();

                s.Id = Convert.ToInt32(d["Id"].ToString());
                s.Name = d["Name"].ToString();
                s.Surname = d["Surname"].ToString();
                s.Age = Convert.ToInt32(d["Age"].ToString());
                s.ClassId = Convert.ToInt32(d["ClsId"].ToString());
                s.DersId = Convert.ToInt32(d["DersId"].ToString());
                if (d["CreateDate"] != DBNull.Value)
                    s.CreateDate = Convert.ToDateTime(d["CreateDate"].ToString());

                students.Add(s);
            }

            return students;
        }
    }
}
