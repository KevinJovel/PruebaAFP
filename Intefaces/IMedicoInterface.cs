using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface IMedicoInterface
    {
        Task<Medico> creatMedico(Medico medico);
        Task<List<Medico>> listarMedico();
    }
}
