namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension methods for <see cref="string" />.
/// </summary>
public static class StringExtensions
{
   /// <summary>
   ///    Returns the string with its first character in upper case, using the current culture. Returns <c>null</c> for <c>null</c>.
   /// </summary>
   /// <param name="str">The string to capitalize.</param>
   public static string? Capitalize(this string? str)
   {
      if (str is null)
         return null;
      
      if(str == string.Empty)
         return str;
      
      var first = char.ToUpper(str[0]);
      
      if (str.Length == 1)
         return first.ToString();

      if (first == str[0])
         return str;

      return string.Create(str.Length, (first, str), static (span, state) => {
         span[0] = state.first;
         state.str.AsSpan(1).CopyTo(span[1..]);
      });
   }
}