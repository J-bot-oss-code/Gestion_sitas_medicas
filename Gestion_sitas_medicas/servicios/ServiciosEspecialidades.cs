using Gestion_sitas_medicas.datos;
using Gestion_sitas_medicas.modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gestion_sitas_medicas.servicios
{
    internal class ServiciosEspecialidades
    {
        private readonly DatosEspecialidades Especialidades;

        public ServiciosEspecialidades(DatosEspecialidades Especialidades)
        {
            this.Especialidades = Especialidades ?? new DatosEspecialidades();
        }

        public void AgregarEspecialidades(Especialidad esp)
        {
            Especialidades.Guardar(esp);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Especialidad agregada correctamente");
            Console.ResetColor();
        }

        public void GuardarEspecialidad(Especialidad nuevaEspecialidad)
        {
            List<Especialidad> listaReal = Especialidades.obtenerTodas();

            bool yaExiste = listaReal.Any(e => e.NombreEspecialidad.Equals(nuevaEspecialidad.NombreEspecialidad, StringComparison.OrdinalIgnoreCase));
            if (yaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: La especialidad ya existe");
                Console.ResetColor();
                return;
            }

            int idMaximo = 0;
            for (int i = 0; i < listaReal.Count; i++)
            {
                if (listaReal[i].id > idMaximo)
                {
                    idMaximo = listaReal[i].id;
                }
            }
            nuevaEspecialidad.id = idMaximo + 1;
            Especialidades.Guardar(nuevaEspecialidad);
        }

        public List<Especialidad> Listar()
        {
            return Especialidades.obtenerTodas();
        }
    }
}