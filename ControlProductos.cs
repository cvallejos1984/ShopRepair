using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ShopRepair
{
    class ControlProductos
    {
        BaseDatos BaseDatos = new BaseDatos();
        public void Acciones(string Accion, EntidadProductos Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.productos(tipo,descripcion,precio_s_iva,costo) values ('" + Entidad.Tipo + "','" + Entidad.Descripcion + "','" + Entidad.Precio + "','" + Entidad.Costo + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.productos set tipo = '" + Entidad.Tipo + "', descripcion = '" + Entidad.Descripcion + "',precio_s_iva = '" + Entidad.Precio + "',costo = '" + Entidad.Costo + "' where id_producto = '" + Entidad.IdProducto + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.productos where id_producto = '" + Entidad.IdProducto + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }      
        public DataSet DevolverDatos()
        {
            string sql = "Select id_producto as producto, tipo,descripcion,precio_s_iva as precio,costo from productos";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
        public DataSet DevolverItem(string desc)
        {
            string sql = "Select * from productos where descripcion = '"+ desc +"'";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverPrecio(string desc)
        {
            string sql = "Select precio from productos where id_producto = '" + desc + "'";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
    }
}

