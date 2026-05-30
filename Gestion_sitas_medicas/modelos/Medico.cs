using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.modelos
{
    internal class Medico : Usuario
    {
        string especialidad;
        public string Horario;
        
        public Medico( string DNI, string Nombre, string Telefono ,string especialidad, string Horario) : base(DNI, Nombre, Telefono)
        {
            especialidad = especialidad;
            this.Horario = Horario;

        }

        public override string ToString()
        {
            return $"DNI {DNI} \n" +
                $"Nombre {Nombre} \n" +
                $"Telefono {Telefono} \n" +
                $"Especialidad {especialidad} \n" +
                $"Horario {Horario} \n";
        }
    }
}

