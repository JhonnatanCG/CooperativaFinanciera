using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CooperativaFinanciera.Domain;

public partial class Direcciones
{

    [Key]
    public int DireccionID { get; set; }

    [Required]
    public int CodigoCliente { get; set; }

    [Required]
    [StringLength(20)]
    public string? Tipo { get; set; }
    [Required]
    [StringLength(100)]
    public string? Direccion { get; set; }

    [JsonIgnore]
    public Cliente? Cliente { get; set; }
}
