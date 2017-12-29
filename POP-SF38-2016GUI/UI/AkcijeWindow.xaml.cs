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
    /// Interaction logic for AkcijeWindow.xaml
    /// </summary>
    public partial class AkcijeWindow : Window
    {
        private Akcija akcija;
        private Operacija operacija;

        public AkcijeWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbPopust.DataContext = akcija;
            dtPocetka.DataContext = akcija;
            dtKraj.DataContext = akcija;

            //dgPopustNamestaj.IsSynchronizedWithCurrentItem = true;
            //dgPopustNamestaj.DataContext = akcija;
            //dgPopustNamestaj.SelectedValue = SelectedNamestaj;

            //dgPopustNamestaj.ItemsSource = akcija.IdNamestaja;
            //POSLE BAZA NE VALJA


            //dgPopustNamestaj.ItemsSource = dgPopustNamestaj.SelectedItem


            /*akcija.Id = Projekat.Instance.Akcije.Count + 1;
            akcija.Naziv = "a";
            Akcija.Create(akcija);*/
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

                    //lista.Add(akcija);
                    break;
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.Popust = akcija.Popust;
                            n.PocetakAkcije = akcija.PocetakAkcije;
                            n.KrajAkcije = akcija.KrajAkcije;
                            //n.IdNamestaja = akcija.IdNamestaja;


                            Akcija.Update(n);


                            /*foreach (var nam in listaNamestaja)
                            {
                                if(n.IdNamestaja.Contains(nam.Id))
                                {
                                    nam.IdAkcije = n.Id;
                                }
                            }*/
                            break;
                        }
                    }
                    break;
            }
            //GenericSerializer.Serialize("akcija.xml", lista);
            //GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
            Close();
        }

        private void ZatvoriAkcijeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SviNamestaji(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Namestaji;
            //var NamestajNaPopustu = akcija.IdNamestaja;
            SviNamestajiWindow prozor = new SviNamestajiWindow(SviNamestajiWindow.Radnja.Preuzmi);
            
            prozor.ShowDialog();

            var akcijaa = prozor.SelektovanNaAkciji;
            akcijaa.IdAkcije = akcija.Id;
            akcijaa.IdNamestaja = akcijaa.IdNamestaja;
            NaAkciji.Update(akcijaa);



            //if(prozor.ShowDialog() == true)
            //{

                //akcija.IdNamestaja.Add(prozor.SelektovaniNamestaj.Id);
                //OVA IZNAD LINIJA JE VALJALA PRE BAZA


                //akcija.IdNamestaja = prozor.SelektovaniNamestaj
                //var namId = prozor.SelektovaniNamestaj.Id;
                
                //akcija.IdNamestaja.Add(prozor.SelektovaniNamestaj.Id);
                //akcija.IdNamestaja = int.Parse(prozor.SelektovaniNamestaj);
                //akcija.IdNamestaja = Namestaj.GetById(int.Parse(prozor.SelektovaniNamestaj.Naziv));
            //}
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



        /*public Namestaj selectedNamestaj;

        public Namestaj SelectedNamestaj
        {
            get { return selectedNamestaj; }
            set
            {
                if (selectedNamestaj == value) return;
                selectedNamestaj = value;
                akcija.IdNamestaja.Add(selectedNamestaj.Id);
            }
        }*/
    }
}
