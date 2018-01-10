using POP_SF49_16GUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16GUI.model
{
    class RadSaPodacima
    {
        public static RadSaPodacima Instance { get; private set; } = new RadSaPodacima();


        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set;}
        public string ConnectionStr = @"Server=localhost;Initial Catalog=SalonNamestaja;Trusted_Connection=True;";
        private RadSaPodacima()
        {
            TipoviNamestaja = GenericSerialize.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaj = GenericSerialize.Deserialize<Namestaj>("listaNam.xml");
            Korisnici = new ObservableCollection<Korisnik>();
            Akcije = GenericSerialize.Deserialize<Akcija>("Akcije.xml");
            DodatneUsluge = GenericSerialize.Deserialize<DodatnaUsluga>("DodatneUsluge.xml");
        }

    }
}