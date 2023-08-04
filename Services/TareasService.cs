using webapi.Models;

namespace webapi.Services;

public class TareasServices : ITareasServices
{
    TareasContext context;

    public TareasServices(TareasContext dbcontext)
    {
        context = dbcontext;

    }
    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea cetegoria)
    {
        context.Add(cetegoria);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Tarea tarea)
    {
        var TareaActual = context.Tareas.Find(id);
        if (TareaActual != null)
        {
            TareaActual.CategoriaId = tarea.CategoriaId;
            TareaActual.Titulo = tarea.Titulo;
            TareaActual.PrioridadTarea = tarea.PrioridadTarea;
            TareaActual.Descripcion = tarea.Descripcion;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);
        if (TareaActual != null)
        {
            context.Remove(TareaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITareasServices
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea cetegoria);
    Task Update(Guid id, Tarea cetegoria);
    Task Delete(Guid id);
}