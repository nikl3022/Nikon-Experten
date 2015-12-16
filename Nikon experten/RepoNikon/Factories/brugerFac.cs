using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using RepoNikon.Models.BaseModels;



namespace RepoNikon.Factories
{
     public class brugerFac : AutoFac<Bruger>
    {

         public Bruger Login(string email, string password)
         {
             using (var CMD = new SqlCommand("SELECT * FROM bruger WHERE Email=@Email AND Adgangskode=Adgangskode", Conn.CreateConnection()))
             {
                 CMD.Parameters.AddWithValue("@Email", email);
                 CMD.Parameters.AddWithValue("@Kodeord", password);

                 Mapper<Bruger> mapper = new Mapper<Bruger>();

                 var r = CMD.ExecuteReader();
                 Bruger per = new Bruger();

                 if (r.Read())
                 {
                     per = mapper.Map(r);
                 }
                 r.Close();
                 CMD.Connection.Close();
                 return per;
             }
         }
         public bool UserExists(string email)
         {
             using (var cmd = new SqlCommand("SELECT ID FROM Bruger WHERE Email=@Email", Conn.CreateConnection()))
             {
                 cmd.Parameters.AddWithValue("@Email", email);

                 var r = cmd.ExecuteReader();

                 if (r.Read())
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
         }
    }
}
