using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface IDiagnosticoInterface
    {
        Task<Diagnostico> crearDiagnostico(Diagnostico diagnostico);
        Task<List<Diagnostico>> listarDiagnosticos();
    }
}
