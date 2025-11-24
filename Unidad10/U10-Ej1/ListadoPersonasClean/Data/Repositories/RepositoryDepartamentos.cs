using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryDepartamentos
    {
        public List<clsDepartamento> GetListaPersonas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            clsDepartamento oDepartamento;

            miConexion.ConnectionString
            = ("server=dferdom.database.windows.net;database=PersonasDB;uid=prueba;pwd=123abc|@#;trustServerCertificate = true;");

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM departamentos";

                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                //Si hay lineas en el lector

                if (miLector.HasRows)

                {

                    while (miLector.Read())

                    {

                        oDepartamento = new clsDepartamento();

                        oDepartamento.id = (int)miLector["ID"];

                    }


                }

                miLector.Close();

                miConexion.Close();

            }

            catch (SqlException exSql)
            {

                throw exSql;

            }

            return listadoDepartamentos;

        }
    }
}
