using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace ShopRepair
{
    class ControlClientes
    {
        BaseDatos BaseDatos = new BaseDatos();

        public void Acciones(string Accion, EntidadClientes Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.clientes(cedula, nombre, telefono1,telefono2,telefono3, correo,direccion,tipo) values ('" + Entidad.Cedula + "','" + Entidad.Nombre + "','" + Entidad.Telefono1 + "','" + Entidad.Telefono2 + "','" + Entidad.Telefono3 + "','" + Entidad.Correo + "','" + Entidad.Direccion + "','" + Entidad.Tipo + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.clientes set cedula = '" + Entidad.Cedula + "', nombre = '" + Entidad.Nombre + "',telefono1= '" + Entidad.Telefono1 + "',telefono2 = '" + Entidad.Telefono2 + "',telefono3 = '" + Entidad.Telefono3 + "',correo = '" + Entidad.Correo + "',direccion = '" + Entidad.Direccion + "',tipo = '" + Entidad.Tipo + "'  where id_cliente = '" + Entidad.IdCliente + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.clientes where id_cliente = '" + Entidad.IdCliente + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverDatos()
        {
            string sql = "Select * from clientes";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverCliente(string cedula)
        {
            string sql = "Select * from clientes where cedula = '"+ cedula +"' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverDato(string filtro)
        {
            string sql = "Select * from clientes where cedula like '%" + filtro + "%' or nombre like '%"+ filtro +"%' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
    }

}
