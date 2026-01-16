namespace mvdmio.Basic.Extensions;

public static class QueueExtensions
{
   extension<T>(Queue<T> queue)
   {
      public void EnqueueRange(IEnumerable<T> items)
      {
         foreach (var item in items)
         {
            queue.Enqueue(item);
         }
      }
   }
}