using System;
using System.Collections.Generic;

namespace Sistema_Creditos.Model.Models;

public partial class Operaciones
{
    public int OperacionId { get; set; }

    public string? Identificacion { get; set; }

    public string? Nombre { get; set; }

    public string? TipoCredito { get; set; }

    public decimal? Monto { get; set; }

    public DateTime? FechaInicio { get; set; }

    public int? PlazoMeses { get; set; }

    public bool? Aprobado { get; set; }

    public DateTime? FechaRegistro { get; set; }
    public DateTime? FechaFin { get; set; }
}
