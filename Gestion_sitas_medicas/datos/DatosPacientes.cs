using Gestion_sitas_medicas.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.datos
{
    internal class DatosPacientes
    {
        public static List<Paciente> ListarPacientes = new List<Paciente>();

        public List<Paciente> ObtenerTodos()
        {

            return ListarPacientes;
        }

        public void Guardar(Paciente paciente)
        {

           
            ListarPacientes.Add(paciente);
            
        }

        public Paciente ObtenerPorDNI(string DNI) {

            return ListarPacientes.Find(d => d.DNI == DNI);

        }
    }
}
