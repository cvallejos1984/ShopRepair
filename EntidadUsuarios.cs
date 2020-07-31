using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadUsuarios
    {

        private string mUsuario, mContrasena, mNombre, mPuesto;

        public String Usuario
        {
            get
            {
                return mUsuario;
            }
            set
            {
                mUsuario = value;
            }
        }

        public string Contrasena
        {
            get
            {
                return mContrasena;
            }
            set
            {
                mContrasena = value;
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

        public string Puesto
        {
            get
            {
                return mPuesto;
            }
            set
            {
                mPuesto = value;
            }
        }

    }
}
