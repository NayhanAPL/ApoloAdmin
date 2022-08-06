using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
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

        public static ObservableCollection<Artista> ObservablelistArt = new ObservableCollection<Artista>();
        public static List<Artista> listArt = new List<Artista>();
        public static Artista artSelected = new Artista();
        public static bool procesoActualizacion = false;
        public static byte[] foto = new byte[] { };
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
            //await App.Database.SaveUpVersionActual(new VersionActual() { Version = "1", Id = 1 });
            var version = await App.Database.GetIdVersionActual(1);
            if (version == null)
            {
                await App.Database.SaveVersionActual(new VersionActual() { Version = "1" });
            }
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = @"Archivos de imágen (.jpg)|*.jpg| All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            bool? checarOK = openFileDialog1.ShowDialog();
            if (checarOK == true)
            {
                imgBrush.ImageSource = new BitmapImage(new Uri(openFileDialog1.FileName));

                var image = new BitmapImage(new Uri(openFileDialog1.FileName));
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    foto = ms.ToArray();
                }
            }
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
            ResumenCurriculo.resumenCurriculo = "";
            Organizaciones.organizaciones = "";
            ManifestacionArtistica.manifestacionArtistica = "";
            imgBrush.ImageSource = null;
            Fecha.SelectedDate = null;
            Guardar.Content = "Guardar";
            artSelected = null;
            foto = null;
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
            int id = 0;
            if (sepuede && procesoActualizacion == false)
            {
                MensajeSubLeft("Artista guardado correctamente.");
                Artista art = new Artista()
                {
                    Correo = correo.Text,
                    ActividadProfecional = profesion.Text,
                    Nombre = nombre.Text,
                    FechaNacimiento = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString(),
                    DireccionWeb = web.Text,
                    Fijo = fijo.Text,
                    Movil = movil.Text,
                    Curriculo = ResumenCurriculo.resumenCurriculo,
                    Organizaciones = Organizaciones.organizaciones,
                    Manifestacion = ManifestacionArtistica.manifestacionArtistica,
                    Foto = foto
                };await App.Database.SaveArtistas(art);
                var last = await App.Database.GetLastItemArtistas();
                if (last != null)
                { id = last[0].Id; }
                ByDefault();
                correo.Text = "";
                profesion.Text = "";
                nombre.Text = "";
                web.Text = "";
                fijo.Text = "";
                movil.Text = "";
                ResumenCurriculo.resumenCurriculo = "";
                Organizaciones.organizaciones = "";
                ManifestacionArtistica.manifestacionArtistica = "";
                imgBrush.ImageSource = null;
                Fecha.SelectedDate = null;
                foto = null;
                artSelected = null;
                ButtonVisible(false);
            }
            else if (sepuede && procesoActualizacion == true)
            {
                id = artSelected.Id;
                Artista art = new Artista()
                {
                    Id = artSelected.Id,
                    Correo = correo.Text,
                    ActividadProfecional = profesion.Text,
                    Nombre = nombre.Text,
                    FechaNacimiento = fecha.Day.ToString() + "/" + fecha.Month.ToString() + "/" + fecha.Year.ToString(),
                    DireccionWeb = web.Text,
                    Fijo = fijo.Text,
                    Movil = movil.Text,
                    Curriculo = ResumenCurriculo.resumenCurriculo,
                    Organizaciones = Organizaciones.organizaciones,
                    Manifestacion = ManifestacionArtistica.manifestacionArtistica,
                    Foto = foto
                };await App.Database.SaveUpArtistas(art);
                ByDefault();
                procesoActualizacion = false;
                correo.Text = "";
                profesion.Text = "";
                nombre.Text = "";
                web.Text = "";
                fijo.Text = "";
                movil.Text = "";
                imgBrush.ImageSource = null;
                Fecha.SelectedDate = null;
                Guardar.Content = "Guardar";
                artSelected = null;
                MensajeSubLeft("Artista actualizado correctamente.");
                indexSelected = -1;
                ButtonVisible(false);
                foto = null;
                ResumenCurriculo.resumenCurriculo = "";
                Organizaciones.organizaciones = "";
                ManifestacionArtistica.manifestacionArtistica = "";
            }
            else
            {                
                MensajeSubLeft(mensajeError);
                artSelected = null;
            }
            var sinId = await App.Database.GetByIdArtProyectos(0);
            foreach (var item in sinId)
            {item.IdArt = id; await App.Database.SaveUpProyectos(item);}
        }
        private async void ListArtistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sinId = await App.Database.GetByIdArtProyectos(0);
            foreach (var item in sinId)
            { await App.Database.DeleteProyectos(item); }
            if (ListArtistas.SelectedIndex != -1)
            {
                ButtonVisible(true);
                index = ListArtistas.SelectedIndex;
                procesoActualizacion = true;
                Guardar.Content = "Actualizar";
                artSelected = new Artista()
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
            Fecha.SelectedDate = Convert.ToDateTime(artSelected.FechaNacimiento);
            foto = artSelected.Foto;
            ResumenCurriculo.resumenCurriculo = artSelected.Curriculo;
            Organizaciones.organizaciones = artSelected.Organizaciones;
            ManifestacionArtistica.manifestacionArtistica = artSelected.Manifestacion;
            if (artSelected.Foto != null && artSelected.Foto.Length > 0)
            {
                var stream = new MemoryStream(artSelected.Foto);
                stream.Seek(0, SeekOrigin.Begin);
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = stream;
                bmp.EndInit();
                imgBrush.ImageSource = bmp;
            }

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
            MensajeSubLeft("Artista desmarcado, puede continuar creando otros artistas.");
            indexSelected = -1;
            ButtonVisible(false);
            index = -1;
            foto = null;
            imgBrush.ImageSource = null;
            ResumenCurriculo.resumenCurriculo = "";
            Organizaciones.organizaciones = "";
            ManifestacionArtistica.manifestacionArtistica = "";
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Artista> lista = new List<Artista>();
            if (filtro.Text != " " && filtro.Text != "")
            {
                lista.AddRange(listArt.FindAll(x => 
                x.Nombre.Contains(filtro.Text) || 
                x.Manifestacion.Contains(filtro.Text) || 
                x.ActividadProfecional.Contains(filtro.Text) || 
                x.Organizaciones.Contains(filtro.Text)));

                ObservablelistArt.Clear();
                lista.ForEach(x => ObservablelistArt.Add(x));
            }
            if(lista.Count == 0)
            {
                ObservablelistArt.Clear();
                listArt.ForEach(x => ObservablelistArt.Add(x));
                MensajeSubLeft("No se encontraton Coincidencias.");
            }
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            new Info().Show();
        }
        private async void exportarDB_Click(object sender, RoutedEventArgs e)
        {
            string pathDest = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string pathAct = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ApoloAdministracion.db3");
            string nameDB = "Apolo";
            var version = await App.Database.GetIdVersionActual(1);
            nameDB += version.Version;
            nameDB += ".db3";
            string destFile = System.IO.Path.Combine(pathDest, nameDB);
            Directory.CreateDirectory(pathDest);
            File.Copy(pathAct, destFile, true);
            await App.Database.SaveUpVersionActual(new VersionActual() { Version = (Convert.ToInt32(version.Version) + 1).ToString(), Id = 1 });
            MensajeSubLeft($"La base de datos fué copiada en el escritorio.");
        }
    }
}
