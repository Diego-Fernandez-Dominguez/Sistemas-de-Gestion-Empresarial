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
        public List<clsPersona> getListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsPersona oPersona;

            miConexion.ConnectionString
            = ("server=dferdom.database.windows.net;database=PersonasDB;uid=prueba;pwd=123abc|@#;trustServerCertificate = true;");

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM personas";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                //Si hay lineas en el lector

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
