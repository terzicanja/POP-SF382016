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

namespace POP_SF38_2016GUI.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        

        private void Login(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.Korisnik;
            TipKorisnika tipKorisnika;

            foreach (var k in korisnici)
            {
                if(!k.Obrisan && k.KorisnickoIme == tbUser.Text && k.Lozinka == tbPass.Text)
                {
                    tipKorisnika = k.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:
                            break;
                        case TipKorisnika.Korisnik:
                            break;
                        case TipKorisnika.Prodavac:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
