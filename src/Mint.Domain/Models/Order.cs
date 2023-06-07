using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mint.Domain.Models;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderNumber { get; set; }

    public string ShippingType { get; set; } = null!;

    public string PaymentType { get; set; } = null!;

    public string? Description { get; set; }

    public string? OrderStatus { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.Now;

    public Guid? AddressId { get; set; }

    public Address? Address { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; } = null!;

    public List<OrderProduct> OrderProducts { get; set; } = null!;
}
