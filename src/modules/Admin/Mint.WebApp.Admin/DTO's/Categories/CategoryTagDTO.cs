namespace Mint.WebApp.Admin.DTO_s.Categories;

public class CategoryTagBindingModel
{
    public Guid? CategoryId { get; set; }

    public Guid? TagId { get; set; }
}

public record CategoryViewModel();
