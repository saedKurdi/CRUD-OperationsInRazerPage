using aspTask4RazorPages.Context;
using aspTask4RazorPages.Entities.Concretes;
namespace aspTask4RazorPages.Repositories.Concretes;
public class ProductRepository : BaseRepository<Product>
{
    // parametric constructor for product repository : 
    public ProductRepository(ProductDbContext opt) : base(opt) {}
}
