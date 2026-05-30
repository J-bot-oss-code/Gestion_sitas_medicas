using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.modelos
{
   internal abstract class Usuario
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }



        // constructor 
        public Usuario(string DNI, string Nombre, string Telefono) {

            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }
        public abstract string ToString();

    }
}
