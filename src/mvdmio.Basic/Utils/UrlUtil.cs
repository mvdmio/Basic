namespace mvdmio.Basic.Utils;

/// <summary>
/// URL utilities
/// </summary>
public class UrlUtil
{
   /// <summary>
   /// Check if the URL is local.
   /// A URL is considered local if it starts with a slash (/) or a dot-slash (./).
   /// </summary>
   public static bool IsLocal(string url)
   {
      return url.StartsWith("/") || url.StartsWith("./");
   }

   /// <summary>
   /// Normalize the URL.
   /// Normalized URLS start with 'http://', 'https://', '/', or './'.
   /// Normalized URLS always end without a trailing slash.
   /// </summary>
   public static string Normalize(string? url)
   {
      if (string.IsNullOrWhiteSpace(url))
         throw new ArgumentNullException(nameof(url));

      if (!IsLocal(url) && !url.StartsWith("http://") && !url.StartsWith("https://"))
         url = $"https://{url}";

      while(url.EndsWith("/"))
         url = url.Substring(0, url.Length - 1);

      return url;
   }
}