namespace mvdmio.Basic.Extensions;

public static class StringExtensions
{
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