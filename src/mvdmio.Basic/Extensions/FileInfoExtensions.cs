namespace mvdmio.Basic.Extensions;

public static class FileInfoExtensions
{
   public static async Task<string> ReadAllTextAsync(this FileInfo file, CancellationToken ct = default)
   {
      if (!file.Exists)
         throw new FileNotFoundException($"File '{file.FullName}' does not exist.");

      using var reader = file.OpenText();
      return await reader.ReadToEndAsync(ct);
   }
}