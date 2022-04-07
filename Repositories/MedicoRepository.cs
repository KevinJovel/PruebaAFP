using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Repositories
{
    public class MedicoRepository : IMedicoInterface
    {
        private readonly ClinicaContext _ctx;
        public MedicoRepository(ClinicaContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Medico> creatMedico(Medico medico)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_MEDICO]  @Nombre, @TipoID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = medico.Nombre},
                        new SqlParameter("@TipoID", SqlDbType.Int) { Value = medico.TipoID},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return medico;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<Medico>> listarMedico()
        {
            List<Medico> ListaMedios = await _ctx.Medicos.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_MEDICOS]").ToListAsync();
            return ListaMedios;
        }
    }
}
