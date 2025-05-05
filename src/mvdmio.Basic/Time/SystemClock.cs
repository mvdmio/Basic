using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

public class SystemClock : IClock
{
   public DateTime Now => DateTime.Now;
   public DateTime UtcNow => DateTime.UtcNow;
   public DateOnly Today => DateOnly.FromDateTime(DateTime.Now);
}