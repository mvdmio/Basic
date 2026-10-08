namespace mvdmio.Basic.Time.Interfaces;

/// <summary>
///    Gives the current time and waits for a span of time. Inject it in place of <see cref="DateTimeOffset.Now" /> and <see cref="Task.Delay(TimeSpan)" /> so tests can control time.
/// </summary>
public interface IClock
{
   /// <summary>
   ///    The current date and time in the local time zone.
   /// </summary>
   DateTimeOffset Now { get; }

   /// <summary>
   ///    The current date and time in UTC.
   /// </summary>
   DateTimeOffset UtcNow { get; }
   
   /// <summary>
   ///    The current date in the local time zone.
   /// </summary>
   DateOnly Today { get; }

   /// <summary>
   ///    Waits for the given span of time.
   /// </summary>
   /// <param name="delay">How long to wait.</param>
   /// <param name="ct">Cancels the wait.</param>
   Task Delay(TimeSpan delay, CancellationToken ct = default);

   /// <summary>
   ///    Waits for the given number of milliseconds.
   /// </summary>
   /// <param name="millisecondsDelay">How many milliseconds to wait.</param>
   /// <param name="ct">Cancels the wait.</param>
   Task Delay(int millisecondsDelay, CancellationToken ct = default);
}