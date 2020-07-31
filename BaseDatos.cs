using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Npgsql;

namespace ShopRepair
{
    class BaseDatos
    {
        public NpgsqlConnection DB = new NpgsqlConnection();
        public NpgsqlDataReader DR;
        public NpgsqlCommand CMD;
           

        public void ConectarDB()
        {
            string cadenaconexion = "Username=postgres;Password= Aledezma;Host=localhost;Port =5432; DataBase=shop";

            DB.ConnectionString = cadenaconexion;
            DB.Open();
        }
        public void DesconectarDB()
        {
            DB.Close();
        }
        public void EjecutarSQL(string sql)
        {
            ConectarDB();
            NpgsqlCommand Comando = new NpgsqlCommand(sql, DB);
            Comando.ExecuteNonQuery();
            DesconectarDB();
        }


        public DataSet LlenarDS(string sql)
        {
            ConectarDB();
            DataSet DS = new DataSet();
            NpgsqlDataAdapter Adaptador = new NpgsqlDataAdapter(sql, DB);
            Adaptador.Fill(DS);
            DesconectarDB();
            return DS;
        }

        public DataSet LlenarCH(string sql)
        {
            ConectarDB();
            DataSet DS = new DataSet();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, DB);
            cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter Adaptador = new NpgsqlDataAdapter(cmd);
            Adaptador.Fill(DS);
            DesconectarDB();
            return DS;
        }


        public Boolean DatoRepetido(string Tabla, string Campo, string Valor)
        {
            DataSet DS;
            string sql;
            sql = " select * from " + Tabla + " where " + Campo + " = '" + Valor + "'";
            DS = LlenarDS(sql);
            if (DS.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public void LlenarItems(ComboBox cb, string Marca)
        //{
        //    ConectarDB();
        //    OleDbCommand Comando = new OleDbCommand("Select * from BCIs where Marca = '" + Marca + "'", DB);
        //    dr = Comando.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        Convert.ToString(cb.Items.Add(dr["BCI"]));
        //    }
        //    dr.Close();
        //    DesconectarDB();
        //}

        public void Marcas(ComboBox cb)
        {
            ConectarDB();
            NpgsqlCommand Comando = new NpgsqlCommand("Select * from marcas", DB);
            DR= Comando.ExecuteReader();
            while (DR.Read())
            {
                Convert.ToString(cb.Items.Add(DR["marca"]));
            }
            DR.Close();
            DesconectarDB();
        }

        public void Modelos(ComboBox cb, int marca)
        {
            ConectarDB();
            NpgsqlCommand Comando = new NpgsqlCommand("Select * from modelos where id_marca = '"+ marca +"'", DB);
            DR = Comando.ExecuteReader();
            while (DR.Read())
            {
                Convert.ToString(cb.Items.Add(DR["modelo"]));
            }
            DR.Close();
            DesconectarDB();
        }

        public void Items(ComboBox cb)
        {
            ConectarDB();
            NpgsqlCommand Comando = new NpgsqlCommand("Select descripcion from productos", DB);
            DR = Comando.ExecuteReader();
            while (DR.Read())
            {
                Convert.ToString(cb.Items.Add(DR["descripcion"]));
            }
            DR.Close();
            DesconectarDB();
        }
        public void Placas(ComboBox cb,string cliente)
        {
            ConectarDB();
            NpgsqlCommand Comando = new NpgsqlCommand("Select placa from vehiculos where id_cliente = '"+ cliente +"'", DB);
            DR = Comando.ExecuteReader();
            while (DR.Read())
            {
                Convert.ToString(cb.Items.Add(DR["placa"]));
            }
            DR.Close();
            DesconectarDB();
        }
    }

}
