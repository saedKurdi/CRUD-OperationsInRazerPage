using aspTask4RazorPages.Entities.Concretes;
namespace aspTask4RazorPages.Services.Abstracts;
public interface IProductService
{
    // methods that will implemented from concrete service class : 
    public Task Add(Product entity);
    public void Delete(Product entity);
    public void Delete(int id);
    public Task Update(Product entity);
    public Task<List<Product>> GetAll();
    public Task<Product> GetById(int id);
    public Task SaveChanges();
}
