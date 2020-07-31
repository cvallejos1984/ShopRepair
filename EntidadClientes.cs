using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class EntidadClientes
    {
        private string mCedula, mNombre, mTelefono1, mTelefono2,mTelefono3,mCorreo,mDireccion,mTipo;
        private int mIdCliente;

        public int IdCliente
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

        public string Telefono1
        {
            get
            {
                return mTelefono1;
            }
            set
            {
                mTelefono1 = value;
            }
        }
        public string Telefono2
        {
            get
            {
                return mTelefono2;
            }
            set
            {
                mTelefono2 = value;
            }
        }
        public string Telefono3
        {
            get
            {
                return mTelefono3;
            }
            set
            {
                mTelefono3 = value;
            }
        }
        public string Correo
        {
            get
            {
                return mCorreo;
            }
            set
            {
                mCorreo = value;
            }
        }
        public string Direccion
        {
            get
            {
                return mDireccion;
            }
            set
            {
                mDireccion = value;
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
       

    }
}
