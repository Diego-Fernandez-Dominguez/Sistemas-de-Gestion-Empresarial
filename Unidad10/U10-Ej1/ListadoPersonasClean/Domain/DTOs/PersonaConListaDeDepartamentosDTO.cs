using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.DTOs
{
    public class PersonaConListaDeDepartamentosDTO
    {
        public clsPersona Persona { get; set; }
        public List<clsDepartamento> Departamentos { get; }

        public PersonaConListaDeDepartamentosDTO(clsPersona persona, List<clsDepartamento> departamentos)
        {
            Persona = persona;
            Departamentos = departamentos;
        }
    }
}