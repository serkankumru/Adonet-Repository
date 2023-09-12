using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class BaseRepository<T> where T : class
    {
        public DataTable Connect(string sql)
        {
            List<Ogrenci> list = new List<Ogrenci>();
            SqlConnection conn = new SqlConnection("Data Source=Hp;Initial Catalog=OgrenciTakip2; Integrated Security=true");
            SqlCommand sqlCmd = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            da.SelectCommand = sqlCmd;
            da.Fill(dt);

            da.Dispose();
            sqlCmd.Dispose();

            conn.Close();

            return dt;
        }
        public abstract void Add(T d);
        public abstract bool Remove(T d);
        public abstract void Update(T d);
        public abstract List<T> List();
    }
}
