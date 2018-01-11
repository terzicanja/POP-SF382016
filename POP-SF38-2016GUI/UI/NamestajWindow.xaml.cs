using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        ICollectionView view;

        private Namestaj namestaj;
        private Operacija operacija;
        private TipNamestaja izabraniTipNamestaja;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;
            this.izabraniTipNamestaja = new TipNamestaja();

            var listaTipova = Projekat.Instance.TipoviNamestaja;

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = TipFilter;

            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            cbTipNamestaja.ItemsSource = Projekat.Instance.TipoviNamestaja;
        }

        private bool TipFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
        }


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaji;
            var listaAkcija = Projekat.Instance.Akcije;
            izabraniTipNamestaja = (TipNamestaja)cbTipNamestaja.SelectedItem;
            if (izabraniTipNamestaja == null)
            {
                MessageBoxResult obavestenje = MessageBox.Show("Molim Vas izaberite tip namestaja.", "Obavestenje", MessageBoxButton.OK);
                return;
            }
            
            int max = listaNamestaja.Max(t => t.Id) + 1;

            if (ForceValidation() == true)
            {
                return;
            }

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //Random random = new Random();
                    //int randomNumber = random.Next(10, 99);
                    //namestaj.Id = namestaj.Id;
                    namestaj.Naziv = tbNaziv.Text;
                    namestaj.Sifra = tbNaziv.Text.Substring(0, 2) + max.ToString() + izabraniTipNamestaja.Naziv.Substring(0, 2); //+ randomNumber.ToString();
                    namestaj.Cena = Double.Parse(tbCena.Text);
                    namestaj.KolicinaUMagacinu = int.Parse(tbKolicina.Text);
                    namestaj.IdTipaNamestaja = izabraniTipNamestaja.Id;

                    Namestaj.Create(namestaj);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.TipNamestaja = namestaj.TipNamestaja;
                            n.Sifra = namestaj.Sifra;
                            n.Cena = namestaj.Cena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;

                            Namestaj.Update(n);
                            break;
                        }
                    }
                    break;
            }
            Close();
        }

        private void ZatvoriNamestajWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ForceValidation()
        {
            BindingExpression be1 = tbNaziv.GetBindingExpression(TextBox.TextProperty);
            be1.UpdateSource();
            BindingExpression be2 = tbKolicina.GetBindingExpression(TextBox.TextProperty);
            be2.UpdateSource();
            BindingExpression be3 = tbCena.GetBindingExpression(TextBox.TextProperty);
            be3.UpdateSource();

            if (Validation.GetHasError(tbNaziv) == true || Validation.GetHasError(tbKolicina) == true || Validation.GetHasError(tbCena) == true)
            {
                return true;
            }
            return false;
        }
    }
}
