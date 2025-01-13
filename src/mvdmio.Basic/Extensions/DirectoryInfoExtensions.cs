namespace mvdmio.Basic.Extensions;

public static class DirectoryInfoExtensions
{
   public static void RecursiveCreate(this DirectoryInfo directory)
   {
      if (directory.Parent is not null)
         directory.Parent.RecursiveCreate();
      
      if (directory.Exists is false)
         directory.Create();
   }
}