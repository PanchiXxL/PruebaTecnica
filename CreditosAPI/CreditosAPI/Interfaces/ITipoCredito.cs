using CreditosAPI.DTO;
using Sistema_Creditos.Model.Models;

namespace CreditosAPI.Interfaces
{
    public interface ITipoCredito
    {
        public Task<IEnumerable<TipoCredito>> GetAll();
        public Task<TipoCredito> Create(TipoCreditoDTO tipoCredito);
        public Task Delete(string id);


    }
}
