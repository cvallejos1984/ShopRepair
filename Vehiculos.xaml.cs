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
    /// Lógica de interacción para Vehiculos.xaml
    /// </summary>
    public partial class Vehiculos : Window
    {
        BaseDatos Datos = new BaseDatos();
        ControlMarcMod Control = new ControlMarcMod();
        ControlVeh ControlVehc = new ControlVeh();
        int id_marca = 0;
        public Vehiculos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Aceptar();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Datos.Marcas(CBMarcas);
            LlenarGrid();
        }

        private void CBMarcas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet Ds = new DataSet();
            Ds = Control.DevolverDato(Convert.ToString(CBMarcas.SelectedValue));
            TxtIdMarca.Text = Convert.ToString(Ds.Tables[0].Rows[0][0]);
            id_marca = Convert.ToInt16(TxtIdMarca.Text);
            CBModelos.Items.Clear();
            Datos.Modelos(CBModelos, id_marca);
        }

        private void CBModelos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataSet Ds = new DataSet();
            //Ds = Control.DevolverIdModelo(Convert.ToString(CBModelos.SelectedValue));
            //TxtIdModelo.Text = Convert.ToString(Ds.Tables[0].Rows[0][0]);
        }

        private void TxtAbrir_Click(object sender, RoutedEventArgs e)
        {
            Marcas_y_Modelos frm = new Marcas_y_Modelos();
            frm.Show();
        }

        private void Aceptar()
        {
            DataSet Ds = new DataSet();
            Ds = Control.DevolverIdModelo(Convert.ToString(CBModelos.SelectedValue));
            TxtIdModelo.Text = Convert.ToString(Ds.Tables[0].Rows[0][0]);
            EntidadVeh Entidad = new EntidadVeh
            {             
                IdVehiculo = Convert.ToInt16(TxtIdVeh.Text),
                IdMarca = TxtIdMarca.Text,
                IdModelo = TxtIdModelo.Text,
                Placa = TxtPlaca.Text,
                Anno = TxtYear.Text,
                Marca = CBMarcas.Text,
                Modelo = CBModelos.Text,
                IdCliente = TxtCodCliente.Text
                
            };

            if (TxtIdMarca.Text == "" | TxtIdModelo.Text == "" | TxtPlaca.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("vehiculos", "id_vehiculo", TxtIdVeh.Text))
                {
                    ControlVehc.Acciones("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdModelo.Text = "0";
                    TxtIdVeh.Text = "0";
                    TxtIdMarca.Text = "";
                    TxtPlaca.Text = "";
                    TxtYear.Text = "";
                    TxtCodCliente.Text = "";


                 }
                else
                {
                    ControlVehc.Acciones("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdModelo.Text = "0";
                    TxtIdVeh.Text = "0";
                    TxtIdMarca.Text = "";
                    TxtPlaca.Text = "";
                    TxtYear.Text = "";
                    TxtCodCliente.Text = "";
                }

            }

            LlenarGrid();
        }

        private void LlenarGrid()
        {
            DataSet DSU = new DataSet();
            DSU = ControlVehc.DevolverDatos();
            GDVehiculos.ItemsSource = DSU.Tables[0].DefaultView;
        }

        private void MostrarBox()
        {
            MessageBox.Show("Debe llenar todos los datos", Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MostrarBoxAceptar()
        {
            MessageBox.Show("Dato ingresado", Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void GDVehiculos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                TxtIdVeh.Text = row_selected["vehiculo"].ToString();
                TxtPlaca.Text = row_selected["placa"].ToString();
                TxtYear.Text = row_selected["año"].ToString();
                CBMarcas.Text = row_selected["marca"].ToString();
                CBModelos.Text = row_selected["modelo"].ToString();
                TxtCodCliente.Text = row_selected["codigo_cliente"].ToString();
            }
            else
            {
                TxtIdModelo.Text = "0";
                TxtIdVeh.Text = "0";
                TxtIdMarca.Text = "";
                TxtPlaca.Text = "";
                TxtYear.Text = "";
            }
        }
        private void TxtAct_Click(object sender, RoutedEventArgs e)
        {   if (CBMarcas.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una marca",Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DataSet Ds = new DataSet();
                Ds = Control.DevolverDato(Convert.ToString(CBMarcas.SelectedValue));
                TxtIdMarca.Text = Convert.ToString(Ds.Tables[0].Rows[0][0]);
                id_marca = Convert.ToInt16(TxtIdMarca.Text);
                CBModelos.Items.Clear();
                Datos.Modelos(CBModelos, id_marca);
            }
         
        }
    }
}
