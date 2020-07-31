using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadMarcas
    {
        private int mIdMarca;
        private string mMarca;

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
    }
}
