using CreditosAPI.DTO;
using CreditosAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Sistema_Creditos.Model.Context;
using Sistema_Creditos.Model.Models;

namespace CreditosAPI.Services
{
    public class TipoCreditoService : ITipoCredito
    {
        private readonly CreditosContext _context;

        public TipoCreditoService(CreditosContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TipoCredito>> GetAll()
        {
            return await _context.TipoCreditos.ToListAsync();
        }

        public async Task<TipoCredito> Create(TipoCreditoDTO tipoCredito)
        {
            TipoCredito num = _context.TipoCreditos.First();
            num.Codigo = tipoCredito.Codigo+1;

            int cantidadDigitos = 3;
            string ceros = string.Concat(Enumerable.Repeat("0",cantidadDigitos));
            string numeroTransaccion = ceros + num.Codigo;

            var nuevaTipoCredito = new TipoCredito();
            nuevaTipoCredito.Codigo = numeroTransaccion+tipoCredito.Codigo;
            nuevaTipoCredito.Nombre = tipoCredito.Nombre;

            _context.TipoCreditos.Add(nuevaTipoCredito);
            await _context.SaveChangesAsync();

            return nuevaTipoCredito;

        }

        public async Task Delete(string id)
        {
            var data = await _context.TipoCreditos.FindAsync(id);
            if (data != null)
            {
                _context.TipoCreditos.Remove(data);
                await _context.SaveChangesAsync();
            }

        }

        
    }
}
