using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaInterface ICita;
        public CitasController(ICitaInterface Cita)
        {
            ICita = Cita;
        }
        [HttpPost]
        public async Task<ActionResult> crearCita([FromBody] Cita Cita)
        {
            try
            {
                return Ok(await ICita.crearCita(Cita));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> listarCitas()
        {
            try
            {
                return Ok(await ICita.listarCitas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}
