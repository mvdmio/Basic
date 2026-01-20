namespace mvdmio.Basic.Extensions;

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
   }
}