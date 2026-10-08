namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension methods for <see cref="FileInfo" />.
/// </summary>
public static class FileInfoExtensions
{
   /// <summary>
   ///    Reads the whole file as text.
   /// </summary>
   /// <param name="file">The file to read.</param>
   /// <param name="ct">Cancels the read.</param>
   /// <exception cref="FileNotFoundException">The file does not exist.</exception>
   public static async Task<string> ReadAllTextAsync(this FileInfo file, CancellationToken ct = default)
   {
      if (!file.Exists)
         throw new FileNotFoundException($"File '{file.FullName}' does not exist.");

      using var reader = file.OpenText();
      return await reader.ReadToEndAsync(ct);
   }
}