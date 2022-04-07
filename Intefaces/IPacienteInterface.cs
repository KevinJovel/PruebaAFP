using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Intefaces
{
    public interface IPacienteInterface
    {
        Task<Paciente> creatPaciente(Paciente paciente);
        Task<List<Paciente>> listarPacientes();
    }
}
