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
        public static List<Proyecto> proyectos = new List<Proyecto>();
        public static ObservableCollection<Proyecto> observableProyectos = new ObservableCollection<Proyecto>();
        public static bool selectedItem = false;
        public static Proyecto proSelected = new Proyecto();
        private async void ByDefault()
        {
                proyectos.Clear();
                observableProyectos.Clear();
                ButtonVisible(false);
                proyectos = MainWindow.artSelected == null ? await App.Database.GetByNameArtProyectos(""): await App.Database.GetByNameArtProyectos(MainWindow.artSelected.Nombre);
                proyectos.ForEach(x => observableProyectos.Add(x));
                ListProyectos.ItemsSource = observableProyectos;
        }
        public async void MensajeSubLeft(string texto)
        {
            mensajeSubLeft.Content = texto;
            await Task.Delay(10000);
            mensajeSubLeft.Content = "";
        }
        private async void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (ListProyectos.SelectedIndex != -1)
            {
                
                await App.Database.DeleteProyectos(proSelected);
                proyectos.Clear();
                observableProyectos.Clear();
                proyectos = MainWindow.artSelected == null ? await App.Database.GetByNameArtProyectos("") : await App.Database.GetByNameArtProyectos(MainWindow.artSelected.Nombre);
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
                Proyecto pro = new Proyecto()
                {
                    NameArt = MainWindow.artSelected == null? "": MainWindow.artSelected.Nombre,
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
            if (sepuede && selectedItem && ListProyectos.SelectedIndex != -1)
            {
                Proyecto pro = new Proyecto()
                {
                    Id = proSelected.Id,
                    NameArt = MainWindow.artSelected == null ? "" : MainWindow.artSelected.Nombre,
                    Descripcion = Descripcion,
                    Lugar = Lugar,
                    Nombre = Nombre
                }; await App.Database.SaveUpProyectos(pro);

                proyectos.Clear();
                observableProyectos.Clear();
                proyectos = MainWindow.artSelected == null? await App.Database.GetByNameArtProyectos("") :await App.Database.GetByNameArtProyectos(MainWindow.artSelected.Nombre);
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
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
        private void ListArtistas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListProyectos.SelectedIndex != -1)
            {
                ButtonVisible(true);
                selectedItem = true;
                Guardar.Content = "Actualizar";
                proSelected = proyectos[ListProyectos.SelectedIndex];
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
