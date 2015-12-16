using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNikon;

namespace RepoNikon.Models.BaseModels
{
    public class Kontakt
    {
        public int ID { get; set; }

        public string Navn { get; set; }

        public string Adresse { get; set; }

        public string ByNavn { get; set; }

        public string Tider { get; set; }

        public string Tlf { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Billede { get; set; }

        public string PostNr { get; set; }
    }
}
