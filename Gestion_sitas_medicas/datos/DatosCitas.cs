using Gestion_sitas_medicas.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.datos
{
    internal class DatosCitas
    {
        private static List<Citas> listaCitas = new List<Citas>();
        

        public List<Citas> obtenerTodas() {

            return listaCitas;
        }

        public void Guardar(Citas cita) {

            listaCitas.Add(cita);
            
            
        }

        public Citas buscarPorId(int idCita)
        {
            return listaCitas.Find(c => c.id == idCita);
        }


    }
}
