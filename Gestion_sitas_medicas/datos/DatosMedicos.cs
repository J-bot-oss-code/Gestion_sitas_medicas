using Gestion_sitas_medicas.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.datos
{
    internal class DatosMedicos
    {
        public static List<Medico> ListarMedicos = new List<Medico>();

        public List<Medico> optenerMedicos() {

            return ListarMedicos;
        }

        public void GuardarMedico(Medico medico) {

            ListarMedicos.Add(medico);
            
        }

        public Medico buscarMedico(string DNI) {

            return ListarMedicos.Find(m => m.DNI == DNI);
        }

    }
}
