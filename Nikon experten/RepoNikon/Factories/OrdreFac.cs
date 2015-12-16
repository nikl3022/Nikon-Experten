using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RepoNikon.Models.BaseModels;
using RepoNikon.Models.ViewModels;
using System.Data;
using RepoNikon.Factories;
using RepoNikon;
namespace RepoNikon.Factories
{
    public class OrdreFac:AutoFac<Ordre>
    {
        public void Betalt(bool betalt, int ordreID)
        {
            using (var cmd = new SqlCommand("UPDATE Ordre SET Betalt=@Betalt WHERE ID=@ID", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Betalt", betalt);
                cmd.Parameters.AddWithValue("@ID", ordreID);

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        public int AddOrdre(OrdreFac o)
        {
            int ID = 0;
            using (var cmd = new SqlCommand("INSERT INTO Ordre(Dato, Status, Betalt, KundeID) VALUES(@Dato, @Status, @Betalt, @KundeID);SELECT SCOPE_IDENTITY() AS curID", Conn.CreateConnection()))
            {
                //cmd.Parameters.AddWithValue("@Dato", o.dato);
                //cmd.Parameters.AddWithValue("@Status", o.Status);

                var r = cmd.ExecuteReader();

                if (r.Read())
                {
                    ID = int.Parse(r["curID"].ToString());
                }
                cmd.Connection.Close();
                r.Close();

                return ID;
            }
        }
    }
}
