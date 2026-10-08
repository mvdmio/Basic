namespace mvdmio.Basic.Time;

/// <summary>
///    Time zone lookup by id, and conversion of a <see cref="DateTime" /> to UTC by its <see cref="DateTime.Kind" />.
/// </summary>
public static class TimeZones
{
   /// <summary>
   ///    Returns <paramref name="value" /> as a UTC <see cref="DateTime" />. A local value is converted to UTC; a value of unspecified kind is taken to be UTC already.
   /// </summary>
   /// <param name="value">The value to convert.</param>
   public static DateTime AsUtcInstant(DateTime value) =>
      value.Kind switch
      {
         DateTimeKind.Utc => value,
         DateTimeKind.Local => value.ToUniversalTime(),
         _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
      };

   /// <summary>
   ///    Finds the time zone with the given IANA or Windows id.
   /// </summary>
   /// <param name="zoneId">The time zone id, such as <c>Europe/Amsterdam</c>.</param>
   /// <param name="timeZone">The time zone found, or <see cref="TimeZoneInfo.Utc" /> when none is found.</param>
   /// <returns><c>true</c> when a time zone with that id exists; <c>false</c> when the id is empty, unknown, or invalid.</returns>
   public static bool TryFind(string? zoneId, out TimeZoneInfo timeZone)
   {
      if (string.IsNullOrWhiteSpace(zoneId))
      {
         timeZone = TimeZoneInfo.Utc;
         return false;
      }

      try
      {
         timeZone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
         return true;
      }
      catch (TimeZoneNotFoundException)
      {
         timeZone = TimeZoneInfo.Utc;
         return false;
      }
      catch (InvalidTimeZoneException)
      {
         timeZone = TimeZoneInfo.Utc;
         return false;
      }
   }
}
