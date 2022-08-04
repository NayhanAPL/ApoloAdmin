using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ApoloAdmin
{
    /// <summary>
    /// Lógica de interacción para VinculacionesProyectos.xaml
    /// </summary>
    public partial class VinculacionesProyectos : Window
    {
        public VinculacionesProyectos()
        {
            InitializeComponent();
            ByDefault();
        }
        public static List<Proyectos> proyectos = new List<Proyectos>();
        public static ObservableCollection<Proyectos> observableProyectos = new ObservableCollection<Proyectos>();
        public static bool selectedItem = false;
        public static Proyectos proSelected = new Proyectos();
        private async void ByDefault()
        {
            if (MainWindow.artSelected != null)
            {
                proyectos.Clear();
                observableProyectos.Clear();
                ButtonVisible(false);
                proyectos = await App.Database.GetByIdArtProyectos(MainWindow.artSelected.Id);
                proyectos.ForEach(x => observableProyectos.Add(x));
                ListArtistas.ItemsSource = observableProyectos;
            }
        }
        public async void MensajeSubLeft(string texto)
        {
            mensajeSubLeft.Content = texto;
            await Task.Delay(10000);
            mensajeSubLeft.Content = "";
        }
        private async void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.artSelected != null && ListArtistas.SelectedIndex != -1)
            {
                
                await App.Database.DeleteProyectos(proSelected);
                proyectos.Clear();
                observableProyectos.Clear();
                proyectos = await App.Database.GetByIdArtProyectos(MainWindow.artSelected.Id);
                proyectos.ForEach(x => observableProyectos.Add(x));
                MensajeSubLeft($"Ha borrado el proyecto {proSelected.Nombre} de la base de datos.");
                ButtonVisible(false);
                proSelected = null;
                selectedItem = false;
                nombre.Text = "";
                lugar.Text = "";
                descripcion.Text = "";
                Guardar.Content = "Guardar";
            }
        }
        private async void Guardar_Click(object sender, RoutedEventArgs e)
        {

            if (MainWindow.artSelected != null)
            {
                string Nombre = "";
                string Lugar = "";
                string Descripcion = "";
                bool sepuede = true;
                if (string.IsNullOrEmpty(nombre.Text))
                { sepuede = false; MensajeSubLeft("Debe darle un nombre al proyecto para guardarlo."); }
                else Nombre = nombre.Text;
                if (string.IsNullOrEmpty(lugar.Text))
                { sepuede = false; MensajeSubLeft("Debe especificar el lugar del proyecto para guardarlo."); }
                else Lugar = lugar.Text;
                if (!string.IsNullOrEmpty(descripcion.Text)) Descripcion = descripcion.Text;
                if (sepuede && !selectedItem)
                {
                    Proyectos pro = new Proyectos()
                    {
                        IdArt = MainWindow.artSelected.Id,
                        Descripcion = Descripcion,
                        Lugar = Lugar,
                        Nombre = Nombre
                    }; await App.Database.SaveProyectos(pro);
                    proyectos.Add(pro);
                    observableProyectos.Add(pro);
                    nombre.Text = "";
                    lugar.Text = "";
                    descripcion.Text = "";
                    selectedItem = false;
                    proSelected = null;
                    MensajeSubLeft("Proyecto guardado correctamente.");
                }
                if (sepuede && selectedItem && ListArtistas.SelectedIndex != -1)
                {
                    Proyectos pro = new Proyectos()
                    {
                        Id = proSelected.Id,
                        IdArt = MainWindow.artSelected.Id,
                        Descripcion = Descripcion,
                        Lugar = Lugar,
                        Nombre = Nombre
                    }; await App.Database.SaveUpProyectos(pro);

                    proyectos.Clear();
                    observableProyectos.Clear();
                    proyectos = await App.Database.GetByIdArtProyectos(MainWindow.artSelected.Id);
                    proyectos.ForEach(x => observableProyectos.Add(x));

                    Guardar.Content = "Guardar";
                    nombre.Text = "";
                    lugar.Text = "";
                    descripcion.Text = "";
                    selectedItem = false;
                    proSelected = null;
                    ButtonVisible(false);
                    MensajeSubLeft("Proyecto actualizado correctamente.");
                }
            }
        }
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
        private void ListArtistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.artSelected != null && ListArtistas.SelectedIndex != -1)
            {
                ButtonVisible(true);
                selectedItem = true;
                Guardar.Content = "Actualizar";
                proSelected = proyectos[ListArtistas.SelectedIndex];
                nombre.Text = proSelected.Nombre;
                lugar.Text = proSelected.Lugar;
                descripcion.Text = proSelected.Descripcion;
                MensajeSubLeft($"Ha seleccionado el proyecto {proSelected.Nombre} puede actualizar sus datos o eliminarlos.");
            }
        }
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
        private void Canselar_Click(object sender, RoutedEventArgs e)
        {
            Guardar.Content = "Guardar";
            proSelected = null;
            selectedItem = false;
            nombre.Text = "";
            lugar.Text = "";
            descripcion.Text = "";
            ButtonVisible(false);
            MensajeSubLeft($"Ha cancelado el proceso, ahora puede crear uno proyecto nuevo.");
        }

    }
}
