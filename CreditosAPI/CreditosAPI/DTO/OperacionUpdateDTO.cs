using System.ComponentModel.DataAnnotations;

namespace CreditosAPI.DTO
{
    public class OperacionUpdateDTO
    {
        public int OperacionId { get; set; }
        public string? Nombre { get; set; }
        public string? TipoCredito { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "El valor debe ser solo números.")]
        [Range(2, int.MaxValue, ErrorMessage = "El valor debe ser mayor que 1.")]
        public decimal? Monto { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El plazo de meses debe ser mayor que 0.")]
        public int? PlazoMeses { get; set; }
    }
}
