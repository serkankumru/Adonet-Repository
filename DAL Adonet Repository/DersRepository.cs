using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
   public class DersRepository
    {
        public List<Ders> List()
        {
            List<Ders> result = new List<Ders>();

            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";
            string query = @" select * from Ders s";

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
                Ders drs = new Ders();
                drs.Id = Convert.ToInt32(dr["Id"]);
                drs.Name = dr["Name"].ToString();
                drs.Kredi = Convert.ToInt32(dr["Kredi"]);

                result.Add(drs);

            }

            return result;

        }

        public void AddDers(Ders drs)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";
            DateTime createDate = DateTime.Now;
            string queryNew = String.Format("insert into Ders values('{0}','{1}')",drs.Name,drs.Kredi);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
            

        }

        public void UpdateDers(Ders drs)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";

            string queryNew = String.Format("update Ders set Name='{0}', Kredi='{1}' where ID = {2}",
            drs.Name,drs.Kredi,drs.Id);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();


        }

        public void DeleteDers(int id)
        {
            string queryNew = String.Format("delete from ders where ID='{0}'",id);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
        }

        public void AddOgrenciTODers(int dersId, int ogrId)
        {
            DateTime createDate = DateTime.Now;
            string queryNew = String.Format("insert into OgrDers values({0},{1})", ogrId, dersId);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
        }

        public void RemoveOgrenciTODers(int dersId, int ogrId)
        {
            DateTime createDate = DateTime.Now;
            string queryNew = String.Format("delete from OgrDers where OgrId = {0} and DersId = {1}", ogrId, dersId);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
        }
    }
}
