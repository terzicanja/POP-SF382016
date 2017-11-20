using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        public enum Operacija
        {
            Dodavanje,
            Izmena
        };

        private Namestaj namestaj;
        private Operacija operacija;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;

            tbNaziv.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
        }

        

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    /*Id = listaNamestaja.Count + 1,
                    Naziv = this.tbNaziv.Text,
                    Sifra = this.tbSifra.Text,
                    Cena = Double.Parse(this.tbCena.Text),
                    KolicinaUMagacinu = int.Parse(this.tbKolicina.Text),
                    IdTipaNamestaja = izabraniTipNamestaja.Id
                    
                    listaNamestaja.Add(noviNamestaj);*/
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {

                            n.Naziv = namestaj.Naziv;
                            n.TipNamestaja = namestaj.TipNamestaja; //i ovako za sve
                            n.Sifra = this.tbSifra.Text;
                            n.Cena = Double.Parse(this.tbCena.Text);
                            n.KolicinaUMagacinu = int.Parse(this.tbKolicina.Text);
                            //n.IdTipaNamestaja = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
            Close();
        }

        private void ZatvoriNamestajWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
