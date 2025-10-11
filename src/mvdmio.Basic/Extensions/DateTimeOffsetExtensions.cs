namespace mvdmio.Basic.Extensions;

public static class DateTimeOffsetExtensions
{
   /// <summary>
   ///   Floor the DateTime to the nearest interval. Interval defaults to 1 millisecond if not specified.
   /// </summary>
   public static DateTimeOffset Floor(this DateTimeOffset dateTimeOffset, TimeSpan? interval = null)
   {
      interval ??= TimeSpan.FromMilliseconds(1);
      return new DateTimeOffset(dateTimeOffset.Ticks - dateTimeOffset.Ticks % interval.Value.Ticks, dateTimeOffset.Offset);
   }
}