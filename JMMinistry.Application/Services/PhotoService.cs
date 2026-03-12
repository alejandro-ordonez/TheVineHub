using Microsoft.Extensions.Configuration;
using SkiaSharp;

namespace JMMinistry.Application.Services;

public class PhotoService(IConfiguration configuration) : IPhotoService
{
    private const int ThumbnailSize = 80;
    private const int WebSize = 300;
    private const int WebPQuality = 80;

    private string UploadsPath => configuration.GetValue<string>("UploadsPath") ?? Path.Combine(Directory.GetCurrentDirectory(), "uploads");

    public async Task<string> SavePhotoAsync(string document, Stream imageStream)
    {
        var photosDir = Path.Combine(UploadsPath, "photos");
        Directory.CreateDirectory(photosDir);

        using var memoryStream = new MemoryStream();
        await imageStream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        using var original = SKBitmap.Decode(memoryStream);
        if (original is null)
            throw new ArgumentException("Invalid image file");

        SaveResized(original, Path.Combine(photosDir, $"{document}_thumb.webp"), ThumbnailSize);
        SaveResized(original, Path.Combine(photosDir, $"{document}_web.webp"), WebSize);

        return $"photos/{document}_web.webp";
    }

    public async Task<string> SaveTempPhotoAsync(Stream imageStream)
    {
        var tempId = Guid.NewGuid().ToString("N");
        var photosDir = Path.Combine(UploadsPath, "photos");
        Directory.CreateDirectory(photosDir);

        using var memoryStream = new MemoryStream();
        await imageStream.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        using var original = SKBitmap.Decode(memoryStream);
        if (original is null)
            throw new ArgumentException("Invalid image file");

        SaveResized(original, Path.Combine(photosDir, $"temp_{tempId}_thumb.webp"), ThumbnailSize);
        SaveResized(original, Path.Combine(photosDir, $"temp_{tempId}_web.webp"), WebSize);

        return tempId;
    }

    public string AssignTempPhoto(string tempId, string document)
    {
        var photosDir = Path.Combine(UploadsPath, "photos");

        var tempThumb = Path.Combine(photosDir, $"temp_{tempId}_thumb.webp");
        var tempWeb = Path.Combine(photosDir, $"temp_{tempId}_web.webp");
        var finalThumb = Path.Combine(photosDir, $"{document}_thumb.webp");
        var finalWeb = Path.Combine(photosDir, $"{document}_web.webp");

        if (File.Exists(tempThumb)) File.Move(tempThumb, finalThumb, overwrite: true);
        if (File.Exists(tempWeb)) File.Move(tempWeb, finalWeb, overwrite: true);

        return $"photos/{document}_web.webp";
    }

    public void DeletePhoto(string document)
    {
        var photosDir = Path.Combine(UploadsPath, "photos");
        var thumbPath = Path.Combine(photosDir, $"{document}_thumb.webp");
        var webPath = Path.Combine(photosDir, $"{document}_web.webp");

        if (File.Exists(thumbPath)) File.Delete(thumbPath);
        if (File.Exists(webPath)) File.Delete(webPath);
    }

    private static void SaveResized(SKBitmap original, string outputPath, int targetSize)
    {
        var size = Math.Min(original.Width, original.Height);
        var cropX = (original.Width - size) / 2;
        var cropY = (original.Height - size) / 2;

        using var cropped = new SKBitmap(size, size);
        using (var canvas = new SKCanvas(cropped))
        {
            canvas.DrawBitmap(original,
                new SKRectI(cropX, cropY, cropX + size, cropY + size),
                new SKRect(0, 0, size, size));
        }

        using var resized = cropped.Resize(new SKImageInfo(targetSize, targetSize), new SKSamplingOptions(SKFilterMode.Linear, SKMipmapMode.Linear));
        using var image = SKImage.FromBitmap(resized);
        using var data = image.Encode(SKEncodedImageFormat.Webp, WebPQuality);
        using var fileStream = File.OpenWrite(outputPath);
        data.SaveTo(fileStream);
    }
}
