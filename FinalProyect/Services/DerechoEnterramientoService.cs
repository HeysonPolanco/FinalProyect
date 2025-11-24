using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class DerechoEnterramientoService
{
    private readonly ApplicationDbContext _context;

    public DerechoEnterramientoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<DerechoEnterramiento>> ObtenerTodos()
    {
        return await _context.DerechoEnterramiento
            .Include(d => d.Usuario)
            .Include(d => d.Solicitante)
            .ToListAsync();
    }

    public async Task<DerechoEnterramiento?> ObtenerPorId(int id)
    {
        return await _context.DerechoEnterramiento
            .Include(d => d.Usuario)
            .Include(d => d.Solicitante)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<bool> Crear(DerechoEnterramiento derecho)
    {
        _context.DerechoEnterramiento.Add(derecho);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(DerechoEnterramiento derecho)
    {
        _context.DerechoEnterramiento.Update(derecho);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var derecho = await _context.DerechoEnterramiento.FindAsync(id);
        if (derecho == null) return false;
        _context.DerechoEnterramiento.Remove(derecho);
        return await _context.SaveChangesAsync() > 0;
    }
}
