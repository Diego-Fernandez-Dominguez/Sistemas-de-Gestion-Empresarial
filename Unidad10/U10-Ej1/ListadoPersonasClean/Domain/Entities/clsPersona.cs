using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        private string _imagen;
        private string _telefono;
        private int _idDepartamento;


        #endregion
        #region Getters y setters

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Display(Name="Nombre")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Campo nombre obligatorio")]
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo apellido obligatorio")]
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo fecha obligatorio")]
        public DateTime fechaNac
        {
            get { return _fechaNac; }
            set { _fechaNac = value; }
        }

        [Required(ErrorMessage = "Campo direccion obligatorio")]
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        [Required(ErrorMessage = "Campo telefono obligatorio")]
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        [Required(ErrorMessage = "Campo imagen obligatorio")]
        public string imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        [Required(ErrorMessage = "Campo departamento obligatorio")]
        public int idDepartamento
        {
            get { return _idDepartamento; }
            set { _idDepartamento = value; }
        }

        #endregion

        #region Constructores

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNacimiento, string direccion, string telefono, string imagen, int idDepartamento)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellidos;
            _fechaNac = fechaNacimiento;
            _direccion = direccion;
            _telefono = telefono;
            _idDepartamento = idDepartamento;
            _imagen = imagen;
        }

        public clsPersona()
        {
        }

        #endregion

    }
}
