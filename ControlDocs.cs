using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class ControlDocs
    {
        BaseDatos BaseDatos = new BaseDatos();
        public void Acciones(string Accion, EntidadDoc Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.ordenes(id_cliente, id_vehiculo, nombre,cedula,telefono1, placa,marca,modelo,year,tipo) values ('" + Entidad.IdCliente + "','" + Entidad.IdVehiculo + "','" + Entidad.Nombre + "','" + Entidad.Cedula + "','" + Entidad.Tel1 + "','" + Entidad.Placa + "','" + Entidad.Marca + "','" + Entidad.Modelo + "','" + Entidad.Year + "','" + Entidad.Tipo + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.ordenes set id_cliente = '" + Entidad.IdCliente + "', id_vehiculo = '" + Entidad.IdVehiculo + "',nombre = '" + Entidad.Nombre + "',cedula = '" + Entidad.Cedula + "',telefono1 = '" + Entidad.Tel1 + "',placa = '" + Entidad.Placa + "',marca = '" + Entidad.Marca + "',modelo = '" + Entidad.Modelo + "',year = '" + Entidad.Year + "',id_asociado = '"+Entidad.IdAsc+"',tipo = '"+ Entidad.Tipo +"'  where id_orden = '" + Entidad.IdOrden + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.ordenes where id_orden = '" + Entidad.IdOrden + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverDatos()
        {
            string sql = "Select * from ordenes";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
        public DataSet DevolverAsc(string dato)
        {
            string sql = "Select id_asociado from ordenes where id_orden = '" + dato + "' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
        public DataSet DevolverDato()
        {
            string sql = "Select max(id_orden) from ordenes ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
    }
}
