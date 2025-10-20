namespace _01_ViewBag.Models.Entities
{
    public class clsPersona
    {
        #region Atributos privados
        private int _id;
        private string _nombre;

        #endregion
        #region Getters y setters

        public int id { 
            get { return _id; }
            set { _id = value; }
        }

        public string nombre { 
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion

        #region Constructores

        public clsPersona() { }

        public clsPersona(int id, string nombre) {
            _id = id;
            _nombre = nombre;
        }
        #endregion

    }
}
