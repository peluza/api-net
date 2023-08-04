using webapi.Models;

namespace webapi.Services;

public class CategoriaServices : ICategoriaServices
{
    TareasContext context;

    public CategoriaServices(TareasContext dbcontext)
    {
        context = dbcontext;

    }
    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria cetegoria)
    {
        context.Add(cetegoria);
        await context.SaveChangesAsync();
    }
    public async Task Update(Guid id, Categoria cetegoria)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            categoriaActual.Nombre = categoriaActual.Nombre;
            categoriaActual.Descripcion = cetegoria.Descripcion;
            categoriaActual.Peso = cetegoria.Peso;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);
        if (categoriaActual != null)
        {
            context.Remove(categoriaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICategoriaServices
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria cetegoria);
    Task Update(Guid id, Categoria cetegoria);
    Task Delete(Guid id);


}