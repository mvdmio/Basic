namespace mvdmio.Basic.Time.Interfaces;

/// <summary>
///    Week calculations, with weeks running Monday to Sunday.
/// </summary>
public interface ICalendar
{
   /// <summary>
   ///    The Monday of the current week.
   /// </summary>
   DateOnly StartOfWeek();

   /// <summary>
   ///    The Monday of the week that holds <paramref name="date" />.
   /// </summary>
   /// <param name="date">A date in the week.</param>
   DateOnly StartOfWeek(DateOnly date);

   /// <summary>
   ///    The Sunday of the current week.
   /// </summary>
   DateOnly EndOfWeek();

   /// <summary>
   ///    The Sunday of the week that holds <paramref name="date" />.
   /// </summary>
   /// <param name="date">A date in the week.</param>
   DateOnly EndOfWeek(DateOnly date);

   /// <summary>
   ///    The ISO 8601 week number of the current week.
   /// </summary>
   int IsoWeekNumber();

   /// <summary>
   ///    The ISO 8601 week number of the week that holds <paramref name="date" />.
   /// </summary>
   /// <param name="date">A date in the week.</param>
   int IsoWeekNumber(DateOnly date);
}
