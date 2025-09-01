namespace mvdmio.Basic.Time.Interfaces;

public interface IClock
{
   DateTime Now { get; }
   DateTime UtcNow { get; }
   
   DateOnly Today { get; }

   Task Delay(TimeSpan delay, CancellationToken ct = default);
   Task Delay(int millisecondsDelay, CancellationToken ct = default);
}