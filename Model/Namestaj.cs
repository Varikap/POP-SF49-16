﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public double Cena { get; set; }

        public int Kolicina { get; set; }

        public TipNamestaja Tip_Namestaja { get; set; }
    }
}
