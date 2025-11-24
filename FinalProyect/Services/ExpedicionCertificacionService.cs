using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class ExpedicionCertificacionService
{
    private readonly ApplicationDbContext _context;

    public ExpedicionCertificacionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ExpedicionCertificacion>> ObtenerTodos()
    {
        return await _context.ExpedicionesCertificaciones
            .Include(e => e.Usuario)
            .Include(e => e.Solicitante)
            .Include(e => e.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<ExpedicionCertificacion?> ObtenerPorId(int id)
    {
        return await _context.ExpedicionesCertificaciones
            .Include(e => e.Usuario)
            .Include(e => e.Solicitante)
            .Include(e => e.ReciboIngreso)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<bool> Crear(ExpedicionCertificacion certificacion)
    {
        _context.ExpedicionesCertificaciones.Add(certificacion);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(ExpedicionCertificacion certificacion)
    {
        _context.ExpedicionesCertificaciones.Update(certificacion);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var certificacion = await _context.ExpedicionesCertificaciones.FindAsync(id);
        if (certificacion == null) return false;
        _context.ExpedicionesCertificaciones.Remove(certificacion);
        return await _context.SaveChangesAsync() > 0;
    }
}
