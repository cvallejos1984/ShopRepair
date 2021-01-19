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
    /// Lógica de interacción para Reportes.xaml
    /// </summary>
    public partial class Reportes : Window
    {
        ControlDocs Control = new ControlDocs();
        public Reportes()
        {
            InitializeComponent();
        }
        
        private void LlenarDG()
        {
            DataTable DS = new DataTable();
            DS = Control.DevolverOrdenes(TxtFiltro.Text);

        }
    }
}
