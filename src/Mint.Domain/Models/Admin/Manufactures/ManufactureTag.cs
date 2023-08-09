namespace Mint.Domain.Models.Admin.Manufactures;

public class ManufactureTag
{
    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }

    public Guid? TagId { get; set; }

    public Tag? Tag { get; set; }
}
