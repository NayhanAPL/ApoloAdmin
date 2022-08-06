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
            VerMensaje();
        }
        public static bool sino = false;
        public static string mensaje = "";
        private void VerMensaje()
        {
            int x = 40;
            int y = 0;
            string text = "";
            while (x < mensaje.Length)
            {
                text += mensaje.Substring(y, 40) + "\n";
                y = x;
                x += 40;
            }           
            if (mensaje.Length - 1 > y) text += mensaje.Substring(y, mensaje.Length - y);
            texto.Content = text;
        }

        private void Canselar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.indexSelected = -1;
            sino = false;
            this.Close();          
        }

        private async void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.indexSelected != -1)
            {
                sino = true;
                string name = MainWindow.listArt[MainWindow.indexSelected].Nombre;
                var proyectos = await App.Database.GetByNameArtProyectos(name);
                proyectos.ForEach(async x => await App.Database.DeleteProyectos(x));
                await App.Database.DeleteArtistas(MainWindow.listArt[MainWindow.indexSelected]);
                MainWindow.listArt.RemoveAt(MainWindow.indexSelected);
                MainWindow.ObservablelistArt.Clear();
                MainWindow.listArt.ForEach(x => MainWindow.ObservablelistArt.Add(x));
                MainWindow.indexSelected = -1;
                this.Close();
            }
        }
    }
}
