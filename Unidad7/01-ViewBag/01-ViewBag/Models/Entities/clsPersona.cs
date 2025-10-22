namespace _01_ViewBag.Models.Entities
{
    public class clsPersona
    {
        #region Atributos privados
        private int _id;
        private string _nombre;
        private string _apellido;
        private int _departamento;

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

        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }

        #endregion

        #region Constructores

        public clsPersona(int id, string nombre) {
            _id = id;
            _nombre = nombre;
        }

        public clsPersona(int id, string nombre, string apellido)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
        }

        public clsPersona(int id, string nombre, string apellido, int departamento)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
            _departamento = departamento;
        }

        public clsPersona()
        {
            _id =0 ;
            _nombre ="";
            _apellido ="";
            _departamento = 0;
        }
        #endregion

    }
}
