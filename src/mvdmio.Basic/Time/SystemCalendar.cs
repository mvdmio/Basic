using System.Globalization;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

/// <summary>
///    An <see cref="ICalendar" /> that takes the current date from an <see cref="IClock" />.
/// </summary>
public class SystemCalendar : ICalendar
{
   private readonly IClock _clock;
   private readonly GregorianCalendar _gregorianCalendar = new();

   /// <summary>
   ///    Creates a calendar that reads the system clock.
   /// </summary>
   public SystemCalendar()
      : this(new SystemClock())
   {
   }

   /// <summary>
   ///    Creates a calendar that takes the current date from <paramref name="clock" />.
   /// </summary>
   /// <param name="clock">The clock that gives the current date.</param>
   public SystemCalendar(IClock clock)
   {
      _clock = clock;
   }

   /// <inheritdoc />
   public DateOnly StartOfWeek()
   {
      return StartOfWeek(_clock.Today);
   }

   /// <inheritdoc />
   public DateOnly StartOfWeek(DateOnly date)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
      return date.AddDays(-daysOffset);
   }

   /// <inheritdoc />
   public DateOnly EndOfWeek()
   {
      return EndOfWeek(_clock.Today);
   }

   /// <inheritdoc />
   public DateOnly EndOfWeek(DateOnly date)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
      return date.AddDays(6 - daysOffset);
   }

   /// <inheritdoc />
   public int IsoWeekNumber()
   {
      return IsoWeekNumber(_clock.Today);
   }

   /// <inheritdoc />
   public int IsoWeekNumber(DateOnly date)
   {
      return _gregorianCalendar.GetWeekOfYear(date.ToDateTime(TimeOnly.MinValue), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
   }
}
