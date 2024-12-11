using CreditosAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Creditos.Model.Context;
using Sistema_Creditos.Model.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCreditoController : ControllerBase
    {
        private readonly CreditosContext _context;

        public TipoCreditoController(CreditosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoCredito>> Get()
        {
            return await _context.TipoCreditos.ToListAsync();
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TipoCreditoDTO tipoCredito)
        {
            /*TipoCredito num = _context.TipoCreditos.First();
            num.Codigo = tipoCredito.Codigo + 1;

            int cantidadDigitos = 3;
            string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
            string numeroTransaccion = ceros + num.Codigo;*/

            TipoCredito dataTipoCredito = new TipoCredito();
            dataTipoCredito.Codigo = tipoCredito.Codigo;
            dataTipoCredito.Nombre = tipoCredito.Nombre;

            _context.Add(dataTipoCredito);
            await _context.SaveChangesAsync();

            return Ok(dataTipoCredito);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _context.TipoCreditos.FindAsync(id);
            if (result is not null)
            {
                _context.TipoCreditos.Remove(result);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La cuenta a sido Eliminada..!" });
            }
            else
            {
                return NotFound(new { message = "Existe algun error al eliminar la cuenta." });
            }

        }

        //  NUMEROS CEROS
        /*public async Task<string> ValidacionCuenta(TipoCreditoDTO tipoCredito)
        {
            TipoCredito num = _context.TipoCreditos.First();
            num.Codigo = tipoCredito.Codigo + 1;

            int cantidadDigitos = 3;
            string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
            string numeroTransaccion = ceros + num.Codigo;

            var nuevaTipoCredito = new TipoCredito();
            nuevaTipoCredito.Codigo = numeroTransaccion + tipoCredito.Codigo;


            return "";
        }*/

    }
}
