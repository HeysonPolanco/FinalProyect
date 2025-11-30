using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;
public class SolicitanteService
{
    private readonly ApplicationDbContext _context;

    public SolicitanteService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Solicitante>> ObtenerTodos()
    {
        return await _context.Solicitantes.ToListAsync();
    }

    public async Task<Solicitante?> ObtenerPorId(int id)
    {
        return await _context.Solicitantes.FindAsync(id);
    }

    public async Task<Solicitante?> BuscarPorCedula(string cedula)
    {
        return await _context.Solicitantes
            .FirstOrDefaultAsync(s => s.Cedula == cedula);
    }

    public async Task<bool> Crear(Solicitante solicitante)
    {
        if (await BuscarPorCedula(solicitante.Cedula) != null)
            return false;

        _context.Solicitantes.Add(solicitante);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(Solicitante solicitante)
    {
        _context.Solicitantes.Update(solicitante);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var solicitante = await _context.Solicitantes.FindAsync(id);
        if (solicitante == null) return false;
        _context.Solicitantes.Remove(solicitante);
        return await _context.SaveChangesAsync() > 0;
    }
}
