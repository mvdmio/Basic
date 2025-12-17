using System.Globalization;

namespace mvdmio.Basic.Extensions;

public static class DateTimeExtensions
{
   extension(DateTime dateTime)
   {
      /// <summary>
      ///   Gets the start of the day for the given DateTime.
      /// </summary>
      public DateTime StartOfDay => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
      
      /// <summary>
      ///   Gets the end of the day for the given DateTime.
      /// </summary>
      public DateTime EndOfDay => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day + 1, 0, 0, 0, dateTime.Kind).Subtract(TimeSpan.FromTicks(1));
      
      /// <summary>
      ///   Gets the start of the week (Monday) for the given DateTime.
      /// </summary>
      public DateTime StartOfWeek
      {
         get
         {
            var diff = (7 + (dateTime.DayOfWeek - DayOfWeek.Monday)) % 7;
            var startOfWeek = dateTime.AddDays(-1 * diff);
            return new DateTime(startOfWeek.Year, startOfWeek.Month, startOfWeek.Day, 0, 0, 0, dateTime.Kind);   
         }
      }
      
      /// <summary>
      ///   Gets the end of the week (Sunday) for the given DateTime.
      /// </summary>
      public DateTime EndOfWeek
      {
         get
         {
            var startOfWeek = dateTime.StartOfWeek;
            var endOfWeek = startOfWeek.AddDays(7);
            return new DateTime(endOfWeek.Year, endOfWeek.Month, endOfWeek.Day, 0, 0, 0, dateTime.Kind).Subtract(TimeSpan.FromTicks(1));   
         }
      }
      
      /// <summary>
      ///   Gets the start of the month for the given DateTime.
      /// </summary>
      public DateTime StartOfMonth => new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, dateTime.Kind);
      
      /// <summary>
      ///   Gets the end of the month for the given DateTime.
      /// </summary>
      public DateTime EndOfMonth
      {
         get
         {
            var daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return new DateTime(dateTime.Year, dateTime.Month, daysInMonth, 0, 0, 0, dateTime.Kind).Subtract(TimeSpan.FromTicks(1));
         }
      }
      
      /// <summary>
      ///   Gets the start of the year for the given DateTime.
      /// </summary>
      public DateTime StartOfYear => new DateTime(dateTime.Year, 1, 1, 0, 0, 0, dateTime.Kind);
      
      /// <summary>
      ///   Gets the end of the year for the given DateTime.
      /// </summary>
      public DateTime EndOfYear => new DateTime(dateTime.Year + 1, 1, 1, 0, 0, 0, dateTime.Kind).Subtract(TimeSpan.FromTicks(1));
      
      /// <summary>
      ///   Gets the ISO 8601 week number for the given DateTime.
      /// </summary>
      public int WeekNumber => ISOWeek.GetWeekOfYear(dateTime);
      
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