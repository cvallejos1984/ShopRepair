using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ShopRepair
{
    class ControlMarcMod
    {
        BaseDatos BaseDatos = new BaseDatos();

        public void AccionesMarcas(string Accion, EntidadMarcas Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.marcas(marca) values ('" + Entidad.Marca + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.marcas set marca = '" + Entidad.Marca + "' where id_marca = '" + Entidad.IdMarca + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.marcas where id_marca = '" + Entidad.IdMarca + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }

        public void AccionesModelos(string Accion, EntidadModelos Entidad)
        {
            string sql;
            switch (Accion)
            {
                case "agregar":
                    {
                        sql = " insert into public.modelos(id_marca,modelo) values ('" + Entidad.IdMarca + "','" + Entidad.Modelo + "');";

                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                case "modificar":
                    {
                        sql = " update public.modelos set id_marca = '" + Entidad.IdMarca + "', modelo = '" + Entidad.Modelo + "' where id_modelo = '" + Entidad.IdModelo + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }

                case "eliminar":
                    {
                        sql = "delete from public.modelos where id_modelo = '" + Entidad.IdModelo + "'";
                        BaseDatos.EjecutarSQL(sql);
                        break;
                    }
                default:
                    break;
            }
        }
        public DataSet DevolverMarcas()
        {
            string sql = "Select * from marcas";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverModelos()
        {
            string sql = "Select * from modelos";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverDato(string marca)
        {
            string sql = "Select id_marca from marcas where marca = '"+marca+"' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }

        public DataSet DevolverIdModelo(string modelo)
        {
            string sql = "Select id_modelo from modelos where modelo = '" + modelo + "' ";
            DataSet DS = new DataSet();
            DS = BaseDatos.LlenarDS(sql);
            return DS;
        }


    }

}
