namespace mvdmio.Basic.Time.Interfaces;

public interface ICalendar
{
   DateOnly StartOfWeek();
   DateOnly StartOfWeek(DateOnly date);
   DateOnly EndOfWeek();
   DateOnly EndOfWeek(DateOnly date);
   int IsoWeekNumber();
   int IsoWeekNumber(DateOnly date);
}
