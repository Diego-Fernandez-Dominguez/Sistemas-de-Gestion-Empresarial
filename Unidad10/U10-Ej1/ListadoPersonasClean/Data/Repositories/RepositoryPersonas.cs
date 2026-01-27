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
    public class RepositoryPersonas : IRepoPersona
    {
        /// <summary>
        /// <description>Obtiene la lista completa de personas en la base de datos.</description>
        /// <precondition>Ninguna</precondition>
        /// <postcondition>Devuelve todas las personas registradas en la tabla Personas.</postcondition>
        /// </summary>
        /// <returns>Lista de personas.</returns>
        public List<clsPersona> getListaPersonas()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona oPersona;

            SqlConnection miConexion = new SqlConnection(Connection.getConnectionString());

            try
            {
                miConexion.Open();
                miComando.CommandText = "SELECT * FROM Personas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.id = (int)miLector["ID"];
                        oPersona.nombre = (string)miLector["Nombre"];
                        oPersona.apellido = (string)miLector["Apellidos"];
                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                        }
                        oPersona.direccion = (string)miLector["Direccion"];
                        oPersona.telefono = (string)miLector["Telefono"];
                        oPersona.imagen = (string)miLector["Foto"];
                        oPersona.idDepartamento = (int)miLector["IDDepartamento"];
                        listadoPersonas.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }

        /// <summary>
        /// <description>Actualiza los datos de una persona existente en la base de datos.</description>
        /// <precondition>El ID de la persona debe existir y el objeto persona debe contener datos válidos.</precondition>
        /// <postcondition>Se actualizan los campos de la persona en la base de datos.</postcondition>
        /// </summary>
        /// <param name="idPersona">ID de la persona a actualizar.</param>
        /// <param name="persona">Objeto con los nuevos datos de la persona.</param>
        /// <returns>Número de filas afectadas en la base de datos.</returns>
        public int actualizarPersona(int idPersona, clsPersona persona)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = @"UPDATE Personas 
                                 SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion, 
                                     Telefono = @Telefono, Foto = @Foto, IDDepartamento = @IDDepartamento, FechaNacimiento = @FechaNacimiento 
                                 WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", persona.nombre);
                    miComando.Parameters.AddWithValue("@Apellidos", persona.apellido);
                    miComando.Parameters.AddWithValue("@Direccion", persona.direccion);
                    miComando.Parameters.AddWithValue("@Telefono", persona.telefono);
                    miComando.Parameters.AddWithValue("@Foto", persona.imagen);
                    miComando.Parameters.AddWithValue("@IDDepartamento", persona.idDepartamento);
                    miComando.Parameters.AddWithValue("@FechaNacimiento", (object)persona.fechaNac ?? DBNull.Value);
                    miComando.Parameters.AddWithValue("@ID", idPersona);

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
        /// <description>Agrega una nueva persona a la base de datos.</description>
        /// <precondition>El objeto persona debe contener datos válidos.</precondition>
        /// <postcondition>Se inserta un nuevo registro en la tabla Personas.</postcondition>
        /// </summary>
        /// <param name="personaNueva">Persona a agregar.</param>
        /// <returns>Número de filas afectadas en la base de datos (debería ser 1 si se insertó correctamente).</returns>
        public int añadirPersona(clsPersona personaNueva)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = @"INSERT INTO Personas 
                                 (Nombre, Apellidos, Direccion, Telefono, Foto, IDDepartamento, FechaNacimiento) 
                                 VALUES 
                                 (@Nombre, @Apellidos, @Direccion, @Telefono, @Foto, @IDDepartamento, @FechaNacimiento)";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@Nombre", personaNueva.nombre);
                    miComando.Parameters.AddWithValue("@Apellidos", personaNueva.apellido);
                    miComando.Parameters.AddWithValue("@Direccion", personaNueva.direccion);
                    miComando.Parameters.AddWithValue("@Telefono", personaNueva.telefono);
                    miComando.Parameters.AddWithValue("@Foto", personaNueva.imagen);
                    miComando.Parameters.AddWithValue("@IDDepartamento", personaNueva.idDepartamento);
                    miComando.Parameters.AddWithValue("@FechaNacimiento", (object)personaNueva.fechaNac ?? DBNull.Value);

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
        /// <description>Elimina una persona de la base de datos por su ID.</description>
        /// <precondition>El ID de la persona debe existir.</precondition>
        /// <postcondition>Se elimina el registro de la persona de la tabla Personas.</postcondition>
        /// </summary>
        /// <param name="idPersona">ID de la persona a eliminar.</param>
        /// <returns>Número de filas afectadas en la base de datos.</returns>
        public int eliminarPersona(int idPersona)
        {
            int filasAfectadas = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "DELETE FROM Personas WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idPersona);

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
        /// <description>Obtiene una persona específica por su ID.</description>
        /// <precondition>El ID de la persona debe ser válido (> 0).</precondition>
        /// <postcondition>Devuelve la persona correspondiente si existe; en caso contrario, devuelve null.</postcondition>
        /// </summary>
        /// <param name="idPersona">ID de la persona a consultar.</param>
        /// <returns>Objeto clsPersona correspondiente al ID o null si no se encuentra.</returns>
        public clsPersona getPersonaPorID(int idPersona)
        {
            clsPersona oPersona = null;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT * FROM Personas WHERE ID = @ID";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@ID", idPersona);

                    try
                    {
                        miConexion.Open();
                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                oPersona = new clsPersona(
                                    (int)miLector["ID"],
                                    (string)miLector["Nombre"],
                                    (string)miLector["Apellidos"],
                                    (DateTime)miLector["FechaNacimiento"],
                                    (string)miLector["Direccion"],
                                    (string)miLector["Telefono"],
                                    (string)miLector["Foto"],
                                    (int)miLector["IDDepartamento"]
                                );

                                if (miLector["FechaNacimiento"] != DBNull.Value)
                                {
                                    oPersona.fechaNac = (DateTime)miLector["FechaNacimiento"];
                                }
                            }
                        }
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return oPersona;
        }

        /// <summary>
        /// <description>Cuenta cuántas personas están asignadas a un departamento específico.</description>
        /// <precondition>El ID del departamento debe existir.</precondition>
        /// <postcondition>Devuelve el número de personas asignadas al departamento indicado.</postcondition>
        /// </summary>
        /// <param name="idDepartamento">ID del departamento a consultar.</param>
        /// <returns>Número de personas asignadas al departamento.</returns>
        public int contarPersonasDepartamentos(int idDepartamento)
        {
            int contador = 0;

            using (SqlConnection miConexion = new SqlConnection(Connection.getConnectionString()))
            {
                string query = "SELECT COUNT(*) FROM Personas WHERE IDDepartamento = @IDDepartamento";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.AddWithValue("@IDDepartamento", idDepartamento);

                    try
                    {
                        miConexion.Open();
                        contador = (int)miComando.ExecuteScalar();
                    }
                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }
                }
            }

            return contador;
        }
    }
}
