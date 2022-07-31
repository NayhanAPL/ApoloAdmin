using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApoloAdmin
{
    /// <summary>
    /// Lógica de interacción para SiNo.xaml
    /// </summary>
    public partial class SiNo : Window
    {
        public SiNo()
        {
            InitializeComponent();
        }
        private void Canselar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.listArt.RemoveAt(MainWindow.indexSelected);
            this.Close();
        }
    }
}
