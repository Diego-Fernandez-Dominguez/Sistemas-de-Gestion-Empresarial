using Data.Database;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryDepartamentos : IRepoDepartamento
    {
        /// <summary>
        /// <description>Actualiza los datos de un departamento existente en la base de datos.</description>
        /// <precondition>El ID del departamento debe existir y el objeto departamento debe contener un nombre válido.</precondition>
        /// <postcondition>Se actualiza el nombre del departamento en la base de datos.</postcondition>
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a actualizar.</param>
        /// <param name="departamento">Objeto con los nuevos datos del departamento.</param>
        /// <returns>Número de filas afectadas en la base de datos.</returns>
        public int actualizarDepartamento(int idDepartamento, clsDepartamento departamento)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", departamento.nombre);
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// <description>Agrega un nuevo departamento a la base de datos.</description>
        /// <precondition>El objeto departamento debe tener un nombre válido.</precondition>
        /// <postcondition>Se inserta un nuevo registro en la tabla de departamentos.</postcondition>
        /// </summary>
        /// <param name="departamentoNuevo">Departamento a agregar.</param>
        /// <returns>Número de filas afectadas en la base de datos (debería ser 1 si se insertó correctamente).</returns>
        public int añadirDepartamento(clsDepartamento departamentoNuevo)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "INSERT INTO Departamentos (Nombre) VALUES (@Nombre)";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", departamentoNuevo.nombre);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// <description>Elimina un departamento de la base de datos por su ID.</description>
        /// <precondition>El ID del departamento debe existir y no tener restricciones que impidan la eliminación.</precondition>
        /// <postcondition>Se elimina el registro del departamento de la base de datos.</postcondition>
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a eliminar.</param>
        /// <returns>Número de filas afectadas en la base de datos (debería ser 1 si se eliminó correctamente).</returns>
        public int eliminarDepartamento(int idDepartamento)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "DELETE FROM Departamentos WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        filasAfectadas = miComando.ExecuteNonQuery();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return filasAfectadas;
        }

        /// <summary>
        /// <description>Obtiene un departamento específico de la base de datos por su ID.</description>
        /// <precondition>El ID del departamento debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve el departamento correspondiente si existe; en caso contrario, devuelve null.</postcondition>
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a consultar.</param>
        /// <returns>Objeto clsDepartamento correspondiente al ID o null si no se encuentra.</returns>
        public clsDepartamento getDepartamentoPorID(int idDepartamento)
        {
            clsDepartamento oDepartamento = null;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT * FROM Departamentos WHERE ID = @ID";
                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                oDepartamento = new clsDepartamento((int)miLector["ID"], (string)miLector["Nombre"]);
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return oDepartamento;
        }

        /// <summary>
        /// <description>Obtiene la lista completa de departamentos de la base de datos.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve todos los departamentos existentes en la tabla Departamentos.</postcondition>
        /// </summary>
        /// <returns>Lista de departamentos.</returns>
        public List<clsDepartamento> getListaDepartamentos()
        {
            SqlConnection miConexion = new SqlConnection();
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector = null;
            clsDepartamento oDepartamento;

            miConexion.ConnectionString
            = ("server=dferdom.database.windows.net;database=PersonasDB;uid=prueba;pwd=123abc|@#;trustServerCertificate = true;");

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Departamentos";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oDepartamento = new clsDepartamento((int)miLector["ID"], (string)miLector["Nombre"]);
                        listadoDepartamentos.Add(oDepartamento);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoDepartamentos.ToList();
        }
    }
}
