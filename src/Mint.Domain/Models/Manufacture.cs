using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Manufacture : Entity<Guid>
{
    //[Required(ErrorMessage = "Заполните поле Название")]
    //[MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    //public string Name { get; set; } = null!;

    //[MaxLength(800, ErrorMessage = "Превышено макс. длина строки (100).")]
    //public string? Description { get; set; }

    //public int DisplayOrder { get; set; }

    //public Guid? PhotoId { get; set; }

    //public Photo? Photo { get; set; }

    //public List<Category>? Categories { get; set; }

    //public List<Product>? Products { get; set; }
}
