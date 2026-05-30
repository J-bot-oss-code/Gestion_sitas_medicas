using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_sitas_medicas.modelos
{
    internal class Citas
    {

        public int id;
        public DateOnly Fecha { get; set; }
        public DateTime Hora { get; set; }

        public Medico medico;

        public Paciente paciente;
        public string estado { get; set; }


        public Citas(int id, DateOnly fecha, DateTime hora, Medico medico, Paciente paciente, string estado ) {
                this.id = id;
            this.Fecha = fecha;
            this.Hora = hora;
            this.medico = medico;
            this.paciente = paciente;
            this.estado = string.IsNullOrWhiteSpace(estado) ? "Pendiente" : estado;
        }

        public override string ToString()
        {
            return $"=========================================\n" +
                   $"DETALLE DE LA CITA\n" +
                   $"Fecha: {Fecha} | Hora: {Hora} | Estado: {estado}\n" +
                   $"-----------------------------------------\n" +
                   $"PACIENTE: {paciente?.ToString()}\n" +
                   $"-----------------------------------------\n" +
                   $"MÉDICO: {medico?.ToString()}\n" +
                   $"=========================================";
        }
    }
}
