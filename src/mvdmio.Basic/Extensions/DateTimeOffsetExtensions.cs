namespace mvdmio.Basic.Extensions;

/// <summary>
///    Extension members for <see cref="DateTimeOffset" />.
/// </summary>
public static class DateTimeOffsetExtensions
{
   extension(DateTimeOffset dateTimeOffset)
   {
      DateTimeOffset StartOfDay => new DateTimeOffset( dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 0, 0, 0, dateTimeOffset.Offset);
      DateTimeOffset EndOfDay => new DateTimeOffset( dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 23, 59, 59, dateTimeOffset.Offset);
      
      /// <summary>
      ///   Floor the DateTimeOffset to the nearest interval. Interval defaults to 1 millisecond if not specified.
      /// </summary>
      public DateTimeOffset Floor(TimeSpan? interval = null)
      {
         interval ??= TimeSpan.FromMilliseconds(1);
         return new DateTimeOffset(dateTimeOffset.Ticks - dateTimeOffset.Ticks % interval.Value.Ticks, dateTimeOffset.Offset);
      }
   }
}