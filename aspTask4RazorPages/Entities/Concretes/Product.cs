using aspTask4RazorPages.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
namespace aspTask4RazorPages.Entities.Concretes;
public class Product : BaseEntity
{
    // public properties :
    [Required(ErrorMessage = "Name is required !")]
    public string ? Name { get; set; }
    public string ? Description { get; set; }

    [Required(ErrorMessage = "Please Input correct image path !")]
    public string ? ImagePath { get; set; }

    [Range(1,100,ErrorMessage = "Minimum Discount must be 1 max 100")]
    public int Discount { get; set; }
    public double Price { get; set; }

    // other methods : 
    public double GetDiscountedPrice(double price,int discount) => (price - ((price * discount) / 100));
}
