using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Repositories
{
    public class CitaRepository : ICitaInterface
    {
        private readonly ClinicaContext _ctx;
        public CitaRepository(ClinicaContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Cita> crearCita(Cita cita)
        {
            try
            {
                string spSQL = "EXEC [dbo].[SP_GUARDAR_CITA]  @PacienteID, @MedicoID, @FechaHora";
                SqlParameter[] parameters = new SqlParameter[] {
                        new SqlParameter("@PacienteID", SqlDbType.Int) { Value = cita.PacienteID},
                        new SqlParameter("@MedicoID", SqlDbType.Int) { Value = cita.MedicoID},
                        new SqlParameter("@FechaHora", SqlDbType.DateTime) { Value = cita.FechaHora},
                 };
                await _ctx.Database.ExecuteSqlRawAsync(spSQL, parameters);
                return cita;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<List<DetalleCita>> listarCitas()
        {
            var ListaCitas = await _ctx.detalleCitas.FromSqlRaw("EXECUTE [dbo].[SP_LISTA_CITAS]").ToListAsync();
            return ListaCitas;
        }
    }
}
