using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Repositories
{
    public class PacienteRepository : IPacienteInterface
    {
        private readonly ClinicaContext _ctx;


        public PacienteRepository(ClinicaContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Paciente> creatPaciente(Paciente paciente)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_PACIENTE]  @Nombre";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = paciente.Nombre},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return paciente;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<Paciente>> listarPacientes()
        {
            List<Paciente> ListaPacientes = await _ctx.Pacientes.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_PACIENTES]").ToListAsync();          
            return ListaPacientes;
        }
    }
}
