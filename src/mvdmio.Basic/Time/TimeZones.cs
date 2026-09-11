namespace mvdmio.Basic.Time;

/// <summary>
///    IANA zone lookup and UTC Instant kind-fix used by Instant display and User Timezone picks.
/// </summary>
public static class TimeZones
{
   public static DateTime AsUtcInstant(DateTime value) =>
      value.Kind switch
      {
         DateTimeKind.Utc => value,
         DateTimeKind.Local => value.ToUniversalTime(),
         _ => DateTime.SpecifyKind(value, DateTimeKind.Utc)
      };

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
