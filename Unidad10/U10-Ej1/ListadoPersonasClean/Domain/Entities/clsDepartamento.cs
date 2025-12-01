using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class clsDepartamento
    {
        #region Atributos privados

        private int _id;
        private string _nombre;



        #endregion

        #region Getters y setters
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion

        #region Constructores

        public clsDepartamento()
        {
        }

        public clsDepartamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }

        #endregion


    }
}
