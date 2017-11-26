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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        public enum Operacija
        {
            Dodavanje,
            Izmena
        };

        private Salon salon;
        private Operacija operacija;

        public SalonWindow(Salon salon, Operacija operacija)
        {
            InitializeComponent();

            this.salon = salon;
            this.operacija = operacija;

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbEmail.DataContext = salon;
            tbSajt.DataContext = salon;
            tbPIB.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbZiroRacun.DataContext = salon;
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
                            n.Naziv = salon.Naziv;
                            n.Adresa = salon.Adresa;
                            n.Telefon = salon.Telefon;
                            n.Email = salon.Email;
                            n.Sajt = salon.Sajt;
                            n.PIB = salon.PIB;
                            n.MaticniBroj = salon.MaticniBroj;
                            n.ZiroRacun = salon.ZiroRacun;
                            break;
                        }
                    }
                    break;
            }
            GenericSerializer.Serialize("salon.xml", lista);
            Close();
        }

        private void ZatvoriSalonWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
