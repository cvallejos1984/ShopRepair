﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepair
{
    class ControlLineas
    {
        BaseDatos BaseDatos = new BaseDatos();
        public void Acciones(string Accion, EntidadLineas Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.lineas(id_factura, producto,precio,iva, total_pagar,num_asociado,cantidad,subtotal,medio_pago,linea) values ('" + Entidad.IdFactura + "','" + Entidad.IdProducto + "','" + Entidad.Precio + "','" + Entidad.IVA + "','" + Entidad.Total + "','" + Entidad.IdAsc + "','" + Entidad.Cantidad + "','" + Entidad.SubTotal + "','" + Entidad.Pago + "','" + Entidad.IdLinea + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.lineas set id_factura = '" + Entidad.IdFactura + "', producto = '" + Entidad.IdProducto + "',precio_s_iva = '" + Entidad.Precio + "',iva = '" + Entidad.IVA + "',total_pagar = '" + Entidad.Total + "',cantidad = '" + Entidad.Cantidad + "',subtotal = '" + Entidad.SubTotal + "',medio_pago = '" + Entidad.Pago + "' where id_linea = '" + Entidad.IdLinea + "' and num_asociado = '"+Entidad.IdAsc+"'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.lineas where id = '" + Entidad.IdLinea + "' and num_asociado = '" + Entidad.IdAsc + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverDatos()
        {
            string sql = "Select * from lineas";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
        public DataSet DevolverAsc(string dato)
        {
            string sql = "Select num_asociado from lineas where id_factura = '" + dato + "' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
        public DataSet DevolverDato()
        {
            string sql = "Select max(id) from lineas ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }
    }
}
