using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16.Model
{
    class Akcija
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }

        public DateTime Pocetak { get; set; }
        public DateTime Zavrsetak { get; set; }
        public decimal Popust { get; set; }
    }
}