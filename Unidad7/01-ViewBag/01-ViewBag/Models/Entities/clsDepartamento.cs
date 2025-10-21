
namespace _01_ViewBag.Models.Entities
{
    public class clsDepartamento
    {
        #region Atributos privados
        private int _idDepartamento;
        private string _nombreDepartamento;

        #endregion
        #region Getters y setters

        public int idDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }

        public string nombreDepartamento
        {
            get { return _nombreDepartamento; }
            set { _nombreDepartamento = value; }
        }

        #endregion

        #region Constructores

        public clsDepartamento() { }

        public clsDepartamento(int id, string nombre)
        {
            _idDepartamento = id;
            _nombreDepartamento = nombre;
        }

        #endregion
    }

}
