using CreditosAPI.DTO;
using CreditosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations.Rules;
using Sistema_Creditos.Model.Context;
using Sistema_Creditos.Model.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        private readonly CreditosContext _context;
        private readonly OperacionService _service; 

        public OperacionesController(CreditosContext context, OperacionService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _context.Operaciones.ToListAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _context.Operaciones.FindAsync(id) ;
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OperacionesDTO operaciones)
        {
            try
            {
                DateTime fechaPrestamo = Convert.ToDateTime(operaciones.FechaInicio);
                if (fechaPrestamo<DateTime.Now)
                {
                    return NotFound(new {mensaje="Fecha del prestamo no puede ser menor a la actual"});
                }
                var nuevaOperacion = new Operaciones();
                nuevaOperacion.Identificacion = operaciones.Identificacion;
                nuevaOperacion.Nombre = operaciones.Nombre;
                nuevaOperacion.TipoCredito = operaciones.TipoCredito;
                nuevaOperacion.Monto = operaciones.Monto;
                nuevaOperacion.FechaInicio = operaciones.FechaInicio;
                nuevaOperacion.PlazoMeses = operaciones.PlazoMeses;
                nuevaOperacion.Aprobado = operaciones.Aprobado;
                nuevaOperacion.FechaRegistro = fechaPrestamo;
                nuevaOperacion.FechaFin = fechaPrestamo.AddMonths(Convert.ToInt16(operaciones.PlazoMeses));
                _context.Operaciones.Add(nuevaOperacion);
                await _context.SaveChangesAsync();

                return Ok(nuevaOperacion);
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OperacionUpdateDTO operaciones)
        {
            if (id != operaciones.OperacionId)
                return BadRequest(new { message = $"La {operaciones.Nombre} con su ID {id} no existe. " });

            var result = await _context.Operaciones.FindAsync(id);

            var fechaExample = await _context.Operaciones.Where(x => x.OperacionId == id).FirstOrDefaultAsync();

            DateTime fechaInicio = Convert.ToDateTime(fechaExample?.FechaInicio);
            if (result is not null)
            {
                result.Nombre = operaciones.Nombre;
                result.TipoCredito = operaciones.TipoCredito;
                result.Monto = operaciones.Monto;
                result.PlazoMeses = operaciones.PlazoMeses;
                result.FechaFin = fechaInicio.AddMonths(Convert.ToInt16(operaciones.PlazoMeses));

                await _context.SaveChangesAsync();
                
                return Ok(new { message = "La operacion a sido actualizada." });
            }
            else
            {
                return NotFound(new { message = "Existe algun error al actualizar la cuenta." });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Operaciones.FindAsync(id);
            if (data is not null)
            {
                _context.Operaciones.Remove(data);
                await _context.SaveChangesAsync();

                return Ok(new { message = "La cuenta a sido Eliminada..!" });

            }
            else
            {
                return NotFound(new { message = "Existe algun error al eliminar la cuenta." });
            }

        }
    }
}
