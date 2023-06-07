#nullable disable

namespace Mint.Domain.Models.Base.Interfaces;

public interface ITrackable
{
    byte[] RowVersion { get; set; }

    DateTimeOffset CreatedDate { get; set; }

    DateTimeOffset? UpdateDateTime { get; set; }
}
