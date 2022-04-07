using PruebaTecnicaAFP.Models;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface ICitaInterface
    {
        Task<Cita> creatCita(Cita cita);
    }
}
