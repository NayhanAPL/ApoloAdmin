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
    /// Lógica de interacción para Organizaciones.xaml
    /// </summary>
    public partial class Organizaciones : Window
    {
        public Organizaciones()
        {
            InitializeComponent();
            ByDefault();
        }

        private void ByDefault()
        {
            organizaciones = "";
        }

        public static string organizaciones = "";

        private void QuitarOrganiazcion(string org)
        {
            for (int i = 0; i < organizaciones.Length; i++)
            {
                if (organizaciones[i] == org[0] && organizaciones[i + 1] == org[1] && organizaciones[i + 2] == org[2])
                {
                    string primero = "";
                    if (i > 0) primero = organizaciones.Substring(0, i);
                    string segundo = "";
                    if (i + org.Length != organizaciones.Length) segundo = organizaciones.Substring(i + org.Length, organizaciones.Length - (i + org.Length));
                    organizaciones = primero + segundo;
                    break;
                }
            }
        }
        private void UNEAC_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "UNEAC, ";
        }
        private void UNEAC_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("UNEAC, ");
        }
        private void ACAA_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "ACAA, ";
        }
        private void ACAA_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("ACAA, ");
        }
        private void UPEC_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "UPEC, ";
        }
        private void UPEC_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("UPEC, ");
        }
        private void AHS_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "AHS, ";
        }
        private void AHS_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("AHS, ");
        }
        private void ASCC_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "ASCC, ";
        }
        private void ASCC_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("ASCC, ");
        }
        private void ICRT_Checked(object sender, RoutedEventArgs e)
        {
            organizaciones += "ICRT, ";
        }
        private void ICRT_Unchecked(object sender, RoutedEventArgs e)
        {
            QuitarOrganiazcion("ICRT, ");
        }
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
