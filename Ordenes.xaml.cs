using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
using System.Xml;

namespace ShopRepair
{
    /// <summary>
    /// Lógica de interacción para Ordenes.xaml
    /// </summary>
    public partial class Ordenes : Window
    {
        ControlClientes ControlCL = new ControlClientes();
        ControlVeh ControlVeh = new ControlVeh();
        ControlProductos ControlItem = new ControlProductos();
        ControlDocs Control = new ControlDocs();
        BaseDatos Datos = new BaseDatos();
        ControlLineas ControlLin = new ControlLineas();
        decimal Precio = 0;
        int index = 0;
       // int x = 0;
        DataTable DSItems = new DataTable();
        public Ordenes()
        {
            InitializeComponent();
        }
        private void LlenarCliente()
        {
            if (Datos.DatoRepetido("clientes", "cedula", TxtCedula.Text))
            {
                DataSet DS = new DataSet();
                DS = ControlCL.DevolverCliente(TxtCedula.Text);
                TxtCodCliente.Text = Convert.ToString(DS.Tables[0].Rows[0]["id_cliente"]);
                TxtNombre.Text = Convert.ToString(DS.Tables[0].Rows[0]["nombre"]);
                TxtTelefono.Text = Convert.ToString(DS.Tables[0].Rows[0]["telefono1"]);
                LlenarVeh();
            }
            else
            {
                MessageBox.Show("No existen valores para el dato ingresado", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LlenarVeh()
        {
            DataSet DS = new DataSet();
            DS = ControlVeh.DevolverVeh(TxtCodCliente.Text);
            TxtVeh.Text = Convert.ToString(DS.Tables[0].Rows[0]["id_vehiculo"]);
           // TxtPlaca.Text= Convert.ToString(DS.Tables[0].Rows[0]["placa"]);
            TxtMarca.Text= Convert.ToString(DS.Tables[0].Rows[0]["marca"]);
            TxtModelo.Text= Convert.ToString(DS.Tables[0].Rows[0]["modelo"]);
            TxtYear.Text = Convert.ToString(DS.Tables[0].Rows[0]["anno"]);
            Datos.Placas(CbPlaca, TxtCodCliente.Text);
            CbPlaca.Text = Convert.ToString(DS.Tables[0].Rows[0]["placa"]);
        }
        
        private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    LlenarCliente();
            //}
        }

        private void TxtCedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
               if (TxtCedula.Text == "")
                {
                    MessageBox.Show("Debe ingresar un dato", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    LlenarCliente();
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Datos.Items(CB_Items);
        }
        private void CB_Items_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSet Ds = new DataSet();
            Ds = ControlItem.DevolverItem(Convert.ToString(CB_Items.SelectedValue));
            TxtCodigoItem.Text = Convert.ToString(Ds.Tables[0].Rows[0]["id_producto"]);
            Precio = Convert.ToDecimal(Ds.Tables[0].Rows[0]["precio_s_iva"]);
        }
        private void Calculos()
        {
            Decimal Subtotal = Math.Round(Precio * Convert.ToDecimal(TxtCantidad.Text),2);
            Double Mimp = 0.13;
            Decimal IVA = Math.Round(Subtotal * Convert.ToDecimal(Mimp),2);
            Decimal Total = Math.Round(Subtotal + IVA,2);
            TxtSubTotal.Text = Convert.ToString(Subtotal);
            TxtIva.Text = Convert.ToString(IVA);
            TxtTotal.Text = Convert.ToString(Total);
        }
        private void TxtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Calculos();
            }
        }
        private void AgregarCol()
        {
            
            DSItems.Columns.Add("Codigo");
            DSItems.Columns.Add("Descripcion");
            DSItems.Columns.Add("Cantidad");
            DSItems.Columns.Add("Subtotal");
            DSItems.Columns.Add("IVA");
            DSItems.Columns.Add("Total");
        }
        private void AgregarFila()
        {   
          DataRow Row = DSItems.NewRow();
          Row[0] = TxtCodigoItem.Text;
          Row[1] = CB_Items.Text;
          Row[2] = TxtCantidad.Text;
          Row[3] = TxtSubTotal.Text;
          Row[4] = TxtIva.Text;
          Row[5] = TxtTotal.Text;
          DSItems.Rows.Add(Row);                        
          DGItems.ItemsSource = DSItems.DefaultView;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (TxtCantidad.Text=="" | CB_Items.Text == "")
            {
                MessageBox.Show("Debe llenar todos los campos", Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (DSItems.Rows.Count == 0 & DSItems.Columns.Count == 0)
                {
                    AgregarCol();
                    AgregarFila();
                    BtnCrear.IsEnabled = true;
                }
                else
                {
                    AgregarFila();
                    BtnCrear.IsEnabled = true;
                }
            }        
           
        }
        
        private void AceptarEnc()
        {
            EntidadDoc Entidad = new EntidadDoc
            {
                IdOrden = Convert.ToInt16(TxtConsecutivo.Text),
                IdCliente = TxtCodCliente.Text,
                IdVehiculo = TxtVeh.Text,
                Nombre = TxtNombre.Text,
                Cedula= TxtCedula.Text,
                Tel1 = TxtTelefono.Text,
                Placa = CbPlaca.Text,
                Marca = TxtMarca.Text,
                Modelo = TxtModelo.Text,
                Year = TxtYear.Text,
                IdAsc = Convert.ToInt16(TxtDocAsc.Text),
                Tipo = CBTipo.Text
                };
            try
            {
                if (CBTipo.Text == "" | TxtCodCliente.Text == "" | TxtVeh.Text == "" | TxtNombre.Text == "" | TxtCedula.Text == "")
                {
                    MostrarBox();
                    return;
                }
                else
                {
                    if (Datos.DatoRepetido("ordenes", "id_orden", TxtConsecutivo.Text))
                    {
                        Control.Acciones("modificar", Entidad);
                        MostrarBoxAceptar();
                    }
                    else
                    {
                        Control.Acciones("agregar", Entidad);
                        MostrarBoxAceptar();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
        private void MostrarBox()
        {
            MessageBox.Show("Debe llenar todos los datos", Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MostrarBoxAceptar()
        {
            MessageBox.Show("Dato ingresado", Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AceptarEnc();
            LlenarIdOrden();
            LlenarDocAsc();
        }
        private void LlenarIdOrden()
        {
            DataSet DS = new DataSet();
            DS = Control.DevolverDato();
            TxtConsecutivo.Text = Convert.ToString(DS.Tables[0].Rows[0][0]);
        }
        private void LlenarDocAsc()
        {
            DataSet DS = new DataSet();
            DS = Control.DevolverAsc(TxtConsecutivo.Text);
            TxtDocAsc.Text = Convert.ToString(DS.Tables[0].Rows[0][0]);
        }

        private void AceptarLin()
        {
            try
            {
                for (int i = 0; i < DSItems.Rows.Count; i++)
                {
                    DataTable data = new DataTable();
                    data = ((DataView)DSItems.DefaultView).ToTable();
                    EntidadLineas Entidad = new EntidadLineas
                    {
                        IdLinea = i,
                        IdFactura = Convert.ToInt16(TxtConsecutivo.Text),
                        IdProducto = Convert.ToInt16(data.Rows[i]["Codigo"].ToString()),
                        Precio = Math.Round(Precio, 2),
                        IVA = Math.Round(Convert.ToDecimal(data.Rows[i]["IVA"].ToString()), 2),
                        Total = Math.Round(Convert.ToDecimal(data.Rows[i]["Total"].ToString()), 2),
                        IdAsc = Convert.ToInt16(TxtDocAsc.Text),
                        Cantidad = Convert.ToInt16(data.Rows[i]["Cantidad"].ToString()),
                        SubTotal = Math.Round(Convert.ToDecimal(data.Rows[i]["Subtotal"].ToString()), 2)
                    };
                    if (TxtDocAsc.Text == "")
                    {
                        MostrarBox();
                    }
                    else
                    {
                        ControlLin.Acciones("agregar", Entidad);
                    }                   
                }
                MostrarBoxAceptar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnCrear_Click(object sender, RoutedEventArgs e)
        {
            AceptarLin();
        }
        private void DGItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = DGItems.SelectedIndex;
        }
        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {            
            DSItems.Rows.RemoveAt(index);
            DGItems.ItemsSource = DSItems.DefaultView;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.Show();
            this.Hide();
        }

        private void CbPlaca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbPlaca.Text != "")
                {
                    DataSet DS = new DataSet();
                    DS = ControlVeh.DevolverPlaca(Convert.ToString(CbPlaca.SelectedValue));
                    TxtVeh.Text = Convert.ToString(DS.Tables[0].Rows[0]["id_vehiculo"]);
                    TxtMarca.Text = Convert.ToString(DS.Tables[0].Rows[0]["marca"]);
                    TxtModelo.Text = Convert.ToString(DS.Tables[0].Rows[0]["modelo"]);
                    TxtYear.Text = Convert.ToString(DS.Tables[0].Rows[0]["anno"]);
                }
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
    
}
