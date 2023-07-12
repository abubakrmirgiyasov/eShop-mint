using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mint.Domain.Models;

public class Order : Entity<Guid>
{
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public int OrderNumber { get; set; }

    //[Required(ErrorMessage = "Заполните обязательно поле")]
    //[MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    //public string ShippingType { get; set; } = null!;

    //[Required(ErrorMessage = "Заполните обязательно поле")]
    //[MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    //public string PaymentType { get; set; } = null!;

    //[Required(ErrorMessage = "Заполните обязательно поле")]
    //[StringLength(800, ErrorMessage = "Превышено макс. длина строки (800).")] 
    //public string? Description { get; set; }

    //[MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    //public string? OrderStatus { get; set; }

    //public bool IsPaid { get; set; } = false;

    //public DateTime? PaidDate { get; set; }

    //public DateTime? ShipDate { get; set; }

    //public Guid? AddressId { get; set; }

    //public Address? Address { get; set; }

    //public Guid? UserId { get; set; }

    //public User? User { get; set; }

    //public List<OrderProduct> OrderProducts { get; set; } = null!;
}
