using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class clsMision
    {

        #region Atributos privados
        private int _idMision;
        private string _nombreMision;
        private string _descripcionMision;
        private int _recompensa;

        #endregion
        #region Getters y Setters

        public int IdMision
        {
            get { return _idMision; }
        }

        public String NombreMision
        {
            get { return _nombreMision; }
            set { _nombreMision = value; }
        }

        public String DescripcionMision
        {
            get { return _descripcionMision; }
            set { _descripcionMision = value; }
        }

        public int Recompensa
        {
            get { return _recompensa; }
            set { _recompensa = value; }
        }

        #endregion
        #region Constructores

        public clsMision(int idMision, string nombreMision, string descripcionMision, int recompensa)
        {
            _idMision = idMision;
            _nombreMision = nombreMision;
            _descripcionMision = descripcionMision;
            _recompensa = recompensa;
        }

        public clsMision()
        {
            _idMision = 0;
            _nombreMision = "Desconocida";
            _descripcionMision = "Sin descripcion";
            _recompensa = 0;
        }

        #endregion

    }
}
