using aspTask4RazorPages.Entities.Concretes;
using aspTask4RazorPages.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace aspTask4RazorPages.Pages.Products;
public class IndexModel : PageModel
{
    // private readonly fields :
    private readonly IProductService _service;

    // public property for showing info : 
    public string ? Info { get; set; }

    // constructor for injecting service : 
    public IndexModel(IProductService service)
    {
        _service = service;
    }

    // properties for binding two-way : 
    [BindProperty]
    public Product? AddProduct { get; set; }

    [BindProperty]
    public Product? EditProduct { get; set; }

    // properties for binding one-way : 
    public List<Product> ? Products { get; set; }

    // default methods from 'PageModel' : 
    public async Task OnGet(string info)
    {
        Products = await _service.GetAll();
        Info = info;
    }

    public async Task<IActionResult> OnPost()
    {
        if (AddProduct is not null)
        {
            await _service.Add(AddProduct);
            await _service.SaveChanges();
            Info = $"{AddProduct.Name} added succesfulyy !";
            return RedirectToPage("Index", new { info = Info });
        }
        return RedirectToPage("Index", new { info = "Data is null !" });
    }

    // other methods : 
    public async Task<IActionResult> OnPostDelete(int id)
    {
        var product = await _service.GetById(id);
        if (product != null)
        {
            _service.Delete(product);
            await _service.SaveChanges();
            Info = $"Product with ID {id} deleted successfully!";
        }
        else
        {
            Info = $"Product with ID {id} not found!";
        }

        return RedirectToPage("Index", new { info = Info });
    }

    public async Task<IActionResult> OnPostEdit()
    {
        if (EditProduct is not null)
        {
            var existingProduct = await _service.GetById(EditProduct.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = EditProduct.Name;
            existingProduct.Price = EditProduct.Price;
            existingProduct.Discount = EditProduct.Discount;
            existingProduct.Description = EditProduct.Description;
            existingProduct.ImagePath = EditProduct.ImagePath;

            await _service.SaveChanges();
            Info = $"{EditProduct.Name} updated successfully!";
            return RedirectToPage("Index", new { info = Info });
        }
        return RedirectToPage("Index", new { info = "Update failed!" });
    }

}
