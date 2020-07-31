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
    /// Lógica de interacción para Marcas_y_Modelos.xaml
    /// </summary>
    public partial class Marcas_y_Modelos : Window
    {
        BaseDatos Datos = new BaseDatos();
        ControlMarcMod Control = new ControlMarcMod();
        int id_marca = 0;
        public Marcas_y_Modelos()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet Ds = new DataSet();
            Ds = Control.DevolverDato(Convert.ToString(CBMarcas.SelectedValue));
            TxtIdMarca.Text = Convert.ToString(Ds.Tables[0].Rows[0][0]);
            id_marca = Convert.ToInt16(TxtIdMarca.Text);
            CBModelos.Items.Clear();
            Datos.Modelos(CBModelos, id_marca);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Datos.Marcas(CBMarcas);
        }

        private void AceptarMarca()
        {
            EntidadMarcas Entidad = new EntidadMarcas
            {
                IdMarca = Convert.ToInt16(TxtIdMarca.Text),
                Marca = TxtMarca.Text
            
            };

            if (TxtMarca.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("Marcas", "id_marca", TxtIdMarca.Text))
                {
                    Control.AccionesMarcas("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdMarca.Text = "";
                    TxtMarca.Text = "";
                   
                }
                else
                {
                    Control.AccionesMarcas("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdMarca.Text = "";
                    TxtMarca.Text = "";
                }

            }

            

        }
        private void AceptarModelo()
        {
            EntidadModelos Entidad = new EntidadModelos
            {
                IdModelo = Convert.ToInt16(TxtIdModelo.Text),
                Modelo = TxtModelo.Text,
                IdMarca = Convert.ToInt16(TxtIdMarca.Text)              
            };

            if (TxtIdMarca.Text == "" | TxtModelo.Text == "" | CBMarcas.Text == "")
            {
                MostrarBox();
            }
            else
            {
                if (Datos.DatoRepetido("Modelos", "id_modelo", TxtIdModelo.Text))
                {
                    Control.AccionesModelos("modificar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdModelo.Text = "";
                    TxtModelo.Text = "Ingrese Nuevo Modelo";
                 
                }
                else
                {
                    Control.AccionesModelos("agregar", Entidad);
                    MostrarBoxAceptar();
                    TxtIdModelo.Text = "";
                    TxtModelo.Text = "Ingrese Nuevo Modelo";
                }

            }

            
        }
        //private void LlenarGrid()
        //{
        //    DataSet DSU = new DataSet();
        //    DSU = Control.DevolverDatos();
        //    GRUsuarios.ItemsSource = DSU.Tables[0].DefaultView;
        //}

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
            AceptarMarca();
            CBMarcas.Items.Clear();
            Datos.Marcas(CBMarcas);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AceptarModelo();
            CBModelos.Items.Clear();
            Datos.Modelos(CBModelos, id_marca);
        }

        private void TxtMarca_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TxtMarca.Text = "";
            TxtIdMarca.Text = "0";
        }

        private void TxtModelo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TxtIdModelo.Text = "0";
            TxtModelo.Text = "";
        }



        //private void TxtMarca_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    TxtMarca.Text = "";
        //    TxtIdMarca.Text = "0";
        //}
    }
}
