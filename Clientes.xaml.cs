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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopRepair
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BaseDatos Datos = new BaseDatos();
        ControlClientes Control = new ControlClientes();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Aceptar()
        {
            EntidadClientes Entidad = new EntidadClientes
            {
                IdCliente = Convert.ToInt16(TxtIdCliente.Text),
                Cedula = TxtCedula.Text,
                Nombre = TxtNombre.Text,
                Telefono1 = TxtTel1.Text,
                Telefono2 = TxtTel2.Text,
                Telefono3 = TxtTel3.Text,
                Correo = TxtCorreo.Text,
                Direccion = TxtDireccion.Text,
                Tipo = CbTipo.Text
            };

            if (TxtCedula.Text == "" | TxtNombre.Text == "" | TxtTel1.Text == "" | CbTipo.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("Clientes", "id_cliente", TxtIdCliente.Text))
                {
                    Control.Acciones("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtNombre.Text = "";
                    TxtIdCliente.Text = "";
                    TxtCedula.Text = "";
                    TxtTel1.Text = "";
                    TxtTel2.Text = "";
                    TxtTel3.Text = "";
                    TxtCorreo.Text = "";
                    TxtDireccion.Text = "";
                    CbTipo.Text = "";
                   
                }
                else
                {
                    Control.Acciones("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtNombre.Text = "";
                    TxtIdCliente.Text = "";
                    TxtCedula.Text = "";
                    TxtTel1.Text = "";
                    TxtTel2.Text = "";
                    TxtTel3.Text = "";
                    TxtCorreo.Text = "";
                    TxtDireccion.Text = "";
                    CbTipo.Text = "";

                }

            }

            LlenarGrid();

        }

        private void LlenarGrid()
        {
            DataSet DSU = new DataSet();
            DSU = Control.DevolverDatos();
            GDClientes.ItemsSource = DSU.Tables[0].DefaultView;
        }

        private void MostrarBox()
        {
            MessageBox.Show("Debe llenar todos los datos", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MostrarBoxAceptar()
        {
            MessageBox.Show("Dato ingresado", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarGrid();
        }

        private void GDClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                TxtIdCliente.Text = row_selected["id_cliente"].ToString();
                TxtCedula.Text = row_selected["cedula"].ToString();
                TxtNombre.Text = row_selected["nombre"].ToString();
                TxtTel1.Text = row_selected["telefono1"].ToString();
                TxtTel2.Text = row_selected["telefono2"].ToString();
                TxtTel3.Text = row_selected["telefono3"].ToString();
                TxtCorreo.Text = row_selected["correo"].ToString();
                TxtDireccion.Text = row_selected["direccion"].ToString();
                CbTipo.Text = row_selected["tipo"].ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Aceptar();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            DataSet DS = new DataSet();
            DS = Control.DevolverDato(TxtFiltro.Text);
            GDClientes.ItemsSource = DS.Tables[0].DefaultView;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            Ordenes frm = new Ordenes();
            frm.TxtCodCliente.Text = TxtIdCliente.Text;
            frm.TxtCedula.Text = TxtCedula.Text;
            frm.Show();
            this.Hide();
        }
    }
}
