namespace LarQ.Configuration;

public class FileOptionModel
{
    public const string FileOption = "FileOptions";

    public string WwwRootImagePath { get; set; } = string.Empty;
    public string AllowedImageExtensions { get; set; } = string.Empty;
    public string AllowedAudioExtensions { get; set; } = string.Empty;
    public int MaxImageSizeInMb { get; set; }
    public int MaxAudioSizeInMb { get; set; }
}