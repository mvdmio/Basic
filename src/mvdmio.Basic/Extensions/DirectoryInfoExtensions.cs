namespace mvdmio.Basic.Extensions;

public static class DirectoryInfoExtensions
{
   public static void RecursiveCreate(this DirectoryInfo directory)
   {
      if (directory.Parent is not null && directory.Parent.Exists is false)
         directory.Parent.RecursiveCreate();

      if (directory.Exists is false)
         directory.Create();
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