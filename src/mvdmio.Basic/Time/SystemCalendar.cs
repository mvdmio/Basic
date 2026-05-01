using System.Globalization;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

public class SystemCalendar : ICalendar
{
   private readonly IClock _clock;
   private readonly GregorianCalendar _gregorianCalendar = new();

   public SystemCalendar()
      : this(new SystemClock())
   {
   }

   public SystemCalendar(IClock clock)
   {
      _clock = clock;
   }

   public DateOnly StartOfWeek()
   {
      return StartOfWeek(_clock.Today);
   }

   public DateOnly StartOfWeek(DateOnly date)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
      return date.AddDays(-daysOffset);
   }

   public DateOnly EndOfWeek()
   {
      return EndOfWeek(_clock.Today);
   }

   public DateOnly EndOfWeek(DateOnly date)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
      return date.AddDays(6 - daysOffset);
   }

   public int IsoWeekNumber()
   {
      return IsoWeekNumber(_clock.Today);
   }

   public int IsoWeekNumber(DateOnly date)
   {
      return _gregorianCalendar.GetWeekOfYear(date.ToDateTime(TimeOnly.MinValue), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
   }
}
