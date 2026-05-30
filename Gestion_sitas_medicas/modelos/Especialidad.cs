using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.modelos
{
    internal class Especialidad
    {

        public int id { get; set; }
        public string NombreEspecialidad { get; set; }


        public Especialidad(int id, string NombreEspecialidad) {

            this.id = id;
            this.NombreEspecialidad = NombreEspecialidad;
        }
    }


}

