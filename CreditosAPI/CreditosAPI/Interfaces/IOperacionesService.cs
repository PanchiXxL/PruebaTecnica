using CreditosAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Sistema_Creditos.Model.Models;

namespace CreditosAPI.Interfaces
{
    public interface IOperacionesService
    {
        public Task<List<Operaciones>> ObtenerOperacionesAsync();
        public Task<Operaciones?> GetById(int id);

        public Task<Operaciones> Create(OperacionesDTO operaciones);
        public Task Update(int id, OperacionesDTO operaciones);

        public Task Delete(int id);

    }
}
