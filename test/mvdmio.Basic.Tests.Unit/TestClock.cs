using mvdmio.Basic.Extensions;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Tests.Unit;

public class TestClock : IClock
{
   private DateTimeOffset _utcNow = DateTimeOffset.UtcNow.Floor();
   private DateTimeOffset _now = DateTimeOffset.Now.Floor();

   public DateTimeOffset UtcNow
   {
      get => _utcNow;
      set => _utcNow = value.Floor();
   }

   public DateTimeOffset Now
   {
      get => _now;
      set => _now = value.Floor();
   }

   public DateOnly Today { get; set; } = DateOnly.FromDateTime(DateTime.Now);

   public Task Delay(TimeSpan delay, CancellationToken ct = default)
   {
      return Task.CompletedTask;
   }

   public Task Delay(int millisecondsDelay, CancellationToken ct = default)
   {
      return Task.CompletedTask;
   }
}
