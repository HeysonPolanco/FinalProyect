using FinalProyect.Data;
using FinalProyect.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProyect.Services;

public class DocumentoService
{
    private readonly ApplicationDbContext _context;

    public DocumentoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Documento>> ObtenerTodos()
    {
        return await _context.Documentos.ToListAsync();
    }

    public async Task<Documento?> ObtenerPorId(int id)
    {
        return await _context.Documentos.FindAsync(id);
    }

    public async Task<bool> Crear(Documento documento)
    {
        _context.Documentos.Add(documento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(Documento documento)
    {
        _context.Documentos.Update(documento);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var documento = await _context.Documentos.FindAsync(id);
        if (documento == null) return false;
        _context.Documentos.Remove(documento);
        return await _context.SaveChangesAsync() > 0;
    }
}
