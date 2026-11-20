using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    internal class Knjiga
    {
        private string naziv, autor, isbn;
        private DateTime datumIzdavanja;
        private double cijena;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Naziv ne smije biti prazan");
                naziv = value;
            }
        }
        public string Autor
        {
            get { return autor; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Autor ne smije biti prazan");
                autor = value;
            }
        }
        public string Isbn
        {
            get { return isbn; }
            set
            {
                isbn = value;
            }
        }

        public DateTime DatumIzdavanja
        {
            get
            {
                return datumIzdavanja;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Datum ne smije biti u budućnosti");
                datumIzdavanja = value;
            }
        }

        public double Cijena
        {
            get 
            {
                return cijena;
            }
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Cijena mora biti veća od 0");
                cijena = value; 
            }
        }
    }
}
