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
    /// Lógica de interacción para ManifestacionArtistica.xaml
    /// </summary>
    public partial class ManifestacionArtistica : Window
    {
        public ManifestacionArtistica()
        {
            InitializeComponent();
            ByDefault();
        }

        private void ByDefault()
        {
            manifestacionArtistica = "";
        }
        public static string manifestacionArtistica = "";
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            manifestacionArtistica = manifestacion.SelectedItem.ToString();
            this.Close();
        }
    }
}
