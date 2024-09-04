using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;

namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension methods for hashing strings
/// </summary>
[PublicAPI]
public static class HashExtensions
{
   /// <summary>
   ///    Creates a SHA256 hash of the specified input.
   /// </summary>
   public static string Sha256(this string? input)
   {
      if (string.IsNullOrWhiteSpace(input))
         return string.Empty;

      var bytes = Encoding.UTF8.GetBytes(input);
      var hash = SHA256.HashData(bytes);
      
      return Convert.ToBase64String(hash);
   }

   /// <summary>
   ///    Creates a SHA256 hash of the specified input.
   /// </summary>
   public static byte[] Sha256(this byte[] input)
   {
      return SHA256.HashData(input);
   }

   /// <summary>
   ///    Creates a SHA512 hash of the specified input.
   /// </summary>
   public static string Sha512(this string? input)
   {
      if (string.IsNullOrWhiteSpace(input))
         return string.Empty;

      var bytes = Encoding.UTF8.GetBytes(input);
      var hash = SHA512.HashData(bytes);

      return Convert.ToBase64String(hash);
   }
}