using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadVeh
    {
        private string mIdMarca, mIdModelo, mMarca, mModelo, mPlaca, mAnno,mIdCliente;
        private int mIdVehiculo;

        public int IdVehiculo
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
        public string IdMarca
        {
            get
            {
                return mIdMarca;
            }
            set
            {
                mIdMarca = value;
            }
        }
        public string IdModelo
        {
            get
            {
                return mIdModelo;
            }
            set
            {
                mIdModelo = value;
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
        public string Anno
        {
            get
            {
                return mAnno;
            }
            set
            {
                mAnno = value;
            }
        }

        public string IdCliente
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



    }

}
