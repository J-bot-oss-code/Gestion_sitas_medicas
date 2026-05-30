using Gestion_sitas_medicas.datos;
using Gestion_sitas_medicas.modelos;
using Gestion_sitas_medicas.servicios;
using System;
using System.Collections.Generic;
using System.Data;


namespace Gestion_sitas_medicas.presentacion {


    class Precentacion {

        private static DatosCitas Datocita;
        private static DatosEspecialidades DatosESP;
        private static DatosMedicos DTMedicos;
        private static DatosPacientes DTPacientes;
        private static ServiciosCitas SVCitas;
        private static ServiciosEspecialidades SVCEspecialidades;
        private static ServicioUsuarios SVCusuarios;

        private static InterfazConsola interfaz;

        static void Main(string[] args)
        {

            Datocita = new DatosCitas();
            DatosESP = new DatosEspecialidades();
            DTMedicos = new DatosMedicos();
            DTPacientes = new DatosPacientes();
            SVCitas = new ServiciosCitas(Datocita);
            SVCEspecialidades = new ServiciosEspecialidades(DatosESP);
            SVCusuarios = new ServicioUsuarios(DTMedicos, DTPacientes);

            interfaz = new InterfazConsola(SVCitas, SVCEspecialidades, SVCusuarios);

            int opcion = 0;

            do
            {
                interfaz.DibujarMenuPrincipal();
                if (int.TryParse(Console.ReadLine(), out opcion))
                {

                    switch (opcion) {


                        case 1: interfaz.RegistrarEspecialidad(); break;
                        case 2: interfaz.RegistrarMedico(); break;
                        case 3: interfaz.RegistrarPaciente(); break;
                        case 4: interfaz.AgendarCita(); break;
                        case 5: interfaz.CancelarCita(); break;
                        case 6: interfaz.ReprogramarCita(); break;
                        case 7: interfaz.ListarCitas(); break;
                        case 8: interfaz.ConsultarCitaPorPaciente(); break;
                        case 9: interfaz.ConsultarCitaPorMedico(); break;

                    }
                }

            } while (opcion != 10);

            Console.Clear();
            interfaz.DibujarEncabezado("SISTEMA CERRADO");
            Console.WriteLine("\n Gracias por utilizar nuestros servicios, vuelva pronto!");
        }

        

    }
}