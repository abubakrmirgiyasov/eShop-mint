namespace Mint.Domain.Models;

public class ReviewPhoto
{
    public Guid? ReviewId { get; set; }

    public Review? Review { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }
}
