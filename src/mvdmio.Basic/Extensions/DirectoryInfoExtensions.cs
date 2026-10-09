namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension methods for <see cref="DirectoryInfo" />.
/// </summary>
public static class DirectoryInfoExtensions
{
   /// <summary>
   ///    Creates the directory and any missing parent directories.
   /// </summary>
   /// <param name="directory">The directory to create.</param>
   public static void RecursiveCreate(this DirectoryInfo directory)
   {
      if (directory.Parent?.Exists is false)
         directory.Parent.RecursiveCreate();

      if (directory.Exists is false)
         directory.Create();
   }

   /// <summary>
   ///    Deletes the directory and everything in it, including read-only files and directories. Does nothing when the directory does not exist.
   /// </summary>
   /// <param name="directory">The directory to delete.</param>
   public static void ForceDelete(this DirectoryInfo directory)
   {
      if (!directory.Exists)
         return; // Nothing to delete

      // Ensure the directory is refreshed to get the latest attributes
      directory.Refresh();
      
      // Clear read-only on the top-level directory
      directory.Attributes = FileAttributes.Normal;

      // Recursively clear read-only on all subdirectories
      foreach (var subDir in directory.GetDirectories("*", SearchOption.AllDirectories))
      {
         subDir.Attributes = FileAttributes.Normal;
      }

      // Recursively clear read-only on all files
      foreach (var file in directory.GetFiles("*", SearchOption.AllDirectories))
      {
         file.Attributes = FileAttributes.Normal;
      }

      // Now delete recursively
      directory.Delete(true);
   }
   
   /// <summary>
   ///    Combines the directory's full path with <paramref name="paths" />, as <see cref="Path.Combine(string[])" /> does.
   /// </summary>
   /// <param name="directory">The base directory.</param>
   /// <param name="paths">The path parts to append.</param>
   public static DirectoryInfo Combine(this DirectoryInfo directory, params string[] paths)
   {
      var combiner = new List<string>();
      combiner.Add(directory.FullName);
      combiner.AddRange(paths);

      var combined = Path.Combine(combiner.ToArray());
      return new DirectoryInfo(combined);
   }
}