using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak2
{
    public partial class Glavna : Form
    {
        List<Knjiga> knjige = new List<Knjiga>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string naziv = txtNaziv.Text;
            string autor = txtAutor.Text;
            string isbn = txtISBN.Text;
            string unos = txtDatumIzdavanja.Text;
            bool ok = DateTime.TryParse(unos, out DateTime datum);
            if(!ok)
            {
                MessageBox.Show("Neispravan format datuma");
                return;
            }
            unos = txtCijena.Text;
            ok = double.TryParse(unos, out double cijena);
            if (!ok)
            {
                MessageBox.Show("Neispravan format cijene");
                return;
            }
            Knjiga knjiga = new Knjiga();
            try
            {
                knjiga.Naziv = naziv;
                knjiga.Autor = autor;
                knjiga.Isbn = isbn;
                knjiga.DatumIzdavanja = datum;
                knjiga.Cijena = cijena;
                knjige.Add(knjiga);
                AzurirajGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška. Tekst pogreške: {ex.Message}");
            }
            
        }

        void AzurirajGrid()
        {
            dgvKnjige.DataSource = null;
            dgvKnjige.DataSource = knjige;
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            string[] redci = File.ReadAllLines("knjige.txt");
            foreach (var redak in redci)
            {
                string[] stupci = redak.Split(';');
                Knjiga knjiga = new Knjiga();
                knjiga.Naziv = stupci[0];
                knjiga.Autor = stupci[1];
                knjiga.Isbn = stupci[2];
                string unos = stupci[3];
                bool ok = DateTime.TryParse(unos, out DateTime datum);
                if (ok)
                    knjiga.DatumIzdavanja = datum;
                unos = stupci[4];
                ok = double.TryParse(unos, out double cijena);
                if(ok)
                    knjiga.Cijena = cijena;
                knjige.Add(knjiga);
            }
            AzurirajGrid();
        }

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            StreamWriter datoteka = new StreamWriter("knjige.txt");
            foreach (var knjiga in knjige)
            {
                datoteka.WriteLine($"{knjiga.Naziv};{knjiga.Autor};{knjiga.Isbn};{knjiga.DatumIzdavanja};{knjiga.Cijena}");
            }
            datoteka.Close();
        }


    
  }
}
