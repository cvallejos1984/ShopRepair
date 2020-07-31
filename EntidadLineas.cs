using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadLineas
    {
        private int mIdLinea,mIdFactura, mIdProducto, mCantidad,mIdAsc;
        private decimal mPrecio, mIVA,mTotal,mSubTotal;
        private string mPago;

        public string Pago
        {
            get
            {
                return mPago;
            }
            set
            {
                mPago = value;
            }
        }
        public int IdLinea
        {
            get
            {
                return mIdLinea;
            }
            set
            {
                mIdLinea = value;
            }
        }
        public int IdAsc
        {
            get
            {
                return mIdAsc;
            }
            set
            {
                mIdAsc = value;
            }
        }
        public int IdFactura
        {
            get
            {
                return mIdFactura;
            }
            set
            {
                mIdFactura = value;
            }
        }
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
        public int Cantidad
        {
            get
            {
                return mCantidad;
            }
            set
            {
                mCantidad = value;
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
        public decimal IVA
        {
            get
            {
                return mIVA;
            }
            set
            {
                mIVA = value;
            }
        }
        public decimal Total
        {
            get
            {
                return mTotal;
            }
            set
            {
                mTotal = value;
            }
        }
        public decimal SubTotal
        {
            get
            {
                return mSubTotal;
            }
            set
            {
                mSubTotal = value;
            }
        }
    }
}
