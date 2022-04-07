using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoInterface
    {
        private readonly ClinicaContext _ctx;
        public DiagnosticoRepository(ClinicaContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Diagnostico> crearDiagnostico(Diagnostico diagnostico)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_DIAGNOSTICO]  @CitaID, @Descripcion";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@CitaID", SqlDbType.Int) { Value = diagnostico.CitaID},
                        new SqlParameter("@Descripcion", SqlDbType.VarChar) { Value = diagnostico.Descripcion},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return diagnostico;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<Diagnostico>> listarDiagnosticos()
        {
            List<Diagnostico> ListaDiagnosticos = await _ctx.Diagnosticos.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_DIAGNOSTICOS]").ToListAsync();
            return ListaDiagnosticos;
        }
    }
}
