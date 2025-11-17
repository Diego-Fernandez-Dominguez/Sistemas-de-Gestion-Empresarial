using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class clsPersona
    {

        #region Atributos privados

        private int _id;
        private string _nombre;
        private string _apellido;
        private DateTime _fechaNac;
        private string _direccion;
        private string _telefono;


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

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public DateTime fechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        #endregion

        #region Constructores

        public clsPersona(int id, string nombre, string apellido)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
        }

        public clsPersona()
        {
            _id = 0;
            _nombre = "";
            _apellido = "";
        }

        #endregion

    }
}
