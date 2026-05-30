using Gestion_sitas_medicas.datos;
using Gestion_sitas_medicas.modelos;
using Gestion_sitas_medicas.servicios;
using System;
using System.Collections.Generic;

namespace Gestion_sitas_medicas.presentacion
{
    internal class InterfazConsola
    {
        private readonly ServiciosCitas SVCitas;
        private readonly ServiciosEspecialidades SVCEspecialidades;
        private readonly ServicioUsuarios SVCusuarios;

        public InterfazConsola(ServiciosCitas SVCitas, ServiciosEspecialidades SVCEspecialidades, ServicioUsuarios SVCusuarios)
        {
            this.SVCitas = SVCitas;
            this.SVCEspecialidades = SVCEspecialidades;
            this.SVCusuarios = SVCusuarios;
        }

        public void DibujarEncabezado(string titulo)
        {
            int anchoTotal = 55;
            string lineaDoble = new string('═', anchoTotal - 2);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"╔{lineaDoble}╗");

            int espaciosIzquierda = (anchoTotal - 2 - titulo.Length) / 2;
            int espaciosDerecha = anchoTotal - 2 - titulo.Length - espaciosIzquierda;
            string textoCentrado = new string(' ', espaciosIzquierda) + titulo + new string(' ', espaciosDerecha);

            Console.WriteLine($"║{textoCentrado}║");
            Console.WriteLine($"╚{lineaDoble}╝");
            Console.ResetColor();
        }

        public void DibujarMenuPrincipal()
        {
            Console.Clear();
            DibujarEncabezado("SISTEMA DE GESTIÓN DE CITAS MÉDICAS");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ╔══════════════════════════════════════════════════╗");
            Console.WriteLine("  ║  1.  Registrar Especialidad                      ║");
            Console.WriteLine("  ║  2.  Registrar Médico                            ║");
            Console.WriteLine("  ║  3.  Registrar Paciente                          ║");
            Console.WriteLine("  ║ ─────────────────────────────────────────────────║");
            Console.WriteLine("  ║  4.  Agendar Cita Médica                         ║");
            Console.WriteLine("  ║  5.  Cancelar Cita                               ║");
            Console.WriteLine("  ║  6.  Reprogramar Cita                            ║");
            Console.WriteLine("  ║ ─────────────────────────────────────────────────║");
            Console.WriteLine("  ║  7.  Listar Todas las Citas                      ║");
            Console.WriteLine("  ║  8.  Consultar Citas por Paciente                ║");
            Console.WriteLine("  ║  9.  Consultar Citas por Médico                  ║");
            Console.WriteLine("  ║ ─────────────────────────────────────────────────║");
            Console.WriteLine("  ║  10. Salir del Sistema                           ║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  Seleccione una opción: ");
            Console.ResetColor();
        }

        public void PresioneParaContinuar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n ─────────────────────────────────────────────────────");
            Console.Write(" Presione cualquier tecla para volver al menú...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public void MostrarMensajeExito(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n   {mensaje}");
            Console.ResetColor();
        }

        public void MostrarMensajeError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  [ERROR]: {mensaje}");
            Console.ResetColor();
        }

        public void RegistrarEspecialidad()
        {
            Console.Clear();
            DibujarEncabezado(" Registrar Especialidad");
            Console.WriteLine(" Especialidades registradas hasta el momento");

            List<Especialidad> lista = SVCEspecialidades.Listar();
            int Nuevoid = lista.Count + 1;

            if (lista.Count == 0)
            {
                MostrarMensajeError("No hay especialidades en la lista ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("   ┌──────┬────────────────────────────────────────────┐");
                Console.WriteLine("   │  ID  │ NOMBRE DE LA ESPECIALIDAD                  │");
                Console.WriteLine("   ├──────┼────────────────────────────────────────────┤");

                foreach (Especialidad esp in lista)
                {
                    Console.WriteLine($"   │ {esp.id,-4} │ {esp.NombreEspecialidad,-42} │");
                }
                Console.WriteLine("   └──────┴────────────────────────────────────────────┘");
            }

            Console.WriteLine("\nIngrese el nombre de la especialidad que desea agregar:");
            string nombre = Console.ReadLine();
            Especialidad espd = new Especialidad(Nuevoid, nombre);
            SVCEspecialidades.AgregarEspecialidades(espd);
            PresioneParaContinuar();
        }

        public void RegistrarMedico()
        {
            Console.Clear();
            DibujarEncabezado("Registro de medicos");
            Console.WriteLine("Ingrese los siguientes datos para agregar Medico:\n");

            Console.WriteLine("Ingrese el DNI del medico");
            string dni = Console.ReadLine();

            Console.WriteLine("Ingrese el Nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono");
            string tel = Console.ReadLine();

            Console.WriteLine("Estas son las especialidades disponibles ");
            List<Especialidad> lista = SVCEspecialidades.Listar();

            foreach (Especialidad espe in lista)
            {
                Console.WriteLine($"- {espe.NombreEspecialidad}");
            }

            Console.WriteLine("\n Ingrese la Especialidad a asignar");
            string esp = Console.ReadLine();

            Console.WriteLine("\n Ahora ingrese el horario con el formato (ej: 8:00 am - 2:00 pm)");
            string horario = Console.ReadLine();

            SVCusuarios.AgregarMedico(dni, nombre, tel, esp, horario);
            PresioneParaContinuar();
        }

        public void RegistrarPaciente()
        {
            Console.Clear();
            DibujarEncabezado(" ***Registrar Paciente*** ");
            Console.WriteLine(" Ingrese los siguientes datos:\n");

            Console.WriteLine("Ingrese el DNI");
            string dni = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono");
            string tel = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del paciente: (ej: MM/dd/AAAA)");
            string fecha = Console.ReadLine();

            if (!DateOnly.TryParse(fecha, out DateOnly Fecha))
            {
                MostrarMensajeError(" la fecha no cumple con el formato requerido");
                PresioneParaContinuar();
                return;
            }

            SVCusuarios.AgregarPaciente(dni, nombre, tel, Fecha);
            PresioneParaContinuar();
        }

        public void AgendarCita()
        {
            Console.Clear();
            DibujarEncabezado(" Registro de citas ");

            Console.WriteLine("Ingrese la fecha de la cita: (ej: MM/dd/AAAA)");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly fechacita))
            {
                MostrarMensajeError("El formato no coincide con el requerido");
                PresioneParaContinuar();
                return;
            }

            Console.WriteLine("Ingrese la hora de la cita: (ej: 08:00 AM)");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime horacita))
            {
                MostrarMensajeError("El formato no coincide con el requerido");
                PresioneParaContinuar();
                return;
            }

            // Muestra la lista de médicos disponibles dinámicamente
            Console.WriteLine("\n--- Médicos Registrados Disponibles ---");
            List<Medico> medicos = SVCusuarios.ListarMedicos();
            if (medicos.Count == 0)
            {
                MostrarMensajeError("No hay médicos en el sistema. Registre uno primero.");
                PresioneParaContinuar();
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ┌─────────────────┬──────────────────────────────────────┐");
            Console.WriteLine(" │ DNI             │ NOMBRE DEL MÉDICO                    │");
            Console.WriteLine(" ├─────────────────┼──────────────────────────────────────┤");
            foreach (var m in medicos)
            {
                Console.WriteLine($" │ {m.DNI,-15} │ {m.Nombre,-36} │");
            }
            Console.WriteLine(" └─────────────────┴──────────────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine("\nAgregar Medico a la cita: ingrese su DNI");
            string Dni = Console.ReadLine();
            Medico MedicoBuscar = SVCusuarios.buscarMedico(Dni);

            if (MedicoBuscar == null)
            {
                MostrarMensajeError("Medico no encontrado: el DNI no es correcto");
                PresioneParaContinuar();
                return;
            }

            // Muestra la lista de pacientes registrados dinámicamente
            Console.WriteLine("\n--- Pacientes Registrados Disponibles ---");
            List<Paciente> pacientes = SVCusuarios.ListarPacientes();
            if (pacientes.Count == 0)
            {
                MostrarMensajeError("No hay pacientes en el sistema. Registre uno primero.");
                PresioneParaContinuar();
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ┌─────────────────┬──────────────────────────────────────┐");
            Console.WriteLine(" │ DNI             │ NOMBRE DEL PACIENTE                  │");
            Console.WriteLine(" ├─────────────────┼──────────────────────────────────────┤");
            foreach (var p in pacientes)
            {
                Console.WriteLine($" │ {p.DNI,-15} │ {p.Nombre,-36} │");
            }
            Console.WriteLine(" └─────────────────┴──────────────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine("\nAgregar Paciente a la cita: ingrese su DNI");
            string DNI = Console.ReadLine();
            Paciente PacienteBuscar = SVCusuarios.buscarPaciente(DNI);

            if (PacienteBuscar == null)
            {
                MostrarMensajeError("Paciente no encontrado: el DNI no es correcto");
                PresioneParaContinuar();
                return;
            }

            bool guardadoExitoso = SVCitas.AgendarCitas(fechacita, horacita, MedicoBuscar, PacienteBuscar, "Pendiente");

            if (guardadoExitoso)
            {
                MostrarMensajeExito("Cita agendada correctamente");
            }
            PresioneParaContinuar();
        }

        public void CancelarCita()
        {
            Console.Clear();
            DibujarEncabezado("Cancelar Cita");

            List<Citas> lista = SVCitas.consultar();
            if (lista.Count == 0)
            {
                MostrarMensajeError("No existen citas registradas en el sistema actualmente.");
                PresioneParaContinuar();
                return;
            }

            // Muestra las citas existentes antes de pedir el ID
            Console.WriteLine("\n--- Citas Actualmente Registradas ---");
            DibujarTablaCitas(lista);

            Console.WriteLine("\nIngrese el id de la cita que desea eliminar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarMensajeError("ID no válido.");
                PresioneParaContinuar();
                return;
            }

            bool exito = SVCitas.Cancelar(id);
            if (exito)
            {
                MostrarMensajeExito("Cita cancelada correctamente");
            }
            else
            {
                MostrarMensajeError("Cita no registrada o no encontrada.");
            }

            PresioneParaContinuar();
        }

        public void ReprogramarCita()
        {
            Console.Clear();
            DibujarEncabezado("Reprogramar Citas");

            List<Citas> lista = SVCitas.consultar();
            if (lista.Count == 0)
            {
                MostrarMensajeError("No existen citas registradas para reprogramar.");
                PresioneParaContinuar();
                return;
            }

            // Muestra las citas existentes antes de pedir el ID
            Console.WriteLine("\n--- Citas Actualmente Registradas ---");
            DibujarTablaCitas(lista);

            Console.WriteLine("\n Ingrese el id de la cita que quiere re-programar:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                MostrarMensajeError("ID Inválido");
                PresioneParaContinuar();
                return;
            }

            // Ya no se solicita el DNI aquí por redundancia

            Console.WriteLine("\n Ingrese la nueva fecha de la cita (ej: MM/dd/AAAA)");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly fecha))
            {
                MostrarMensajeError("El formato no coincide con el requerido");
                PresioneParaContinuar();
                return;
            }
            Console.WriteLine("Ingrese la hora de la cita: (ej: 08:00 AM)");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime hora))
            {
                MostrarMensajeError("El formato no coincide con el requerido");
                PresioneParaContinuar();
                return;
            }

            SVCitas.ReprogramarCita(id, fecha, hora);
            PresioneParaContinuar();
        }

        public void ListarCitas()
        {
            Console.Clear();
            DibujarEncabezado("LISTADO DE TODAS LAS CITAS");

            List<Citas> lista = SVCitas.consultar();

            if (lista.Count == 0)
            {
                MostrarMensajeError("No se encontraron citas en el sistema.");
            }
            else
            {
                DibujarTablaCitas(lista);
            }

            PresioneParaContinuar();
        }

        public void ConsultarCitaPorPaciente()
        {
            Console.Clear();
            DibujarEncabezado(" Consultar Citas de Paciente ");

            Console.WriteLine("\n Ingrese el DNI del paciente para ver sus citas:");
            string DNI = Console.ReadLine();

            List<Citas> listaPacientes = SVCitas.ConsultarPorPaciente(DNI);

            if (listaPacientes.Count == 0)
            {
                MostrarMensajeError("No se encontraron citas para el DNI de este paciente.");
            }
            else
            {
                DibujarTablaCitas(listaPacientes);
            }
            PresioneParaContinuar();
        }

        public void ConsultarCitaPorMedico()
        {
            Console.Clear();
            DibujarEncabezado(" Consultar Citas de Medico ");

            Console.WriteLine("\n Ingrese el DNI del medico para ver sus citas:");
            string DNI = Console.ReadLine();

            List<Citas> listaMedicos = SVCitas.ConsultarPorMedico(DNI);

            if (listaMedicos.Count == 0)
            {
                MostrarMensajeError("No se encontraron citas para el DNI de este médico.");
            }
            else
            {
                DibujarTablaCitas(listaMedicos);
            }
            PresioneParaContinuar();
        }

      
        private void DibujarTablaCitas(List<Citas> lista)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ┌────┬────────────┬──────────┬──────────────────────┬──────────────────────┬────────────┐");
            Console.WriteLine(" │ ID │ FECHA      │ HORA     │ PACIENTE             │ MÉDICO               │ ESTADO     │");
            Console.WriteLine(" ├────┼────────────┼──────────┼──────────────────────┼──────────────────────┼────────────┤");

            foreach (Citas cita in lista)
            {
                string id = cita.id.ToString();
                string fecha = cita.Fecha.ToString("dd/MM/yyyy");
                string hora = cita.Hora.ToString("HH:mm");
                string paciente = cita.paciente.Nombre;
                string medico = cita.medico.Nombre;
                string estado = cita.estado.ToUpper();

                
                if (paciente.Length > 20) paciente = paciente.Substring(0, 17) + "...";
                if (medico.Length > 20) medico = medico.Substring(0, 17) + "...";
                if (estado.Length > 10) estado = estado.Substring(0, 10);

                if (cita.estado.ToLower() == "cancelada") Console.ForegroundColor = ConsoleColor.Red;
                else if (cita.estado.ToLower() == "pendiente") Console.ForegroundColor = ConsoleColor.Yellow;
                else Console.ForegroundColor = ConsoleColor.Green;

               
                Console.WriteLine($" │ {id,-2} │ {fecha,-10} │ {hora,-8} │ {paciente,-20} │ {medico,-20} │ {estado,-10} │");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" └────┴────────────┴──────────┴──────────────────────┴──────────────────────┴────────────┘");
            Console.ResetColor();
        }
    }
}