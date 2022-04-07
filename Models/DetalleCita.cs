using System;

namespace PruebaTecnicaAFP.Models
{
    public partial class DetalleCita
    {
        public int CitaID { get; set; }
        public int PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public int MedicoID { get; set; }
        public string NombreMedico { get; set; }
        public string TipoMedico { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
