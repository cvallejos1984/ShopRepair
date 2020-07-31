using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ShopRepair
{
    class EntidadProductos
    {

        private string mTipo, mDescripcion;
        private int mIdProducto;
        private decimal mCosto, mPrecio;

        public int IdProducto
        {
            get
            {
                return mIdProducto;
            }
            set
            {
                mIdProducto = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return mDescripcion;
            }
            set
            {
                mDescripcion = value;
            }
        }
        public string Tipo
        {
            get
            {
                return mTipo;
            }
            set
            {
               mTipo = value;
            }
        }

        public decimal Costo
        {
            get
            {
                return mCosto;
            }
            set
            {
                mCosto = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return mPrecio;
            }
            set
            {
                mPrecio = value;
            }
        }
      
    }
}
