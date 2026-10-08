using System.Text.Json;
using JetBrains.Annotations;

namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension methods for <see cref="IEnumerable{T}" />
/// </summary>
[PublicAPI]
public static class EnumerableExtensions
{
   /// <summary>
   ///    Creates a new enumerable that contains the elements of the original enumerable and adds the index for each element.
   /// </summary>
   /// <example>
   ///    foreach(var (item, index) in enumerable.WithIndex()) { }
   /// </example>
   public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> enumerable)
   {
      return enumerable.Select((item, index) => (item, index));
   }

   /// <summary>
   ///    Converts an enumerable to a JSON string.
   /// </summary>
   public static string ToJson<T>(this IEnumerable<T> enumerable)
   {
      var stringValues = enumerable.Select(x => JsonSerializer.Serialize(x));
      return $"[{string.Join(", ", stringValues)}]";
   }
}