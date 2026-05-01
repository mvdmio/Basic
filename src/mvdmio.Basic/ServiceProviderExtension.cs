using Microsoft.Extensions.DependencyInjection;
using mvdmio.Basic.Time;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic;

public static class ServiceProviderExtension
{
   public static void AddBasic(this IServiceCollection services)
   {
      services.AddSingleton<IClock, SystemClock>();
      services.AddSingleton<ICalendar, SystemCalendar>();
   }
}
