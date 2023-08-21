namespace VideoPlatform.API.Service;

public class ShortGuid
{
    public static String generateShortGUID()
    {
        Guid guid = Guid.NewGuid();
        string shortGuid = Convert.ToBase64String(guid.ToByteArray());
        shortGuid = shortGuid.Replace("/", "_").Replace("+", "-").TrimEnd('=');
        return shortGuid;
    }
}