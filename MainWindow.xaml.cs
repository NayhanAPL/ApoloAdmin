using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApoloAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonVisible(false);
            ByDefault();
        }

        

        public static ObservableCollection<Artistas> ObservablelistArt = new ObservableCollection<Artistas>();
        public static List<Artistas> listArt = new List<Artistas>();
        public static Artistas artSelected = new Artistas();
        public static bool procesoActualizacion = false;
        private static int index = -1;
        public static int indexSelected = -1;

        private void ButtonVisible(bool isVisible)
        {
            if (isVisible)
            {
                Canselar.Opacity = 100;
            }
            if (!isVisible)
            {
                Canselar.Opacity = 0;
            }
        }
        private async void ByDefault()
        {           
            listArt.Clear();
            ObservablelistArt.Clear();
            listArt = await App.Database.GetArtistas();
            ObservablelistArt.Clear();
            listArt.ForEach(x => ObservablelistArt.Add(x));
            ListArtistas.ItemsSource = ObservablelistArt;
        }
        public async void MensajeSubLeft(string texto)
        {
            mensajeSubleft.Content = texto;
            await Task.Delay(10000);
            mensajeSubleft.Content = "";
        }
        private void ButtonOrganizaciones_Click(object sender, RoutedEventArgs e)
        {
            new Organizaciones().Show();
        }
        private void ButtonFoto_Click(object sender, RoutedEventArgs e)
        {
        }
        private void ButtonManifestacion_Click(object sender, RoutedEventArgs e)
        {
            new ManifestacionArtistica().Show();
        }
        private void ButtonVinculaciones_Click(object sender, RoutedEventArgs e)
        {
            new VinculacionesProyectos().Show();
        }
        private void ButtonCurriculo_Click(object sender, RoutedEventArgs e)
        {
            new ResumenCurriculo().Show();
        }
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (ListArtistas.SelectedIndex != -1)
            {
                indexSelected = ListArtistas.SelectedIndex;
                SiNo.mensaje = "¿Desea borrar este artista de la base de datos?";
                new SiNo().Show();
            }
            else MensajeSubLeft("Debe seleccionar un artista para poder borrarlo.");
            procesoActualizacion = false;
            correo.Text = "";
            profesion.Text = "";
            nombre.Text = "";
            web.Text = "";
            fijo.Text = "";
            movil.Text = "";
            Fecha.SelectedDate = null;
            Guardar.Content = "Guardar";
            artSelected = null;
            ButtonVisible(false);
        }
        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string mensajeError = "";
            bool sepuede = true;
            if (string.IsNullOrEmpty(nombre.Text))
            {
                sepuede = false;
                mensajeError += "Le faltó el dato obligatorio nombre del artista.\n";
            }
            DateTime fecha = new DateTime();
            try
            {
                fecha = Fecha.SelectedDate.Value;
            }
            catch (Exception){}
            if (sepuede && procesoActualizacion == false)
            {
                MensajeSubLeft("Artista guardado correctamente.");
                Artistas art = new Artistas()
                {
                    Correo = correo.Text,
                    ActividadProfecional = profesion.Text,
                    Nombre = nombre.Text,
                    FechaNacimiento = fecha,
                    DireccionWeb = web.Text,
                    Fijo = fijo.Text,
                    Movil = movil.Text,
                    Curriculo = ResumenCurriculo.resumenCurriculo,
                    Organizaciones = Organizaciones.organizaciones,
                    Manifestacion = ManifestacionArtistica.manifestacionArtistica,
                };await App.Database.SaveArtistas(art);
                ByDefault();
                correo.Text = "";
                profesion.Text = "";
                nombre.Text = "";
                web.Text = "";
                fijo.Text = "";
                movil.Text = "";
                Fecha.SelectedDate = null;
                ButtonVisible(false);
            }
            if (sepuede && procesoActualizacion == true)
            {
                Artistas art = new Artistas()
                {
                    Id = artSelected.Id,
                    Correo = correo.Text,
                    ActividadProfecional = profesion.Text,
                    Nombre = nombre.Text,
                    FechaNacimiento = fecha,
                    DireccionWeb = web.Text,
                    Fijo = fijo.Text,
                    Movil = movil.Text,
                    Curriculo = ResumenCurriculo.resumenCurriculo,
                    Organizaciones = Organizaciones.organizaciones,
                    Manifestacion = ManifestacionArtistica.manifestacionArtistica,
                };await App.Database.SaveUpArtistas(art);
                ByDefault();
                procesoActualizacion = false;
                correo.Text = "";
                profesion.Text = "";
                nombre.Text = "";
                web.Text = "";
                fijo.Text = "";
                movil.Text = "";
                Fecha.SelectedDate = null;
                Guardar.Content = "Guardar";
                artSelected = null;
                MensajeSubLeft("Artista actualizado correctamente.");
                indexSelected = -1;
                ButtonVisible(false);
            }
            else
            {
                MensajeSubLeft(mensajeError);
            }

        }
        private void ListArtistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonVisible(true);
            if (ListArtistas.SelectedIndex != -1)
            {
                index = ListArtistas.SelectedIndex;
                procesoActualizacion = true;
                Guardar.Content = "Actualizar";
                artSelected = new Artistas()
                {
                    Nombre = listArt[index].Nombre,
                    ActividadProfecional = listArt[index].ActividadProfecional,
                    Correo = listArt[index].Correo,
                    Curriculo = listArt[index].Curriculo,
                    DireccionWeb = listArt[index].DireccionWeb,
                    FechaNacimiento = listArt[index].FechaNacimiento,
                    Fijo = listArt[index].Fijo,
                    Foto = listArt[index].Foto,
                    Movil = listArt[index].Movil,
                    Manifestacion = listArt[index].Manifestacion,
                    Id = listArt[index].Id,
                    Organizaciones = listArt[index].Organizaciones
                };
                MensajeSubLeft($"Ha seleccionado al artista {artSelected.Nombre}");
                Actualizar();
            }
        }
        private void Actualizar()
        {
            correo.Text = artSelected.Correo;
            profesion.Text = artSelected.ActividadProfecional;
            nombre.Text = artSelected.Nombre;
            web.Text = artSelected.DireccionWeb;
            fijo.Text = artSelected.Fijo;
            movil.Text = artSelected.Movil;
            Fecha.SelectedDate = artSelected.FechaNacimiento;
            MensajeSubLeft($"Seleccionó al artista {artSelected.Nombre}");

        }
        private void Canselar_Click(object sender, RoutedEventArgs e)
        {
            procesoActualizacion = false;
            correo.Text = "";
            profesion.Text = "";
            nombre.Text = "";
            web.Text = "";
            fijo.Text = "";
            movil.Text = "";
            Fecha.SelectedDate = null;
            Guardar.Content = "Guardar";
            artSelected = null;
            MensajeSubLeft("Artista actualizado correctamente.");
            indexSelected = -1;
            ButtonVisible(false);
            index = -1;
        }
    }
}
