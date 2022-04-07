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

        public bool eliminarMedico(int ID)
        {
            try{
                string spSQL = "EXEC [dbo].[SP_ELIMINAR_MEDICO]  @ID";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@ID", SqlDbType.Int) { Value = ID}
                 };
                _ctx.Database.ExecuteSqlRaw(spSQL, parameters);
                return true;
            }catch (System.Exception)    {
                return false;
            }
        }

        public async Task<List<Medico>> listarMedico()
        {
            List<Medico> ListaMedios = await _ctx.Medicos.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_MEDICOS]").ToListAsync();
            return ListaMedios;
        }

        public async Task<Medico> modificarMedico(Medico medico)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_MODIFICAR_MEDICO]   @ID ,@Nombre, @TipoID";
                SqlParameter[] parameters = new SqlParameter[] {                   
                        new SqlParameter("@ID", SqlDbType.VarChar) { Value = medico.ID},
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
    }
}
