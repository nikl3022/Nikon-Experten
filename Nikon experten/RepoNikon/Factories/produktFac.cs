using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNikon;
using System.Data.SqlClient;
using RepoNikon.Models.ViewModels;
using RepoNikon.Models.BaseModels;
using RepoNikon.Factories;

namespace RepoNikon.Factories
{
    public class produktFac: AutoFac<produkt>
    {
        KategoriFac katFac = new KategoriFac();

        public ProduktListe GetProduktListe(int katID)
        {
            ProduktListe pl = new ProduktListe();

            pl.kategori = katFac.Get(katID);
            pl.Produkt = GetBy("katID", katID);
            return pl;
        }


        Mapper<produkt> mapper = new Mapper<produkt>();

        public List<produkt> Search(string KeyWord)
        {
            using (var cmd = new SqlCommand("SELECT * FROM produkt WHERE Navn Like @Key OR Tekst Like @Key", Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@Key", "%" + KeyWord + "%");
                return mapper.MapList(cmd.ExecuteReader());
            }
        }
        public List<produkt> AdvSearch(string producent, string Maxpris, string Keyword)
        {
            string SQL = "SELECT * FROM Produkt WHERE Tekst LIKE @Keyword";
            decimal max = 0;

            if (Maxpris != "");
            {
                max = decimal.Parse(Maxpris);
                SQL += " AND pris  <= @pris";
            }
            if (producent != "0")
            {
                SQL += " AND KatID=@producent";
            }
            using (var cmd = new SqlCommand(SQL, Conn.CreateConnection()))
            {
                cmd.Parameters.AddWithValue("@pris", max);
                cmd.Parameters.AddWithValue("@Keyword", "%" + Keyword + "%");
                cmd.Parameters.AddWithValue("@producent", int.Parse(producent));

                var mapper = new Mapper<produkt>();
                List<produkt> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
