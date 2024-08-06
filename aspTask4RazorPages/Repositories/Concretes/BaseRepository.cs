using aspTask4RazorPages.Context;
using aspTask4RazorPages.Entities.Abstracts;
using aspTask4RazorPages.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
namespace aspTask4RazorPages.Repositories.Concretes;
public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    // private readonly fields for keeping context;table : 
    private readonly ProductDbContext _context;
    private readonly DbSet<T> table;

    // constructor for injecting 'DbContext' : 
    public BaseRepository(ProductDbContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }

    public async Task Add(T entity)
    {
       if(entity == null) throw new ArgumentNullException(nameof(entity) + " is null !");
       await table.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity) + " is null !");
        table.Remove(entity);
    }

    public void Delete(int id)
    {
        var entity = _context.Products.FirstOrDefault(p => p.Id == id) as T;
        if (entity == null) throw new ArgumentNullException("Object did not found !");
        table.Remove(entity);
    }

    public async Task<List<T>> GetAll() => await _context.Products.ToListAsync() as List<T>;

    public async Task<T> GetById(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id) as T;

    public async Task SaveChanges() =>
        await _context.SaveChangesAsync();

    public async Task Update(T entity)
    {
        var e = table.FirstOrDefault(e => e.Id == entity.Id);
        _context.Entry(e).State = EntityState.Modified;
        await SaveChanges();
    }
}
