using P1Acrud.Clases.Archivos;
using P1Acrud.Clases.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace P1Acrud
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void CargarArchivoExterno()
        {
            string Fuente = ((@"C:\Users\anner\Desktop\crudDB.csv"));
            ClsArchivos ar = new ClsArchivos();
            //obtener todo el archivo linea por linea dentro de un arreglo simple--unidimensional
            string[] ArregloNotas = ar.LeerArchivo(Fuente);
            string sentencia_sql = "";
            int NumeroLinea = 0;

            ClsConecxion cn = new ClsConecxion();
            foreach (string linea in ArregloNotas)
            {
                //obteniendo datos
                string[] datos = linea.Split(';');
                if(NumeroLinea > 0)
                {
                    sentencia_sql += $"INSERT INTO tb_alumnos values(" + datos[0] + ", '" + datos[1] + "', " + datos[2] + ", " + datos[3] + ", " + datos[4] + ", " + datos[5] + ", '" + datos[6] + "'\n);";
                }
                NumeroLinea++;
            }
            cn.EjecutaSQLDirecto(sentencia_sql);
        }


        protected void SubirInformacion_Click(object sender, EventArgs e)
        {
                CargarArchivoExterno();
        }
    }
}