using FinalProyect.Data;
using FinalProyect.Models;

public class DerechoEnterramiento
{
    public int Id { get; set; }

    public ProcessType TipoProceso { get; set; } = ProcessType.DerechoEnterramiento;
    public string UsuarioId { get; set; } = string.Empty;
    public ApplicationUser Usuario { get; set; }

    public int SolicitanteId { get; set; }
    public Solicitante Solicitante { get; set; }

    public string NombreFallecido { get; set; } = string.Empty;
    public string CedulaFallecido { get; set; } = string.Empty;

    public DateTime Fecha { get; set; }
    public TimeSpan Hora { get; set; }

    public int? ReciboIngresoId { get; set; }
    public ReciboIngreso? ReciboIngreso { get; set; }

    public ICollection<Documento>? Documentos { get; set; }

    public string GetConcepto() => "Derecho a enterramiento";
    public int GetMetros() => 0;
}
