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

        public AkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;
            this.listaNaAkciji = new ObservableCollection<NaAkciji>();

            tbPopust.DataContext = akcija;
            dtPocetka.DataContext = akcija;
            dtKraj.DataContext = akcija;

            //dgPopustNamestaj.IsSynchronizedWithCurrentItem = true;
            //dgPopustNamestaj.DataContext = akcija;
            //dgPopustNamestaj.SelectedValue = SelectedNamestaj;

            //dgPopustNamestaj.ItemsSource = akcija.IdNamestaja;
            //POSLE BAZA NE VALJA


            //dgPopustNamestaj.ItemsSource = dgPopustNamestaj.SelectedItem
            
        }
        

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Akcije;
            var listaNamestaja = Projekat.Instance.Namestaji;

            /*akcija.Id = Projekat.Instance.Akcije.Count + 1;
            akcija.Naziv = "a";
            Akcija.Create(akcija);*/

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    //akcija.Id = lista.Count + 1;
                    akcija.Popust = Double.Parse(tbPopust.Text);
                    akcija.PocetakAkcije = DateTime.Parse(dtPocetka.Text);
                    akcija.KrajAkcije = DateTime.Parse(dtKraj.Text);
                    //akcija.IdNamestaja.Add(akcija.IdNamestaja)
                    //akcija.IdNamestaja = Namestaj.GetById(int.Parse(dgPopustNamestaj.SelectedItem.ToString()));
                    //dgPopustNamestaj.ItemsSource = akcija.IdNamestaja;
                    //PocetakAkcije = this.DatumPocetka.Text

                    Akcija.Update(akcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Popust = akcija.Popust;
                            n.PocetakAkcije = akcija.PocetakAkcije;
                            n.KrajAkcije = akcija.KrajAkcije;


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
            this.Close();
        }

        private void SviNamestaji(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Namestaji;
            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Preuzmi);
            prozor.ShowDialog();

            var akcijaa = prozor.SelektovanNaAkciji;
            akcijaa.IdAkcije = akcija.Id;
            akcijaa.IdNamestaja = akcijaa.IdNamestaja;
            NaAkciji.Update(akcijaa);

            listaNaAkciji.Add(akcijaa);
            dgPopustNamestaj.ItemsSource = listaNaAkciji;
            
            /*if(dgPopustNamestaj.SelectedItem is Namestaj n)
            //if(prozor.SelektovaniNamestaj is Namestaj n)
            {
                //NamestajNaPopustu.Add(n.Id);
                akcija.IdNamestaja.Add(n.Id);
                dgPopustNamestaj.DataContext = akcija.IdNamestaja;
                //lista.Add(prozor.SelektovaniNamestaj);
                //IdNamestajaNaAkciji.Add(prozor.SelektovaniNamestaj.Id);
            }*/
        }
        
    }
}
