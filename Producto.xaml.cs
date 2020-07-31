using System;
using System.Collections.Generic;
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
using System.Data;

namespace ShopRepair
{
    /// <summary>
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        BaseDatos Datos = new BaseDatos();
        ControlProductos Control = new ControlProductos();
        public Producto()
        {
            InitializeComponent();
        }
        private void Aceptar()
        {
            EntidadProductos Entidad = new EntidadProductos
            {
                IdProducto = Convert.ToInt16(TxtId.Text),
                Tipo = CBTipo.Text,
                Precio = Convert.ToInt16( TxtPrecio.Text),
                Costo = Convert.ToInt16(TxtCosto.Text),
                Descripcion = TxtDescripcion.Text, 
            };
            if (CBTipo.Text == "" | TxtDescripcion.Text == "" | TxtCosto.Text == "" | TxtPrecio.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("Productos", "id_producto", TxtId.Text))
                {
                    Control.Acciones("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtPrecio.Text = "";
                    TxtCosto.Text = "";
                    TxtDescripcion.Text = "";
                    TxtId.Text = "0";
                }
                else
                {
                    Control.Acciones("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtPrecio.Text = "";
                    TxtCosto.Text = "";
                    TxtDescripcion.Text = "";
                    TxtId.Text = "0";
                }
            }
            LlenarGrid();
        }
        private void LlenarGrid()
        {
            DataSet DSU = new DataSet();
            DSU = Control.DevolverDatos();
            GDProductos.ItemsSource = DSU.Tables[0].DefaultView;
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
        private void GDProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                TxtId.Text = row_selected["producto"].ToString();
                TxtPrecio.Text = row_selected["precio"].ToString();
                TxtCosto.Text = row_selected["costo"].ToString();
                TxtDescripcion.Text = row_selected["descripcion"].ToString();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aceptar();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LlenarGrid();
        }
    }
}
