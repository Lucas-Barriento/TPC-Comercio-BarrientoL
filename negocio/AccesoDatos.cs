using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    
    public class AccesoDatos//clase
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Lector;
        public SqlDataReader LectorSql
        {
            get { return Lector; }
        }

        public AccesoDatos()//funcion
        {
            //configura la conexion con la DB
            Conexion = new SqlConnection("server = .\\SQLEXPRESS; database = COMERCIO_DB; integrated security = true");
            Comando = new SqlCommand();
        }
            
        //se hace la consulta sql
        public void SetConsulta(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }
        public void setProcedimiento(string procedimiento)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = procedimiento;
        }
        //Ejecuta la lectura y carga el lector (objeto)
        public void ejecutarLectura()
        {
            Comando.Connection = Conexion;

            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery(); //ejecucion  de no consulta (insert,update)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetParametros(string nombre, object valor)//sirve para agregar parametros al comando, recibe el nombre de la variable y el objeto
        {
            Comando.Parameters.AddWithValue(nombre, valor);
            
        }

        public void cerrarConexion()
        {
            if (Lector != null)
            {
                Lector.Close();
            }
            Conexion.Close();
        }
    }
   
}
