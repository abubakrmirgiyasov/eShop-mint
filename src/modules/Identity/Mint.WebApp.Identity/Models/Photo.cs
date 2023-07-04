using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Identity.Models;

[BsonCollection("photos")]
public class Photo : Document
{
    public string FileName { get; set; } = null!;

    public string FileExtension { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public long FileSize { get; set; }
}
