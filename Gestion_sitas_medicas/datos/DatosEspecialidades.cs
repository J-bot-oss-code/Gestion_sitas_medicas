using Gestion_sitas_medicas.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.datos
{
    internal class DatosEspecialidades
    {
        public static List<Especialidad> ListarEspecialidades = new List<Especialidad>();
       

        public List<Especialidad> obtenerTodas() {

            return ListarEspecialidades;
        }

        public void Guardar(Especialidad nuevaEspecialidad) {

            ListarEspecialidades.Add(nuevaEspecialidad);
            
        }

        public Especialidad obtenerPorID(int id) {

            return ListarEspecialidades.Find(e => e.id == id);
        }

    }
}
