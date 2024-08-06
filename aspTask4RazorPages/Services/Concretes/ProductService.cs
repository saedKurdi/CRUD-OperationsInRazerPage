using aspTask4RazorPages.Entities.Concretes;
using aspTask4RazorPages.Repositories.Abstracts;
using aspTask4RazorPages.Services.Abstracts;
namespace aspTask4RazorPages.Services.Concretes;
public class ProductService : IProductService
{
    // private readonly fields for repository : 
    private readonly IBaseRepository<Product> _repository;

    // constructor for service : 
    public ProductService(IBaseRepository<Product> repository)
    {
        _repository = repository;
    }
    
    // other methods from interface : 
    public async Task Add(Product product)
    {
        await _repository.Add(product);
    }

    public void Delete(Product product)
    {
       _repository.Delete(product);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public async Task<List<Product>> GetAll() =>
        await _repository.GetAll(); 

    public async Task<Product> GetById(int id) =>
        await _repository.GetById(id);

    public async Task SaveChanges() => await _repository.SaveChanges();

    public async Task Update(Product product)
    {
     await _repository.Update(product);
    }
}
