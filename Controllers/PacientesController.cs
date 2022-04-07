﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAFP.Intefaces;
using PruebaTecnicaAFP.Models;
using System;
using System.Threading.Tasks;

namespace PruebaTecnicaAFP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteInterface _Ipaciente;
        public PacientesController(IPacienteInterface Ipaciente)
        {
            _Ipaciente = Ipaciente;
        }
        [HttpPost]
        public async Task<ActionResult> crearPaciente([FromBody] Paciente paciente)
        {
            try
            {
                return Ok(await _Ipaciente.creatPaciente(paciente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        public async Task<IActionResult> listarPacientes()
        {
            try
            {
                return Ok(await _Ipaciente.listarPacientes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
