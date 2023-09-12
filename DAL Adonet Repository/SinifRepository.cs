using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerWithAdo
{
    public class SinifRepository
    {
        public List<Sinif> List()
        {
            List<Sinif> result = new List<Sinif>();


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
                Sinif s = new Sinif();
                s.Capacity = Convert.ToInt32(dr["Capacity"]);
                s.Id= Convert.ToInt32(dr["Id"]);
                s.Floor= Convert.ToInt32(dr["Floor"]);
                s.Name = dr["Name"].ToString();
                result.Add(s);
            }

            return result;
        }
    }
}
