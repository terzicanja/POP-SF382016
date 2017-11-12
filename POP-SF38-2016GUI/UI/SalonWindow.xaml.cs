using POP_SF382016.Model;
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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        private Salon salon;
        private Operacija operacija;


        public SalonWindow(Salon salon, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(salon, operacija);
        }

        private void InicijalizujVrednosti(Salon salon, Operacija operacija)
        {
            this.salon = salon;
            this.operacija = operacija;

            this.tbNaziv.Text = salon.Naziv;
            this.tbAdresa.Text = salon.Adresa;
            this.tbTelefon.Text = salon.Telefon;
            this.tbEmail.Text = salon.Email;
            this.tbSajt.Text = salon.Sajt;
            this.tbPIB.Text = salon.PIB.ToString();
            this.tbMaticniBroj.Text = salon.MaticniBroj.ToString();
            this.tbZiroRacun.Text = salon.ZiroRacun;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var lista = Projekat.Instance.Salon;

            switch (operacija)
            {
                case Operacija.Izmena:
                    foreach (var n in lista)
                    {
                        if (n.Id == salon.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.Adresa = this.tbAdresa.Text;
                            n.Telefon = this.tbTelefon.Text;
                            n.Email = this.tbEmail.Text;
                            n.Sajt = this.tbSajt.Text;
                            n.PIB = int.Parse(this.tbPIB.Text);
                            n.MaticniBroj = int.Parse(this.tbMaticniBroj.Text);
                            n.ZiroRacun = this.tbZiroRacun.Text;
                            break;
                        }
                    }
                    break;
            }
            Projekat.Instance.Salon = lista;
            Close();
        }

        private void ZatvoriSalonWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
