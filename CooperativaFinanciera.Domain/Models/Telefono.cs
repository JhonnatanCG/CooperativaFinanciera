using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CooperativaFinanciera.Domain;

public partial class Telefono
{
    [Key]
    public int TelefonoID { get; set; }

    [Required]
    public int CodigoCliente { get; set; }

    [Required]
    [StringLength(20)]
    public string? Tipo { get; set; }

    [Required]
    public long Numero { get; set; }

    [JsonIgnore]
    public Cliente? Cliente { get; set; }
}
