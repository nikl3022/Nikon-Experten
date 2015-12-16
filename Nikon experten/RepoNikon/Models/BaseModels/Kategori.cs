using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoNikon;

namespace RepoNikon.Models.BaseModels
{
    public class Kategori
    {
        public int ID { get; set; }

        public string Navn { get; set; }

        public int Sortering { get; set; }
    }
}
