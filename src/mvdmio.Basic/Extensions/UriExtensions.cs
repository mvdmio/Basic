namespace mvdmio.Basic.Extensions;

public static class UriExtensions
{
   extension(Uri uri)
   {
      /// <summary>
      /// Returns the root domain of the URI (e.g., example.com from sub.example.com).
      /// </summary>
      public string RootDomain
      {
         get
         {
            var hostParts = uri.Host.Split('.');
            return hostParts.Length >= 2 ? string.Join('.', hostParts.TakeLast(2)) : uri.Host;
         }
      }
      
      /// <summary>
      ///   Returns true if the root domain of this URI equals the root domain of the other URI.
      /// </summary>
      public bool RootDomainEquals(Uri other)
      {
         return string.Equals(uri.RootDomain, other.RootDomain, StringComparison.OrdinalIgnoreCase);
      }
   }
}