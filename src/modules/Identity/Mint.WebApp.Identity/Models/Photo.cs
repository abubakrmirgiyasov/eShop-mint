using Mint.Domain.Models.Base;

namespace Mint.WebApp.Identity.Models;

public class Photo : Entity<Guid>
{
    public string FileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public long FileSize { get; set; }

    public List<User>? Users { get; set; }
}
