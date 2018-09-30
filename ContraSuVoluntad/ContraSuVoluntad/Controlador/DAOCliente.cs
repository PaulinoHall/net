using System;
using System.Collections.Generic;

using System.Data.OracleClient; //Primer intento oracle
using Modelo;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class DAOCliente
    {
        //variable oracle

        //Nombre base de datos: funeraria, aun no creada en sql developer

        private OracleConnection conn;

        public DAOCliente()
        {
            conn = new Conexion().obtenerConexion(); //inicia conexion
        }

     

        public bool guardar(Cliente cli)
        {
            try
            {
                string orcl = string.Format("insert into funeraria values ('{0}','{1}','{2}','{3}', '{4}','{5}', '{6}','{7}')",
                                             cli.Rut, cli.Nombre, cli.Telefono, cli.Direccion, cli.Edad, cli.TipoContrato, cli.CantidadCuotas, cli.Adicionales);

                OracleCommand cmd = new OracleCommand(orcl, conn); //Prepara consulta, aparece obsoleto*

                conn.Open();
                // abre conexion

                int cantidadFilas = cmd.ExecuteNonQuery(); //ejecuta consulta

                conn.Close();

                return cantidadFilas > 0; //retorna true si inserto.

            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        public List<Cliente> listar()
        {
            try
            {
                List<Cliente> lista = new List<Cliente>();
                string orcl = "select * from funeraria";

                OracleCommand cmd = new OracleCommand(orcl, conn);

                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente();

                    cli.Rut = Convert.ToString(reader["rut"]);
                    cli.Nombre = Convert.ToString(reader["nombre"]);
                    cli.Telefono = Convert.ToInt32(reader["telefono"]);
                    cli.Direccion = Convert.ToString(reader["direccion"]);
                    cli.Edad = Convert.ToInt32(reader["edad"]);
                    //cli.TipoContrato = Convert.ToString(reader["tipocontrato"]); //Falta convertir a tipo contrato
                    cli.CantidadCuotas = Convert.ToInt32(reader["cantidadcuotas"]);
                    cli.Adicionales = Convert.ToString(reader["adicionales"]);

                    lista.Add(cli); //agrega

                }

                conn.Close();

                return lista;
            }
            catch (Exception ex )
            {

                conn.Close();
                return null;
            }
        }

        public Cliente buscar(string rut)
        {
            try
            {
                Cliente cli = new Cliente(); //cliente en blanco

                string orcl = string.Format("select * from funeraria where rut = {0}",rut);

                OracleCommand cmd = new OracleCommand(orcl, conn);

                conn.Open();

                OracleDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    Cliente cli = new Cliente();

                    cli.Rut = Convert.ToString(reader["rut"]);
                    cli.Nombre = Convert.ToString(reader["nombre"]);
                    cli.Telefono = Convert.ToInt32(reader["telefono"]);
                    cli.Direccion = Convert.ToString(reader["direccion"]);
                    cli.Edad = Convert.ToInt32(reader["edad"]);
                    //cli.TipoContrato = Convert.ToString(reader["tipocontrato"]); //Falta convertir a tipo contrato
                    cli.CantidadCuotas = Convert.ToInt32(reader["cantidadcuotas"]);
                    cli.Adicionales = Convert.ToString(reader["adicionales"]);

                }

                conn.Close();
                return cli; //retorna el cliente


            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }
        }

        public bool eliminar(string rut)
        {
            try
            {
                string orcl = string.Format("delete from funeraria where rut = {0}",rut);

                OracleCommand cmd = new OracleCommand(orcl, conn);

                conn.Open();

                int cantidadFilas = cmd.ExecuteNonQuery();

                conn.Close();

                return cantidadFilas > 0;

            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        public bool modificar(Cliente cli)
        {
            try
            {
                string orcl = string.Format("insert into funeraria values ('{0}','{1}','{2}','{3}', '{4}','{5}', '{6}','{7}')",
                                             cli.Rut, cli.Nombre, cli.Telefono, cli.Direccion, cli.Edad, cli.TipoContrato, cli.CantidadCuotas, cli.Adicionales);

                OracleCommand cmd = new OracleCommand(orcl, conn); //Prepara consulta, aparece obsoleto*

                conn.Open();
                // abre conexion

                int cantidadFilas = cmd.ExecuteNonQuery(); //ejecuta consulta

                conn.Close();

                return cantidadFilas > 0; //retorna true si inserto.

            }
            catch (Exception)
            {
                conn.Close();
                return false;
            }
        }

    }
}
