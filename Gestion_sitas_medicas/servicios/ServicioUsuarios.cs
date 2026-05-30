using System;
using System.Collections.Generic;
using System.Linq;
using Gestion_sitas_medicas.datos;
using Gestion_sitas_medicas.modelos;

namespace Gestion_sitas_medicas.servicios
{
    internal class ServicioUsuarios
    {
        private readonly DatosMedicos Medi;
        private readonly DatosPacientes Pacient;

        public ServicioUsuarios(DatosMedicos medico, DatosPacientes pacient)
        {
            this.Medi = medico ?? new DatosMedicos();
            this.Pacient = pacient ?? new DatosPacientes();
        }

        public void AgregarMedico(string DNI, string Nombre, string Telefono, string especialidad, string Horario)
        {
            Medico medico = new Medico(DNI, Nombre, Telefono, especialidad, Horario);
            List<Medico> ListarMedico = Medi.optenerMedicos();

            if (string.IsNullOrEmpty(DNI))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: No se pudo agregar debido a que el DNI es obligatorio");
                Console.ResetColor();
                return;
            }

            bool yaExiste = ListarMedico.Any(m => m.DNI == medico.DNI);
            if (yaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: El médico ya existe con ese DNI.");
                Console.ResetColor();
                return;
            }

            Medi.GuardarMedico(medico);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Médico guardado correctamente");
            Console.ResetColor();
        }

        public Medico buscarMedico(string DNI)
        {
            return Medi.buscarMedico(DNI);
        }

        
        public List<Medico> ListarMedicos()
        {
            return Medi.optenerMedicos();
        }

        public void AgregarPaciente(string DNI, string Nombre, string Telefono, DateOnly FechaNacimiento)
        {
            Paciente paciente = new Paciente(DNI, Nombre, Telefono, FechaNacimiento);
            List<Paciente> ListarPacientes = Pacient.ObtenerTodos();

            if (string.IsNullOrEmpty(paciente.DNI))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: No se pudo agregar debido a que el DNI es obligatorio");
                Console.ResetColor();
                return;
            }

            bool yaExiste = ListarPacientes.Any(p => p.DNI == paciente.DNI);
            if (yaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: El paciente ya está registrado, no se puede duplicar");
                Console.ResetColor();
                return;
            }

            Pacient.Guardar(paciente);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Paciente guardado correctamente");
            Console.ResetColor();
        }

        public Paciente buscarPaciente(string DNI)
        {
            return Pacient.ObtenerPorDNI(DNI);
        }

        public List<Paciente> ListarPacientes()
        {
            return Pacient.ObtenerTodos();
        }
    }
}