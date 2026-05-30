using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.modelos
{
    internal class Paciente : Usuario
    {
        public DateOnly FechaNacimiento;
       
        public Paciente( string DNI, string Nombre, string Telefono, DateOnly FechaNacimiento) : base(DNI, Nombre, Telefono)
        {
            this.FechaNacimiento = FechaNacimiento;


        }

        public override string ToString()
        {
            return $"DNI {DNI} \n" +
                $"Nombre {Nombre} \n" +
                $"Telefono{Telefono} \n" +
                $"Fecha de Nacimiento {FechaNacimiento}\n";
        }
    }
}
