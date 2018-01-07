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
    /// Interaction logic for SveUslugeWindow.xaml
    /// </summary>
    public partial class SveUslugeWindow : Window
    {
        public DodatnaUsluga SelektovanaUsluga;
        public UslugaProdaje SelektovanaUslugaZaProdaju;
        private UslugaProdaje uslugaZaProdaju;

        public SveUslugeWindow()
        {
            InitializeComponent();

            this.uslugaZaProdaju = new UslugaProdaje();
            SelektovanaUslugaZaProdaju = new UslugaProdaje();

            dgSveUsluge.DataContext = this;
            dgSveUsluge.ItemsSource = Projekat.Instance.DodatneUsluge;
        }

        private void PickUsluga(object sender, RoutedEventArgs e)
        {
            SelektovanaUsluga = dgSveUsluge.SelectedItem as DodatnaUsluga;

            uslugaZaProdaju.IdUsluge = SelektovanaUsluga.Id;
            uslugaZaProdaju.IdProdaje = 1;

            UslugaProdaje.Create(uslugaZaProdaju);
            SelektovanaUslugaZaProdaju = uslugaZaProdaju;

            this.Close();
        }
    }
}
