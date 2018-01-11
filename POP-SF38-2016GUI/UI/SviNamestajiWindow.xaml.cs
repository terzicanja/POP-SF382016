using POP_SF382016.Model;
using POP_SF382016.utill;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SviNamestajiWindow.xaml
    /// </summary>
    public partial class SviNamestajiWindow : Window
    {
        public enum Radnja
        {
            Sacuvaj,
            Preuzmi
        };

        public Namestaj SelektovaniNamestaj = null;
        public StavkaProdaje SelektovanaStavka = null;
        public NaAkciji SelektovanNaAkciji = null;
        private Akcija aakcija;
        private StavkaProdaje stavka;
        private NaAkciji naAkciji;
        private Radnja radnja;
        private int max;
        public ObservableCollection<Namestaj> listaNamestaja;
        
        public SviNamestajiWindow(Radnja radnja = Radnja.Sacuvaj)
        {
            InitializeComponent();

            SelektovaniNamestaj = new Namestaj();
            this.DataContext = SelektovaniNamestaj;
            this.radnja = radnja;
            this.aakcija = new Akcija();
            this.stavka = new StavkaProdaje();
            this.naAkciji = new NaAkciji();
            this.listaNamestaja = new ObservableCollection<Namestaj>();


            var listaa = Projekat.Instance.Akcije;
            max = Projekat.Instance.Akcije.Max(t => t.Id);


            if (radnja == Radnja.Preuzmi)
            {
                PickSave.Click += PickNamestaj;
                lbKoliko.Visibility = Visibility.Collapsed;
                tbKoliko.Visibility = Visibility.Collapsed;
            }
            else
            {
                PickSave.Click += SacuvajStavku;
            }
            
            SelektovanaStavka = new StavkaProdaje();
            SelektovanNaAkciji = new NaAkciji();

            dgSviNamestaji.DataContext = this;
            dgSviNamestaji.ItemsSource = Projekat.Instance.Namestaji;
        }

        private void PickNamestaj(object sender, RoutedEventArgs e)
        {
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;

            foreach (var ak in Projekat.Instance.Akcije)
            {
                if (ak.Id == max)
                {
                    aakcija = ak;
                }
            }

            if (SelektovaniNamestaj != null)
            {
                foreach (var o in Projekat.Instance.NaAkcijama)
                {
                    if (o.IdAkcije == max)
                    {
                        if (SelektovaniNamestaj.Id == o.IdNamestaja)
                        {
                            MessageBoxResult obavestenje = MessageBox.Show("Namestaj je vec na akciji", "Obavestenje", MessageBoxButton.OK);
                            return;
                        }
                    }
                    if (o.IdNamestaja == SelektovaniNamestaj.Id && ((o.Akcija.PocetakAkcije > aakcija.PocetakAkcije && o.Akcija.PocetakAkcije < aakcija.KrajAkcije) 
                        || (o.Akcija.KrajAkcije > aakcija.PocetakAkcije && o.Akcija.KrajAkcije < aakcija.KrajAkcije) 
                        || (o.Akcija.PocetakAkcije < aakcija.PocetakAkcije && o.Akcija.KrajAkcije > aakcija.KrajAkcije)))
                    {
                        MessageBoxResult obavestenje = MessageBox.Show("Namestaj je vec na akciji u tom vremenskom periodu", "Obavestenje", MessageBoxButton.OK);
                        return;
                    }
                }
                naAkciji.IdNamestaja = SelektovaniNamestaj.Id;
                naAkciji.IdAkcije = max;

                NaAkciji.Create(naAkciji);

                SelektovanNaAkciji = naAkciji;

                this.DialogResult = true;
                this.Close();
            }
            
            /*naAkciji.IdNamestaja = SelektovaniNamestaj.Id;
            naAkciji.IdAkcije = max;

            NaAkciji.Create(naAkciji);

            SelektovanNaAkciji = naAkciji;

            this.DialogResult = true;
            this.Close();*/
        }

        private void SacuvajStavku(object sender, RoutedEventArgs e)
        {
            var listaStavki = Projekat.Instance.StavkeProdaje;
            SelektovaniNamestaj = dgSviNamestaji.SelectedItem as Namestaj;
            
            
            stavka.Id = listaStavki.Count+1;
            stavka.IdNamestaja = SelektovaniNamestaj.Id;
            //stavka.IdProdaje = novaProdaja.Id;
            stavka.IdProdaje = 1;
            stavka.Kolicina = int.Parse(tbKoliko.Text);
            
            StavkaProdaje.Create(stavka);

            SelektovanaStavka = stavka;

            var namNaProdaji = stavka.Namestaj as Namestaj;
            //listaNamestaja.Add(namNaProdaji);
            //listaStavki.Add(namNaProdaji);
            this.Close();
        }

        private void DugmeSearch(object sender, RoutedEventArgs e)
        {
            dgSviNamestaji.ItemsSource = Namestaj.Search(tbSearch.Text, "Id");
        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
