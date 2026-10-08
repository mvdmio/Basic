using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

/// <summary>
///    An <see cref="IClock" /> that reads the system clock.
/// </summary>
public class SystemClock : IClock
{
   /// <inheritdoc />
   public DateTimeOffset Now => DateTimeOffset.Now;
   /// <inheritdoc />
   public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
   /// <inheritdoc />
   public DateOnly Today => DateOnly.FromDateTime(DateTime.Now);
   
   /// <inheritdoc />
   public Task Delay(TimeSpan delay, CancellationToken ct = default)
   {
      return Task.Delay(delay, ct);
   }

   /// <inheritdoc />
   public Task Delay(int millisecondsDelay, CancellationToken ct = default)
   {
      return Task.Delay(millisecondsDelay, ct);
   }
}