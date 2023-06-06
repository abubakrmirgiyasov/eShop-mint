#nullable disable

namespace Mint.Domain.Models.Base.Interfaces;

public interface ITrackable
{
    byte[] RowVersion { get; set; }

    DateTimeOffset CreatedDateTime { get; set; }

    DateTimeOffset? UpdateDateTime { get; set; }
}
