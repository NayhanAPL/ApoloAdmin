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
using System.IO;
namespace ApoloAdmin
{
    /// <summary>
    /// Lógica de interacción para ResumenCurriculo.xaml
    /// </summary>
    public partial class ResumenCurriculo : Window
    {
        public ResumenCurriculo()
        {
            InitializeComponent();
            ByDefault();
        }

        private void ByDefault()
        {
            resumenCurriculo = "";
            if (MainWindow.artSelected != null)
            {
                resumenCurriculo = MainWindow.artSelected.Curriculo;
                resumenCurricular.Text = resumenCurriculo;
            }    
        }
        private void BuscarArchivoCurriculo_Click(object sender, RoutedEventArgs e)
        {
        }
        public static string resumenCurriculo = ""; 
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            resumenCurriculo = resumenCurricular.Text;
            this.Close();
        }

        private void ruta_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = "";
            try
            {
                string x = ruta.Text;
                using (StreamReader leer = new StreamReader(@$"{x}"))
                {
                    while (!leer.EndOfStream)
                    {
                        texto += leer.ReadLine();
                    }
                    resumenCurricular.Text = texto;
                    resumenCurriculo = texto;
                }
            }
            catch (Exception) { }
        }

        //C:\!nayhan\curriculo.txt
    }
}
