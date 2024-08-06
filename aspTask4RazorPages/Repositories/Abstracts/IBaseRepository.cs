using aspTask4RazorPages.Entities.Abstracts;
namespace aspTask4RazorPages.Repositories.Abstracts;
public interface IBaseRepository<T> where T : BaseEntity,new()
{
    // methods that will implemented from concrete repository classes : 
    public Task Add(T entity);
    public void Delete(T entity);
    public void Delete(int id);
    public Task Update(T entity);
    public Task<List<T>> GetAll();
    public Task<T> GetById(int id);
    public Task SaveChanges();
}
