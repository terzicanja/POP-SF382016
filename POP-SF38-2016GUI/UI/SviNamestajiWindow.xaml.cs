﻿using POP_SF382016.Model;
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
    /// Interaction logic for SviNamestajiWindow.xaml
    /// </summary>
    public partial class SviNamestajiWindow : Window
    {
        public SviNamestajiWindow()
        {
            InitializeComponent();

            dgSviNamestaji.DataContext = this;
            dgSviNamestaji.ItemsSource = Projekat.Instance.Namestaj;
        }
    }
}
