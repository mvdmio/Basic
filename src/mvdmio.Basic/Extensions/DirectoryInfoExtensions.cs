namespace mvdmio.Basic.Extensions;

public static class DirectoryInfoExtensions
{
   public static void RecursiveCreate(this DirectoryInfo directory)
   {
      if (directory.Parent?.Exists is false)
         directory.Parent.RecursiveCreate();

      if (directory.Exists is false)
         directory.Create();
   }

   public static void ForceDelete(this DirectoryInfo directory)
   {
      if (!directory.Exists)
         return; // Nothing to delete

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
   
   public static DirectoryInfo Combine(this DirectoryInfo directory, params string[] paths)
   {
      var combiner = new List<string>();
      combiner.Add(directory.FullName);
      combiner.AddRange(paths);

      var combined = Path.Combine(combiner.ToArray());
      return new DirectoryInfo(combined);
   }

   public static DirectoryInfo Combine(this DirectoryInfo directory, params DirectoryInfo[] paths)
   {
      var combiner = new List<string>();
      combiner.Add(directory.FullName);
      combiner.AddRange(paths.Select(x => x.FullName));

      var combined = Path.Combine(combiner.ToArray());
      return new DirectoryInfo(combined);
   }
}