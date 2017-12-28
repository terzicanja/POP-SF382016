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
using static POP_SF38_2016GUI.UI.NamestajWindow;

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for KorisniciWindow.xaml
    /// </summary>
    public partial class KorisniciWindow : Window
    {
        private Korisnik korisnik;
        private Operacija operacija;

        public KorisniciWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbUser.DataContext = korisnik;
            tbPass.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;
            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnici;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    /*korisnik.Id = listaKorisnika.Count + 1;
                    korisnik.Ime = tbIme.Text;
                    korisnik.Prezime = tbPrezime.Text;
                    korisnik.KorisnickoIme = tbUser.Text;
                    korisnik.Lozinka = tbPass.Text;
                    korisnik.TipKorisnika = (TipKorisnika)cbTipKorisnika.SelectedItem;*/

                    Korisnik.Create(korisnik);
                    //listaKorisnika.Add(korisnik);
                    break;
                case Operacija.Izmena:
                    //Korisnik.Update(korisnik);
                    foreach (var n in listaKorisnika)
                    {
                        if(n.Id == korisnik.Id)
                        {
                            n.Ime = korisnik.Ime;
                            n.Prezime = korisnik.Prezime;
                            n.KorisnickoIme = korisnik.KorisnickoIme;
                            n.Lozinka = korisnik.Lozinka;
                            n.TipKorisnika = korisnik.TipKorisnika;

                            Korisnik.Update(n);
                            break;
                        }
                    }
                    break;
            }
            //GenericSerializer.Serialize("korisnik.xml", listaKorisnika);
            Close();
        }

        private void ZatvoriKorisniciWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
