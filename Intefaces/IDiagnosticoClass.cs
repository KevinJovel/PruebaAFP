using PruebaTecnicaAFP.Models;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface IDiagnosticoClass
    {
        Task<Diagnostico> crearDiagnostico(Diagnostico medico);
    }
}
