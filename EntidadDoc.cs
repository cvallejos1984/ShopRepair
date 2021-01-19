using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadDoc
    {
        private string  mIdCliente, mIdProducto, mIdVehiculo, mNombre, mCedula, mTel1, mPlaca, mMarca, mModelo, mYear, mTipo,mfecha;
        private int mIdOrden,mIdAsc;

        public string  IdCliente
        {
            get
            {
                return mIdCliente;
            }
            set
            {
                mIdCliente = value;
            }
        }

        public string fecha
        {
            get
            {
                return mfecha;
            }
            set
            {
                mfecha = value;
            }
        }
        public string IdProducto
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
        public string IdVehiculo
        {
            get
            {
                return mIdVehiculo;
            }
            set
            {
                mIdVehiculo = value;
            }
        }
        public string Nombre
        {
            get
            {
                return mNombre;
            }
            set
            {
                mNombre = value;
            }
        }
        public string Cedula
        {
            get
            {
                return mCedula;
            }
            set
            {
                mCedula = value;
            }
        }
        public string Tel1
        {
            get
            {
                return mTel1;
            }
            set
            {
                mTel1 = value;
            }
        }
        public string Placa
        {
            get
            {
                return mPlaca;
            }
            set
            {
                mPlaca = value;
            }
        }
        public string Marca
        {
            get
            {
                return mMarca;
            }
            set
            {
                mMarca = value;
            }
        }
        public string Modelo
        {
            get
            {
                return mModelo;
            }
            set
            {
                mModelo = value;
            }
        }
        public string Year
        {
            get
            {
                return mYear;
            }
            set
            {
                mYear = value;
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
        public int IdOrden
        {
            get
            {
                return mIdOrden;
            }
            set
            {
                mIdOrden = value;
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



    }
}
