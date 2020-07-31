using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadModelos
    {
        private int mIdModelo, mIdMarca;
        private string mModelo;

        public int IdModelo
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

        public int IdMarca
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
    }
}
