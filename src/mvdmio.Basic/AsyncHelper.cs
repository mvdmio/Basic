using JetBrains.Annotations;

namespace mvdmio.Basic;

/// <summary>
///    Provides helper methods for dealing with async methods in sync contexts.
/// </summary>
[PublicAPI]
public static class AsyncHelper
{
   private static readonly TaskFactory _taskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

   /// <summary>
   ///    Runs the given async func synchronously and returns the result.
   /// </summary>
   /// <typeparam name="TResult">The type of the result.</typeparam>
   /// <param name="func">The async func to run synchronously.</param>
   /// <returns>The result of the async func</returns>
   public static TResult RunSync<TResult>(Func<Task<TResult>> func)
   {
      return _taskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
   }

   /// <summary>
   ///    Runs the given async func.
   /// </summary>
   /// <param name="func">The async func to run synchronously.</param>
   public static void RunSync(Func<Task> func)
   {
      _taskFactory.StartNew(func).Unwrap().GetAwaiter().GetResult();
   }
}