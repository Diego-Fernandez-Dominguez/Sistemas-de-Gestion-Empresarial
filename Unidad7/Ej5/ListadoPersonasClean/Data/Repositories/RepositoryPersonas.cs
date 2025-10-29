using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class RepositoryPersonas : IGetListaPersonas
    {

        // Constructor
        public clsPersona[] getListaPersonas()
        {
            return [

                new clsPersona(1, "Ana", "Domínguez"),
                new clsPersona(2, "Juan", "Pérez"),
                new clsPersona(3, "Luis", "Martínez"),
                new clsPersona(4, "Marta", "López"),
                new clsPersona(5, "Carlos", "Sánchez"),
                new clsPersona(6, "Laura", "Fernández")

            ];
        }

    }
}
