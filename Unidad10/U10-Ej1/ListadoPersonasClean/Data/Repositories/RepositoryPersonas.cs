using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;

namespace Data.Repositories
{
    public class RepositoryPersonas : IRepoPersona
    {
        public List<clsPersona> GetListaPersonas()
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
    
        

    }
}
