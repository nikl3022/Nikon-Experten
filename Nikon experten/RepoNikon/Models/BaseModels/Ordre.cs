using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoNikon.Models.BaseModels
{
    public class Ordre
    {
        public int ID { get; set; }

        public DateTime Dato { get; set; }

        public string Status { get; set; }
            
        public bool Betalt { get; set; }

        public int KundeID { get; set; }
    }
}
