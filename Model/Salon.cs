using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16.Model
{
    class Salon
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public string WebStranica { get; set; }

        public int PIB { get; set; }

        public string ZiroRacun { get; set; }
    }
}
