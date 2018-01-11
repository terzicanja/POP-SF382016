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
using static POP_SF38_2016GUI.UI.NamestajWindow;

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        private Akcija akcija;
        private Operacija operacija;
        public ObservableCollection<NaAkciji> listaNaAkciji;
        public ObservableCollection<NaAkciji> zaBrisanje;
        public NaAkciji SelektovaniNamestaj;
        private NaAkciji akcijaa;

        public AkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;
            this.listaNaAkciji = new ObservableCollection<NaAkciji>();
            this.zaBrisanje = new ObservableCollection<NaAkciji>();
            SelektovaniNamestaj = new NaAkciji();

            tbNaziv.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dtPocetka.DataContext = akcija;
            dtKraj.DataContext = akcija;
            dgPopustNamestaj.DataContext = akcija;

            foreach (var ak in Projekat.Instance.NaAkcijama)
            {
                if(ak.IdAkcije == akcija.Id)
                {
                    listaNaAkciji.Add(ak);
                }
            }

            dgPopustNamestaj.ItemsSource = listaNaAkciji;

        }

        private bool AkcijeFilter(object obj)
        {
            Akcija akk = obj as Akcija;
            return (akk.Id > 0);
        }


        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcije;
            var listaNamestaja = Projekat.Instance.Namestaji;


            foreach (var o in Projekat.Instance.NaAkcijama)
            {
                foreach (var v in listaNaAkciji)
                {
                    if (o.IdNamestaja == v.Namestaj.Id && ((o.Akcija.PocetakAkcije > DateTime.Parse(dtPocetka.Text) && o.Akcija.PocetakAkcije < DateTime.Parse(dtKraj.Text))
                    || (o.Akcija.KrajAkcije > DateTime.Parse(dtPocetka.Text) && o.Akcija.KrajAkcije < DateTime.Parse(dtKraj.Text))
                    || (o.Akcija.PocetakAkcije < DateTime.Parse(dtPocetka.Text) && o.Akcija.KrajAkcije > DateTime.Parse(dtKraj.Text))))
                    {
                        MessageBoxResult obavestenje = MessageBox.Show("Namestaj "+v.Namestaj.Naziv+" je vec na akciji u tom vremenskom periodu", "Obavestenje", MessageBoxButton.OK);
                        return;
                    }
                }
            }


            switch (operacija)
            {
                case Operacija.Dodavanje:
                    akcija.Naziv = tbNaziv.Text;
                    akcija.Popust = Double.Parse(tbPopust.Text);
                    akcija.PocetakAkcije = DateTime.Parse(dtPocetka.Text);
                    akcija.KrajAkcije = DateTime.Parse(dtKraj.Text);
                    

                    Akcija.Update(akcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Naziv = akcija.Naziv;
                            n.Popust = akcija.Popust;
                            n.PocetakAkcije = akcija.PocetakAkcije;
                            n.KrajAkcije = akcija.KrajAkcije;
                            foreach (var item in zaBrisanje)
                            {
                                listaNaAkciji.Remove(item);
                                NaAkciji.Delete(item);
                            }
                            dgPopustNamestaj.ItemsSource = listaNaAkciji;
                            Akcija.Update(n);
                            break;
                        }
                    }
                    break;
            }
            Close();
        }

        private void ZatvoriAkcijeWindow(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.Dodavanje:
                    foreach (var a in Projekat.Instance.NaAkcijama)
                    {
                        if (a.IdAkcije == akcija.Id)
                        {
                            NaAkciji.Delete(a);
                        }
                    }
                    Akcija.Delete(akcija);
                    this.Close();
                    break;
                case Operacija.Izmena:
                    this.Close();
                    break;
                default:
                    break;
            }
            
        }

        private void SviNamestaji(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Namestaji;
            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Preuzmi);
            prozor.ShowDialog();

            akcijaa = prozor.SelektovanNaAkciji;
            //akcijaa.IdAkcije = akcija.Id;
            akcijaa.IdNamestaja = akcijaa.IdNamestaja;
            NaAkciji.Update(akcijaa);

            listaNaAkciji.Add(akcijaa);
        }

        private void UkloniNamestaj(object sender, RoutedEventArgs e)
        {
            SelektovaniNamestaj = dgPopustNamestaj.SelectedItem as NaAkciji;
            zaBrisanje.Add(SelektovaniNamestaj);
            listaNaAkciji.Remove(SelektovaniNamestaj);
            //NaAkciji.Delete(SelektovaniNamestaj);
        }
    }
}
