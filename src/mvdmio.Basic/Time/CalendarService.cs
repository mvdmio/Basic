using System.Globalization;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

public class CalendarService
{
   private readonly IClock _clock;
   private readonly ICalendar _calendar;

   public CalendarService(IClock clock, ICalendar calendar)
   {
      _clock = clock;
      _calendar = calendar;
   }

   public DateOnly StartOfWeek()
   {
      return StartOfWeek(_clock.Today);
   }

   public DateOnly StartOfWeek(DayOfWeek firstDayOfWeek)
   {
      return StartOfWeek(_clock.Today, firstDayOfWeek);
   }

   public DateOnly StartOfWeek(DateOnly date)
   {
      return StartOfWeek(date, DayOfWeek.Monday);
   }
   
   public DateOnly StartOfWeek(DateOnly date, DayOfWeek firstDayOfWeek)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)firstDayOfWeek + 7) % 7;
      return date.AddDays(-daysOffset);
   }

   public DateOnly EndOfWeek()
   {
      return EndOfWeek(_clock.Today);
   }

   public DateOnly EndOfWeek(DayOfWeek firstDayOfWeek)
   {
      return EndOfWeek(_clock.Today, firstDayOfWeek);
   }
   
   public DateOnly EndOfWeek(DateOnly date)
   {
      return EndOfWeek(date, DayOfWeek.Monday);
   }

   public DateOnly EndOfWeek(DateOnly date, DayOfWeek firstDayOfWeek)
   {
      var daysOffset = ((int)date.DayOfWeek - (int)firstDayOfWeek + 7) % 7;
      return date.AddDays(6 - daysOffset);
   }

   public int IsoWeekNumber()
   {
      return IsoWeekNumber(_clock.Today);
   }
   
   public int IsoWeekNumber(DateOnly date)
   {
      return IsoWeekNumber(date, _calendar.Calendar);
   }
   
   public int IsoWeekNumber(DateOnly date, Calendar calendar)
   {
      return calendar.GetWeekOfYear(date.ToDateTime(TimeOnly.MinValue), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
   }
}