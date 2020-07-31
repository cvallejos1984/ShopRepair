using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class ControlUsuarios
    {
        BaseDatos BaseDatos = new BaseDatos();

        public void Acciones(string Accion, EntidadUsuarios Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.usuarios(usuario, nombre, contrasenna, puesto) values ('" + Entidad.Usuario + "','" + Entidad.Nombre + "','" + Entidad.Contrasena + "','" + Entidad.Puesto + "');";
 
        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.usuarios set nombre = '" + Entidad.Nombre + "', contrasenna = '" + Entidad.Contrasena + "',puesto = '" + Entidad.Puesto + "' where usuario = '" + Entidad.Usuario + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.usuarios where usuario = '" + Entidad.Usuario + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverDatos()
        {
            string sql = "Select usuario as Usuario,nombre as Nombre,puesto as Puesto from usuarios";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

    }
}
