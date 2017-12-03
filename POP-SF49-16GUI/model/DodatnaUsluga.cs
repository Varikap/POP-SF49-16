using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF49_16GUI.model
{
   public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {

        //ovako za sve ostale uradi property
        //propfull tab tab
        
        //dodaj i interfejs IClonable sa njegovom must metodom za sve zbog kloniranja objekatas

        private int id;

        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChange("Id");
            }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChange("Naziv");
            }
        }

        private double cena;

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChange("Cena");
            }
        }

        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChange("Obrisan");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        //ovu metodu i implementaciju gore odradi za sve
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new DodatnaUsluga
            {
                Id = id,
                Naziv = naziv,
                Cena = cena,
                Obrisan = obrisan
            };
        }
    }
}
