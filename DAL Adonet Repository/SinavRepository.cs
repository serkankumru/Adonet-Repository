using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
    public class SinavRepository
    {
        public List<Sinav> List()
        {
            List<Sinav> result = new List<Sinav>();


            string connString = @"Data Source = PC-466; Initial Catalog = OgrenciTakip2; Integrated Security = true";
            string query = "select * from ClassRoom";

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
                Sinav s = new Sinav();
                s.Id = Convert.ToInt32(dr["Id"]);
                s.OgrId= Convert.ToInt32(dr["OgrId"]);
                s.DersId= Convert.ToInt32(dr["DersId"]);
                s.Sinav1= Convert.ToInt32(dr["Sinav1"]);
                s.Sinav2= Convert.ToInt32(dr["Sinav1"]);
                result.Add(s);
            }

            return result;
        }
        public void AddSinav(Sinav snv)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";
            DateTime createDate = DateTime.Now;
            string queryNew = String.Format("insert into Sinav values('{0}','{1}','{2}','{3}')",
            snv.OgrId, snv.DersId, snv.Sinav1, snv.Sinav2);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();


        }

        public void UpdateSinav(Sinav snv)
        {
            //string query = "insert into Student values('"+ogr.Name+"','"+ogr.Surname+"',"+ogr.Age+","+ogr.ClsId+")";

            string queryNew = String.Format("update Sinav set OgrId='{0}', DersId='{1}', Sinav1={2},Sinav2={3} where OgrId = {4} and OgrId = {5}", snv.OgrId, snv.DersId, snv.Sinav1, snv.Sinav2, snv.OgrId, snv.DersId);


            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();


        }

        public void DeleteSinav(int ogrId, int dersId)
        {
            string queryNew = String.Format("delete from Sinav where  where OgrId = {0} and OgrId = {1}", ogrId,dersId);
            string connString = @"Data Source = PC-466;Database=OgrenciTakip2;Integrated Security=true";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(queryNew, conn);
            conn.Open();

            cmd.ExecuteScalar();

            conn.Close();
        }
    }
}
