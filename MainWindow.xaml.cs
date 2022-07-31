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
            ByDefault();
        }
        public static ObservableCollection<Artistas> listArt = new ObservableCollection<Artistas>();
        private void ByDefault()
        {
            listArt.Clear();
                listArt.Add(new Artistas()
                {
                    Nombre = "Nayhan",
                    FechaNacimiento = new DateTime(2001, 2, 26),
                    ActividadProfecional = "Programador",
                    Correo = "nayhanprovedolabrada@gmail.com",
                    Curriculo = "no tiene nada por ahora está tratando de conseguir su primer empleo, trabaja con hxamarin forms en la creacion de aplicaciones android alsnscjlkas aslkascas asclkas clksacas caslkcnskc; a;lvm d rvr[ vrwv rv orpvwe,vwe;lvcsdpvewv dvlc als casl;c k; csakc ec ec ek ckc asc as;ck ascas c askc pacac, ascasc asckas caksc alskc askc ac sack sack sack ecev  vkv l;v adv dsv;ds vd;slv sd;v, svk v;v ds;v sd;v sdv; sdvsdv ;v sd;lv dsvk sv;d vsd;v dsv;, ;sv sdkv sva;cas c;v sdkvs dvklds vds vs dvklsd vdslkv sd v dvlsd vls vlksd vkld vdksv dsklv dv  dv ewlkg ewgk d svdsv svk dsv sdv dkv skv sdvl dsvl dsvl dsv   dsvksdlfkdsafnakslfjasklfasf dslf dslfksdfaslfasf;ioawfhlkanvdascpiejgkdsn;vkNFI:OEANFVDSKLv;naiefvfnae,dsnkcads .",
                    DireccionWeb = "https://www.google.ru/search",
                    Fijo = "77974732",
                    Id = 1,
                    Manifestacion = "Música",
                    Movil = "58747585",
                    Organizaciones = "UNEAC, UPEC",
                    Foto = new Image()
                });
                listArt.Add(new Artistas()
                {
                    Nombre = "Susana",
                    FechaNacimiento = new DateTime(1992, 11, 21),
                    ActividadProfecional = "FrontEnd",
                    Correo = "susanabp1992@gmail.com",
                    Curriculo = "ha trabajado para el sitio oficial del museo de vellas artes",
                    DireccionWeb = "susy/porahi/miraver/siencuentrasalgo/direc.www.com",
                    Fijo = "78324543",
                    Id = 2,
                    Manifestacion = "Música",
                    Movil = "58237413",
                    Organizaciones = "AHS, UNEAC, UPEC",
                    Foto = new Image()
                });
            ListArtistas.ItemsSource = listArt;
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
                new SiNo.Show();
                if (SiNo.respuesta)
                {
                    ListArtistas.Items
                }
            }
            else MessageBox.Show("Debe seleccionar un artista para poder borrarlo.");
        }
        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string mensajeError = "";
            bool sepuede = true;
            if (string.IsNullOrEmpty(nombre.Text))
            {
                sepuede = false;
                mensajeError += "Le faltó el dato obligatorio nombre del artista.\n";
            }
            DateTime fecha = new DateTime();
            if (!string.IsNullOrEmpty(anno.Text) && !string.IsNullOrEmpty(mes.Text) && !string.IsNullOrEmpty(dia.Text))
            {
                try
                {
                    Convert.ToInt32(anno.Text);
                    Convert.ToInt32(dia.Text);
                    Convert.ToInt32(mes.Text);
                    if (anno.Text.Length < 4 || anno.Text.Length > 4 || mes.Text.Length < 1 || mes.Text.Length > 2 || dia.Text.Length < 1 || dia.Text.Length > 2)
                    {
                        sepuede = false;
                        mensajeError += "El espacio de año debe tener 4 caracteres, el espacio de mes y de día deben tener 1 o 2 caracteres.\n";
                    }
                    else
                    {
                        fecha = new DateTime(year: Convert.ToInt32(anno.Text), month: Convert.ToInt32(mes.Text), day: Convert.ToInt32(dia.Text));
                    }
                }
                catch (Exception)
                {
                    sepuede = false;
                    mensajeError += "los parametros de año, mes y día de fecha de nacimiento deben tener solo caracteres numéricos.\n";
                }
            }
            if (sepuede)
            {
                listArt.Add(new Artistas()
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
                    Foto = new Image()
                }) ;
                ListArtistas.ItemsSource = listArt;
                correo.Text = "";
                profesion.Text = "";
                nombre.Text = "";
                web.Text = "";
                fijo.Text = "";
                movil.Text = "";
                anno.Text = "";
                mes.Text = "";
                dia.Text = "";
                MessageBox.Show("Elemento guardado correctamente");
            }
            else MessageBox.Show(mensajeError);
        }
    }
    public class Artistas
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Image Foto { get; set; }
        public string Manifestacion { get; set; }
        public string ActividadProfecional { get; set; }
        public string Fijo { get; set; }
        public string Movil { get; set; }
        public string Correo { get; set; }
        public string DireccionWeb { get; set; }
        public string Curriculo { get; set; }
        public string Organizaciones { get; set; }
    }
    public class Proyectos
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdArt { get; set; }
        public string Nombre { get; set; }
        public string Lugar { get; set; }
        public string Descripcion { get; set; }
    }
}
