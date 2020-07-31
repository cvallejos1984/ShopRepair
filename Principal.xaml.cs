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

namespace ShopRepair
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.Show();
        }

        private void BtnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            Usuarios frm = new Usuarios();
            frm.Show();
        }

        private void BtnVehiculos_Click(object sender, RoutedEventArgs e)
        {
            Vehiculos frm = new Vehiculos();
            frm.Show();
        }

        private void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            Producto frm = new Producto();
            frm.Show();
        }

        private void BtnOrdenes_Click(object sender, RoutedEventArgs e)
        {
            Ordenes frm = new Ordenes();
            frm.Show();
        }
    }
}
