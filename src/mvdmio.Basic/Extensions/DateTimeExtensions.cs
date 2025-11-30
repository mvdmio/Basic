namespace mvdmio.Basic.Extensions;

public static class DateTimeExtensions
{
   extension(DateTime dateTime)
   {
      public DateTime StartOfDay => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
      public DateTime EndOfDay => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
      
      /// <summary>
      ///   Floor the DateTime to the nearest interval. Interval defaults to 1 millisecond if not specified.
      /// </summary>
      public DateTime Floor(TimeSpan? interval = null)
      {
         interval ??= TimeSpan.FromMilliseconds(1);
         return new DateTime(dateTime.Ticks - dateTime.Ticks % interval.Value.Ticks, dateTime.Kind);
      }
   }
}