namespace mvdmio.Basic.Time.Interfaces;

public interface IClock
{
   DateTime Now { get; }
   DateTime UtcNow { get; }
   
   DateOnly Today { get; }
}