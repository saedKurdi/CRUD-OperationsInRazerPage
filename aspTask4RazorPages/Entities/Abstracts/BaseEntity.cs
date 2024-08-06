namespace aspTask4RazorPages.Entities.Abstracts;
public abstract class BaseEntity
{
    // public properties : 
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

    // default constructor for 'BaseEntity' : 
    public BaseEntity()
    {
        CreatedDate = DateTime.Now;
    }
}
