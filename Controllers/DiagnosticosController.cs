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
    public class DiagnosticosController : ControllerBase
    {
        private readonly IDiagnosticoInterface IDiag;
        public DiagnosticosController(IDiagnosticoInterface Diag)
        {
            IDiag = Diag;
        }
        [HttpPost]
        public async Task<ActionResult> crearDiagnostico([FromBody] Diagnostico Diag)
        {
            try
            {
                return Ok(await IDiag.crearDiagnostico(Diag));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> listarDiagnosticos()
        {
            try
            {
                return Ok(await IDiag.listarDiagnosticos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
