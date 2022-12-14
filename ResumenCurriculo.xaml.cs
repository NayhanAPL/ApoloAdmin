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
using Microsoft.Win32;

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
            if (MainWindow.artSelected != null)
            {
                resumenCurricular.Text = resumenCurriculo;
            }    
        }
        private void BuscarArchivoCurriculo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog().HasValue)
            {
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    resumenCurriculo = reader.ReadToEnd();
                }
                resumenCurricular.Text = resumenCurriculo;
            }
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
                        texto += "\n";
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
