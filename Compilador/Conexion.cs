using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Compilador
{
    class Conexion//clas que se encarga de la conexion
    {
        SqlConnection sqlConexion;
        public Conexion()
        {
            try
            {
                //Establese la conexion con la base de los datos
                sqlConexion = new SqlConnection("Data Source=LAPTOP-AG1ARPMU;Initial Catalog=Automatas2;User ID=Roberto;Password=mario120");
                sqlConexion.Open();

                MessageBox.Show("Conexion correcta");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public DataTable Consulta()
        {
            try
            {
                string strQuery = "SELECT * FROM LSCRIPTMXautomatas2";//consulta a la matriz 
                SqlCommand cmd = new SqlCommand(strQuery, sqlConexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);//ejecuta la consulta 
                DataTable dt = new DataTable();
                da.Fill(dt);//llena el DataTable con los resultados de la consulta
                return dt;
            }catch(Exception ex)
            {
                MessageBox.Show("Error al ejecutar consulta: " + ex.Message);
                return null;
            }

        }

         

    }
}
