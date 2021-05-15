using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace serg.Clases.BaseDatos
{
    public class ClsConecxion
    {
        public MySqlConnection conexion;
        private String _conexion { get; }

        public ClsConecxion()
        {

            _conexion = "Server=localhost;Database=alumnos; Port=3306; Username=root; Password=SoyAgente2341;";

        }



        /// <summary>
        ///cerrar
        /// </summary>
        public void cerrarConexionBD()
        {
            conexion.Close();
        }



        /// <summary>
        /// abrir
        /// </summary>
        public void abrirConexion()
        {
            conexion = new MySqlConnection(_conexion);
            conexion.Open();
        }




        /// <summary>
        ///  clausura a la base de datos
        /// </summary>
        /// <param name="sqll"></param>
        /// <returns></returns>
        public DataTable consultaTablaDirecta(String sqll)
        {
            abrirConexion();
            MySqlDataReader dr;
            MySqlCommand comm = new MySqlCommand(sqll, conexion);
            dr = comm.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(dr);
            cerrarConexionBD();
            return dataTable;
        }



        /// <summary>
        /// ejecuta una instrucción de insersion, eliminación y actualización,
        /// 
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaSQLDirecto(String sqll)
        {
            abrirConexion();
            try
            {

                MySqlCommand comm = new MySqlCommand(sqll, conexion);
                comm.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                cerrarConexionBD();
            }



        }

        /// <summary>
        /// ejecuta instrucciones SQL
        /// 
        /// </summary>
        /// <param name="sqll"></param>
        public void EjecutaSQLManual(String sqll)
        {
            // se abre y cierra la conecxion
            MySqlCommand comm = new MySqlCommand(sqll, conexion);
            comm.ExecuteReader();
        }
    }
}