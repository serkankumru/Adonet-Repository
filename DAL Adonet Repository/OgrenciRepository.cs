using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
   public class OgrenciRepository
    {
        public List<Ogrenci> List()
        {
            List<Ogrenci> result = new List<Ogrenci>();

            string connString = @"Data Source = PC-466; Initial Catalog = OgrenciTakip2; Integrated Security = true";
            string query = @" select s.*,c.Name 'ClassName' from Student s
                            left join ClassRoom c on s.ClsId = c.Id";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();


            foreach(DataRow dr in dt.Rows)
            {
                Ogrenci ogr = new Ogrenci();
                ogr.Id = Convert.ToInt32(dr["Id"]);
                ogr.Name = dr["Name"].ToString();
                ogr.Surname = dr["Surname"].ToString();
                ogr.Age = Convert.ToInt32(dr["Age"]);
                ogr.ClsId = Convert.ToInt32(dr["ClsId"]);
                ogr.ClassName = dr["ClassName"].ToString();

                if (dr["CreateDate"]!=DBNull.Value)
                ogr.CreateDate = Convert.ToDateTime(dr["CreateDate"]);

                result.Add(ogr);

            }

            return result;

        }//

        public List<Ogrenci> ListALmayan(int drsId)
        {
            List<Ogrenci> result = new List<Ogrenci>();
            
            string connString = @"Data Source = PC-466; Initial Catalog = OgrenciTakip2; Integrated Security = true";

            string query = String.Format(@"select * from Student s
                                           where s.Id not in (select ogrId from OgrDers od where od.DersId={0})", drsId);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();


            foreach (DataRow dr in dt.Rows)
            {
                Ogrenci ogr = new Ogrenci();
                ogr.Id = Convert.ToInt32(dr["Id"]);
                ogr.Name = dr["Name"].ToString();
                ogr.Surname = dr["Surname"].ToString();
                ogr.Age = Convert.ToInt32(dr["Age"]);


                if (dr["CreateDate"] != DBNull.Value)
                    ogr.CreateDate = Convert.ToDateTime(dr["CreateDate"]);

                result.Add(ogr);

            }

            return result;

        }

        public List<Ogrenci> ListByDersId(int drsId)
        {
            List<Ogrenci> result = new List<Ogrenci>();

            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";
            string query = String.Format(@" select s.* from Student s
                                join OgrDers  od on od.OgrID=s.Id
                                join Ders d on d.Id=od.DersId
                                where d.Id={0} ", drsId);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();


            foreach (DataRow dr in dt.Rows)
            {
                Ogrenci ogr = new Ogrenci();
                ogr.Id = Convert.ToInt32(dr["Id"]);
                ogr.Name = dr["Name"].ToString();
                ogr.Surname = dr["Surname"].ToString();
                ogr.Age = Convert.ToInt32(dr["Age"]);
               

                if (dr["CreateDate"] != DBNull.Value)
                    ogr.CreateDate = Convert.ToDateTime(dr["CreateDate"]);

                result.Add(ogr);

            }

            return result;

        }

        public List<Ders> AlınanDersler(int sinifId)
        {
            List<Ders> result = new List<Ders>();

            string connString = @"Data Source = PC-466; Initial Catalog = OgrenciTakip2; Integrated Security = true";

            string query = String.Format(@"select * from Ders d
                                            where d.Id not in (select DersId from OgrDers od where od.OgrId={0})", sinifId);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            foreach (DataRow dr in dt.Rows)
            {
                Ders drs = new Ders();
                drs.Id = Convert.ToInt32(dr["Id"]);
                drs.Name = dr["Name"].ToString();
                drs.Kredi = Convert.ToInt32(dr["Kredi"]);

                result.Add(drs);

            }

            return result;

        }
        public List<Ders> AlınanmayanDersler(int sinifId)
        {
            List<Ders> result = new List<Ders>();

            string connString = @"Data Source = PC-466; Initial Catalog = OgrenciTakip2; Integrated Security = true";

            string query = String.Format(@"select * from Ders d
                                            where d.Id in (select DersId from OgrDers od where od.OgrId={0})", sinifId);

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            conn.Close();
            da.Dispose();

            foreach (DataRow dr in dt.Rows)
            {
                Ders drs = new Ders();
                drs.Id = Convert.ToInt32(dr["Id"]);
                drs.Name = dr["Name"].ToString();
                drs.Kredi = Convert.ToInt32(dr["Kredi"]);

                result.Add(drs);

            }

            return result;

        }

        public void AddOgrenci(Ogrenci ogr)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";
            DateTime createDate = DateTime.Now;
            string queryNew = String.Format("insert into student values('{0}','{1}','{2}','{3}','{4}','{5}')", 
            ogr.Name, ogr.Surname, ogr.Age, ogr.ClsId,ogr.ClassName,createDate);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
            

        }

        public void UpdateOgrenci(Ogrenci ogr)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";

            string queryNew = String.Format("update Student set Name='{0}', Surname='{1}', Age={2},ClsId={3} where ID = {4}",
            ogr.Name, ogr.Surname, ogr.Age, ogr.ClsId,ogr.Id);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();


        }

        public void DeleteOgrenci(int id)
        {
            string queryNew = String.Format("delete from student where ID='{0}'",id);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
        }
    }
}
