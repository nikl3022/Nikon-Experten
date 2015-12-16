using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNikon;
using System.Data.SqlClient;
using RepoNikon.Models.BaseModels;

namespace RepoNikon.Factories
{
    public class KategoriFac: AutoFac<Kategori>
    {
        Mapper<Kategori> mapper = new Mapper<Kategori>();

        public List<Kategori> GetAllOrderList()
        {
            using (var cmd = new SqlCommand("SELECT * FROM Kategori ORDER BY Sortering", Conn.CreateConnection()))
            {
                return mapper.MapList(cmd.ExecuteReader());
            }
        }
    }
}
