using System;
using System.Collections.Generic;
using System.Linq;
using Gestion_sitas_medicas.datos;
using Gestion_sitas_medicas.modelos;

namespace Gestion_sitas_medicas.servicios
{
    internal class ServiciosCitas
    {
        private readonly DatosCitas citas;

        // Protección Null con operador Coalesce (??)
        public ServiciosCitas(DatosCitas citas)
        {
            this.citas = citas ?? new DatosCitas();
        }

        public bool AgendarCitas(DateOnly fecha, DateTime hora, Medico medico, Paciente paciente, string estado)
        {
            int Nuevoid = citas.obtenerTodas().Count + 1;
            Citas cita = new Citas(Nuevoid, fecha, hora, medico, paciente, estado);
            List<Citas> listaCitas = citas.obtenerTodas();

            bool MedicoOcupado = listaCitas.Any(c => c.medico.DNI == cita.medico.DNI && c.Fecha == fecha && c.Hora.TimeOfDay == cita.Hora.TimeOfDay && c.estado.ToLower() == "pendiente");
            bool PacienteOcupado = listaCitas.Any(p => p.paciente.DNI == cita.paciente.DNI && p.Fecha == fecha && p.Hora.TimeOfDay == cita.Hora.TimeOfDay && p.estado.ToLower() == "pendiente");

            if (MedicoOcupado || PacienteOcupado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: No está disponible para el horario de la cita (Médico o Paciente ocupado).");
                Console.ResetColor();
                return false;
            }

            citas.Guardar(cita);
            return true;
        }

        public bool Cancelar(int id)
        {
            Citas cancelar = citas.buscarPorId(id);
            if (cancelar == null)
            {
                return false;
            }
            cancelar.estado = "Cancelada";
            return true;
        }

        public void ReprogramarCita(int id, DateOnly fecha, DateTime hora)
        {
            Citas cita = citas.buscarPorId(id);

            if (cita == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: Cita no encontrada, no se puede reprogramar.");
                Console.ResetColor();
                return;
            }

            List<Citas> listaActual = citas.obtenerTodas();

            bool MedicoOcupado = listaActual.Any(c =>
                c.id != id &&
                c.medico.DNI == cita.medico.DNI &&
                c.Fecha == fecha &&
                c.Hora.TimeOfDay == hora.TimeOfDay &&
                c.estado.ToLower() == "pendiente");

            bool PacienteOcupado = listaActual.Any(p =>
                p.id != id &&
                p.paciente.DNI == cita.paciente.DNI &&
                p.Fecha == fecha &&
                p.Hora.TimeOfDay == hora.TimeOfDay &&
                p.estado.ToLower() == "pendiente");

            if (MedicoOcupado || PacienteOcupado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n  [ERROR]: No se pudo reprogramar: El médico o el paciente ya tienen una cita en ese horario.");
                Console.ResetColor();
                return;
            }

            cita.Fecha = fecha;
            cita.Hora = hora;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Cita reprogramada y actualizada correctamente.");
            Console.ResetColor();
        }

        public List<Citas> consultar()
        {
            return citas.obtenerTodas();
        }

        public List<Citas> ConsultarPorPaciente(string DNIpaciente)
        {
            List<Citas> todasLasCitas = citas.obtenerTodas();
            List<Citas> filtered = new List<Citas>();

            foreach (Citas cita in todasLasCitas)
            {
                if (cita.paciente.DNI == DNIpaciente)
                {
                    filtered.Add(cita);
                }
            }
            return filtered;
        }

        public List<Citas> ConsultarPorMedico(string DNImedico)
        {
            List<Citas> todas = citas.obtenerTodas();
            List<Citas> filtered = new List<Citas>();

            foreach (Citas cita in todas)
            {
                if (cita.medico.DNI == DNImedico)
                {
                    filtered.Add(cita);
                }
            }
            return filtered;
        }

        public Citas BuscarPorId(int idCita)
        {
            return citas.buscarPorId(idCita);
        }
    }
}