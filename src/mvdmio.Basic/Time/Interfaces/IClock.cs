namespace mvdmio.Basic.Time.Interfaces;

public interface IClock
{
   DateTimeOffset Now { get; }
   DateTimeOffset UtcNow { get; }
   
   DateOnly Today { get; }

   Task Delay(TimeSpan delay, CancellationToken ct = default);
   Task Delay(int millisecondsDelay, CancellationToken ct = default);
}