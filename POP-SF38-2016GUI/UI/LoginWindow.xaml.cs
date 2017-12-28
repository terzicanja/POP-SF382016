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
        public static Korisnik ulogovaniKorisnik;

        public LoginWindow()
        {
            InitializeComponent();
        }
        

        private void Login(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.Korisnici;
            TipKorisnika tipKorisnika;

            foreach (var k in korisnici)
            {
                if(!k.Obrisan && k.KorisnickoIme == tbUser.Text && k.Lozinka == tbPass.Text)
                {
                    //this.Hide();
                    var mainProzor = new MainWindow(k.TipKorisnika);
                    this.Close();
                    mainProzor.ShowDialog();
                    //this.Close();


                    /*ulogovaniKorisnik = k;
                    tipKorisnika = k.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:
                            //this.Close();
                            var mainProzor = new MainWindow(k.TipKorisnika);
                            mainProzor.ShowDialog();
                            break;
                        case TipKorisnika.Prodavac:
                            var prozorMain = new MainWindow(k.TipKorisnika);
                            prozorMain.ShowDialog();
                            break;
                        default:
                            break;
                    }*/
                }
            }
        }
    }
}
