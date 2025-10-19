using EntradasHuacales9.Controllers;
using EntradasHuacales9.DAL;
using EntradasHuacales9.DTO;
using EntradasHuacales9.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EntradasHuacales9.Services;

public class EntradasHuacalesServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int  idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.IdEntrada == idhuacales);
    }

    private async Task AfectarExistencia(EntradasHuacalesDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach(var item in detalle)
        {
            var tipoHuacal = await contexto.TiposHuacales.SingleAsync(e => e.TipoId == item.TipoId);
            if (tipoOperacion == TipoOperacion.Resta)
                tipoHuacal.Existencia -= item.Cantidad;
            else
                tipoHuacal.Existencia += item.Cantidad;
            await contexto.SaveChangesAsync();
        }
    }

    private async Task<bool> Insertar(EntradasHuacales huacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(huacales);
        await AfectarExistencia(huacales.entradaHuacaleDetalle.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales huacalesNuevos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var huacalesActuales = await contexto.EntradasHuacales
            .Include(e => e.entradaHuacaleDetalle)
            .FirstOrDefaultAsync(e => e.IdEntrada == huacalesNuevos.IdEntrada);

        if (huacalesActuales == null)
        {
            return false; 
        }

        await AfectarExistencia(huacalesActuales.entradaHuacaleDetalle.ToArray(), TipoOperacion.Resta);
        huacalesActuales.NombreCliente = huacalesNuevos.NombreCliente;
        huacalesActuales.Fecha = DateTime.Now; 
        contexto.entradasHuacalesDetalles.RemoveRange(huacalesActuales.entradaHuacaleDetalle);
        huacalesActuales.entradaHuacaleDetalle = huacalesNuevos.entradaHuacaleDetalle;
        await AfectarExistencia(huacalesActuales.entradaHuacaleDetalle.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales huacales)
    {
        if (!await Existe(huacales.IdEntrada))
        {
            return await Insertar(huacales);
        }
        else 
        {
            return await Modificar(huacales);
        }
    }

    public async Task<EntradasHuacales?> Buscar(int idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Include(e => e.entradaHuacaleDetalle).FirstOrDefaultAsync(e => e.IdEntrada == idhuacales);
    }

    public async Task<bool> Eliminar(int idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await Buscar(idhuacales);

        await AfectarExistencia(entrada.entradaHuacaleDetalle.ToArray(), TipoOperacion.Resta);
        contexto.entradasHuacalesDetalles.RemoveRange(entrada.entradaHuacaleDetalle);
        contexto.EntradasHuacales.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<EntradasHuacalesDto[]> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Where(criterio)
            .Select(h => new EntradasHuacalesDto
            {
                NombreCliente = h.NombreCliente
            })
            .ToArrayAsync();
    }

    public async Task<TiposHuacalesDto[]> ListarTipos(Expression<Func<TiposHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales
            .Where(criterio)
            .Select(t => new TiposHuacalesDto
        {
            TipoId = t.TipoId,
            Existencia = t.Existencia,
            Descripcion = t.Descripcion
        }
        ).ToArrayAsync();
    }

    public enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }

}
