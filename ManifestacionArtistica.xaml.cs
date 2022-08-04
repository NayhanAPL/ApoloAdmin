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
            if (MainWindow.artSelected != null)
            {
                if (manifestacionArtistica == "Danza") manifestacion.SelectedIndex = 0;
                else if (manifestacionArtistica == "Música") manifestacion.SelectedIndex = 1;
                else if (manifestacionArtistica == "Teatro") manifestacion.SelectedIndex = 2;
                else if (manifestacionArtistica == "Literatura") manifestacion.SelectedIndex = 3;
                else if (manifestacionArtistica == "Artes visuales") manifestacion.SelectedIndex = 4;
                else if (manifestacionArtistica == "Diseño") manifestacion.SelectedIndex = 5;
                else if (manifestacionArtistica == "Fotografía") manifestacion.SelectedIndex = 6;
            }                
        }
        public static string manifestacionArtistica = "";
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            int index = manifestacion.SelectedIndex;
            if (index == 0) manifestacionArtistica = "Danza";
            else if (index == 1) manifestacionArtistica = "Música";
            else if (index == 2) manifestacionArtistica = "Teatro";
            else if (index == 3) manifestacionArtistica = "Literatura";
            else if (index == 4) manifestacionArtistica = "Artes visuales";
            else if (index == 5) manifestacionArtistica = "Diseño";
            else if (index == 6) manifestacionArtistica = "Fotografía";
            this.Close();
        }
    }
}
