using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class ControlVeh
    {
        BaseDatos BaseDatos = new BaseDatos();

        public void Acciones(string Accion, EntidadVeh Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.vehiculos(id_mar, id_mod,marca,modelo, placa,anno,client) values ('" + Entidad.IdMarca + "','" + Entidad.IdModelo + "','" + Entidad.Marca + "','" + Entidad.Modelo + "','" + Entidad.Placa + "','" + Entidad.Anno + "','"+ Entidad.IdCliente+"');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.vehiculos set id_mar = '" + Entidad.IdMarca + "', id_mod = '" + Entidad.IdModelo + "',marca= '" + Entidad.Marca + "',modelo = '" + Entidad.Modelo + "',placa = '" + Entidad.Placa + "',anno = '" + Entidad.Anno + "', client = '"+Entidad.IdCliente+"' where id_vehiculo = '" + Entidad.IdVehiculo + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.vehiculos where id_vehiculo = '" + Entidad.IdVehiculo + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverDatos()
        {
            string sql = "Select id_vehiculo as Vehiculo,id_mar as Codigo_Marca,id_mod as Codigo_Modelo, marca as Marca, modelo as Modelo,placa as Placa,anno as Año,client as Codigo_Cliente from vehiculos";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverVeh(string dato)
        {
            string sql = "Select * from vehiculos where client = '" + dato + "' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverPlaca(string dato)
        {
            string sql = "Select * from vehiculos where placa = '" + dato + "' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
    }

}
