using System;

namespace PruebaTecnicaAFP.Models
{
    public class Cita
    {
        public int ID { get; set; }
        public int PacienteID { get; set; }
        public int MedicoID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
