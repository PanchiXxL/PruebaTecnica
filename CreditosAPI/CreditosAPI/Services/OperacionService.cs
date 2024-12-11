using CreditosAPI.DTO;
using CreditosAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_Creditos.Model.Context;
using Sistema_Creditos.Model.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CreditosAPI.Services
{
    public class OperacionService:IOperacionesService
    {
        private readonly CreditosContext _context;

        public OperacionService(CreditosContext context)
        {
            _context = context;
        }

        public async Task<List<Operaciones>> ObtenerOperacionesAsync()
        {
            return await _context.Operaciones.ToListAsync();
        }
        public async Task<Operaciones?> GetById(int id)
        {
            return await _context.Operaciones.FindAsync(id);
        }

        public async Task<Operaciones> Create(OperacionesDTO operaciones)
        {
            var nuevaOperacion = new Operaciones();
            nuevaOperacion.Identificacion = operaciones.Identificacion;
            nuevaOperacion.Nombre=operaciones.Nombre;
            nuevaOperacion.TipoCredito=operaciones.TipoCredito;
            nuevaOperacion.Monto = operaciones.Monto;
            nuevaOperacion.FechaInicio = operaciones.FechaInicio;
            nuevaOperacion.PlazoMeses=operaciones.PlazoMeses;
            nuevaOperacion.Aprobado = operaciones.Aprobado;


            _context.Operaciones.Add(nuevaOperacion);
            await _context.SaveChangesAsync();

            return nuevaOperacion;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }


        
        public Task Update(int id, OperacionesDTO operaciones)
        {
            throw new NotImplementedException();
        }
    }
}
