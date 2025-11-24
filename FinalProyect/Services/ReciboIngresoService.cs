using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class ReciboIngresoService
{
    private readonly ApplicationDbContext _context;

    public ReciboIngresoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ReciboIngreso>> ObtenerTodos()
    {
        return await _context.ReciboIngreso
            .Include(r => r.Solicitante)
            .Include(r => r.Proceso)
            .Include(r => r.Documento)
            .ToListAsync();
    }

    public async Task<ReciboIngreso?> ObtenerPorId(int id)
    {
        return await _context.ReciboIngreso
            .Include(r => r.Solicitante)
            .Include(r => r.Proceso)
            .Include(r => r.Documento)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> Crear(ReciboIngreso recibo)
    {
        _context.ReciboIngreso.Add(recibo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(ReciboIngreso recibo)
    {
        _context.ReciboIngreso.Update(recibo);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var recibo = await _context.ReciboIngreso.FindAsync(id);
        if (recibo == null) return false;
        _context.ReciboIngreso.Remove(recibo);
        return await _context.SaveChangesAsync() > 0;
    }
}
