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
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoInterface IMedico;
        public MedicosController(IMedicoInterface medico)
        {
            IMedico = medico;
        }
        [HttpPost]
        public async Task<ActionResult> crearMedico([FromBody] Medico Medico)
        {
            try
            {
                return Ok(await IMedico.creatMedico(Medico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> listarMedicos()
        {
            try
            {
                return Ok(await IMedico.listarMedico());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public async Task<ActionResult> modificarMedico([FromBody] Medico medico)
        {
            try
            {
                return Ok(await IMedico.modificarMedico(medico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        [Route("{Id}")]
        public bool deleteBook(int Id)
        {
            try
            {
                return IMedico.eliminarMedico(Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
