namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension members for <see cref="Uri" />.
/// </summary>
public static class UriExtensions
{
   extension(Uri uri)
   {
      /// <summary>
      /// Returns the root domain of the URI (e.g., example.com from sub.example.com).
      /// Handles two-letter second-level domains (e.g., co.uk) and IP addresses.
      /// </summary>
      public string RootDomain
      {
         get
         {
            var host = uri.Host;
            
            // Check if the host is an IP address
            if (System.Net.IPAddress.TryParse(host, out _))
               return host;
            
            var hostParts = host.Split('.');
            
            // Single part (e.g., localhost)
            if (hostParts.Length < 2)
               return host;
            
            // Check for two-letter second-level domains (e.g., co.uk, com.au, org.uk)
            if (hostParts.Length >= 3 && hostParts[^2].Length <= 3 && hostParts[^1].Length == 2)
               return string.Join('.', hostParts.TakeLast(3));
            
            return string.Join('.', hostParts.TakeLast(2));
         }
      }
      
      /// <summary>
      ///   Returns true if the root domain of this URI equals the root domain of the other URI.
      /// </summary>
      public bool RootDomainEquals(Uri other)
      {
         return string.Equals(uri.RootDomain, other.RootDomain, StringComparison.OrdinalIgnoreCase);
      }
      
      /// <summary>
      ///   Returns the absolute URI without query parameters and fragment.
      /// </summary>
      public string AbsoluteUriBase
      {
         get
         {
            var builder = new UriBuilder(uri) {
               Query = string.Empty,
               Fragment = string.Empty
            };
            
            return builder.Uri.AbsoluteUri;
         }
      }
      
      /// <summary>
      ///   Returns a normalized absolute URI suitable for comparison and deduplication.
      ///   - Removes fragments
      ///   - Keeps query parameters
      ///   - Normalizes scheme and host to lowercase
      ///   - Removes default ports (80 for HTTP, 443 for HTTPS)
      ///   - Removes trailing slash from path (except for root path)
      /// </summary>
      public string NormalizedAbsoluteUri
      {
         get
         {
            var builder = new UriBuilder(uri) {
               Scheme = uri.Scheme.ToLowerInvariant(),
               Host = uri.Host.ToLowerInvariant(),
               Fragment = string.Empty
            };
            
            // Remove default ports
            if ((builder.Scheme == "http" && builder.Port == 80) ||
                (builder.Scheme == "https" && builder.Port == 443))
            {
               builder.Port = -1;
            }
            
            // Remove trailing slash from path (but keep root path as "/")
            if (builder.Path.Length > 1 && builder.Path.EndsWith('/'))
            {
               builder.Path = builder.Path.TrimEnd('/');
            }
            
            return builder.Uri.AbsoluteUri;
         }
      }
   }
}