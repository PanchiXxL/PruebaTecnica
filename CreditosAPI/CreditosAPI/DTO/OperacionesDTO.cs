using System.ComponentModel.DataAnnotations;

namespace CreditosAPI.DTO
{
    public class OperacionesDTO
    {

        [RegularExpression(@"^\d{10}$", ErrorMessage = "La cédula debe contener exactamente 10 dígitos.")]
        public string? Identificacion { get; set; }

        public string? Nombre { get; set; }

        public string? TipoCredito { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "El valor debe ser solo números.")]
        [Range(2, int.MaxValue, ErrorMessage = "El valor debe ser mayor que 1.")]
        public decimal? Monto { get; set; }

        public DateTime? FechaInicio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El plazo de meses debe ser mayor que 0.")]
        public int? PlazoMeses { get; set; }

        public bool? Aprobado { get; set; }



    }
}
