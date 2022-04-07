using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface ICitaInterface
    {
        Task<Cita> crearCita(Cita cita);
        Task<List<DetalleCita>> listarCitas();
    }
}
