using FinalProyect.Data;
using System.ComponentModel.DataAnnotations;

namespace FinalProyect.Models;

public class RegistroDocumentacion
{
    public int Id { get; set; }

    public string NombreCompleto { get; set; }
    public string Cedula { get; set; }
    public string Telefono { get; set; }

    public string TipoDocumentacion { get; set; }

    public decimal Monto { get; set; }

    public string Comentarios { get; set; }

    public string ReciboNotariosRuta { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Required]
    public string UsuarioId { get; set; } = string.Empty; 
    public ApplicationUser? Usuario { get; set; }

    [Required]
    public int SolicitanteId { get; set; }
    public Solicitante? Solicitante { get; set; }

    [Required]
    public int ReciboIngresoId { get; set; } 
    public ReciboIngreso? ReciboIngreso { get; set; }
}
