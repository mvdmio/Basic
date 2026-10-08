namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension members for <see cref="Queue{T}" />.
/// </summary>
public static class QueueExtensions
{
   extension<T>(Queue<T> queue)
   {
      /// <summary>
      ///    Adds each item to the end of the queue, in order.
      /// </summary>
      /// <param name="items">The items to add.</param>
      public void EnqueueRange(IEnumerable<T> items)
      {
         foreach (var item in items)
         {
            queue.Enqueue(item);
         }
      }
   }
}