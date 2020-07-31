using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace ShopRepair
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Window
    {
        BaseDatos Datos = new BaseDatos();
        ControlUsuarios Control = new ControlUsuarios();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void AceptarUser()
        {
            EntidadUsuarios Entidad = new EntidadUsuarios
            {
                Nombre = TxtNombre.Text,
                Usuario = TxtUsuario.Text,
                Contrasena = TxtContrasenna.Text,
                Puesto = CBPuesto.Text
            };

            if (TxtUsuario.Text == "" | TxtNombre.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("Usuarios", "Usuario", TxtUsuario.Text))
                {
                    Control.Acciones("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtUsuario.Text = "";
                    TxtNombre.Text = "";
                    TxtContrasenna.Text = "";
                }
                else
                {
                    Control.Acciones("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtUsuario.Text = "";
                    TxtNombre.Text = "";
                    TxtContrasenna.Text = "";
                }

            }

            LlenarGrid();

        }
        private void LlenarGrid()
        {
            DataSet DSU = new DataSet();
            DSU = Control.DevolverDatos();
            GRUsuarios.ItemsSource = DSU.Tables[0].DefaultView;
        }

        private void MostrarBox()
        {
            MessageBox.Show("Debe llenar todos los datos","Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MostrarBoxAceptar()
        {
            MessageBox.Show("Dato ingresado", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AceptarUser();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarGrid();
        }

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{



        //}

        private void GRUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                TxtNombre.Text = row_selected["nombre"].ToString();
                TxtUsuario.Text = row_selected["usuario"].ToString();
            }   
        }
    }
}
