using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class ArrendamientoTerrenoService
{
    private readonly ApplicationDbContext _context;

    public ArrendamientoTerrenoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ArrendamientoTerreno>> ObtenerTodos()
    {
        return await _context.ArrendamientoTerreno
            .Include(a => a.Usuario)
            .Include(a => a.Solicitante)
            .Include(a => a.ReciboIngreso)
            .ToListAsync();
    }

    public async Task<ArrendamientoTerreno?> ObtenerPorId(int id)
    {
        return await _context.ArrendamientoTerreno
            .Include(a => a.Usuario)
            .Include(a => a.Solicitante)
            .Include(a => a.ReciboIngreso)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<bool> Crear(ArrendamientoTerreno arrendamiento)
    {
        _context.ArrendamientoTerreno.Add(arrendamiento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(ArrendamientoTerreno arrendamiento)
    {
        _context.ArrendamientoTerreno.Update(arrendamiento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var arrendamiento = await _context.ArrendamientoTerreno.FindAsync(id);
        if (arrendamiento == null) return false;
        _context.ArrendamientoTerreno.Remove(arrendamiento);
        return await _context.SaveChangesAsync() > 0;
    }
}
