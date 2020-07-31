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
                        sql = " insert into public.vehiculos(id_marca, id_modelo,marca,modelo, placa,anno,id_cliente) values ('" + Entidad.IdMarca + "','" + Entidad.IdModelo + "','" + Entidad.Marca + "','" + Entidad.Modelo + "','" + Entidad.Placa + "','" + Entidad.Anno + "','"+ Entidad.IdCliente+"');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.vehiculos set id_marca = '" + Entidad.IdMarca + "', id_modelo = '" + Entidad.IdModelo + "',marca= '" + Entidad.Marca + "',modelo = '" + Entidad.Modelo + "',placa = '" + Entidad.Placa + "',anno = '" + Entidad.Anno + "', id_cliente = '"+Entidad.IdCliente+"' where id_vehiculo = '" + Entidad.IdVehiculo + "'";
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
            string sql = "Select id_vehiculo as Vehiculo,id_marca as Codigo_Marca,id_modelo as Codigo_Modelo, marca as Marca, modelo as Modelo,placa as Placa,anno as Año,id_cliente as Codigo_Cliente from vehiculos";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverVeh(string dato)
        {
            string sql = "Select * from vehiculos where id_cliente = '" + dato + "' ";
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
