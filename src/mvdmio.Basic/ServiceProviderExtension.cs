using Microsoft.Extensions.DependencyInjection;
using mvdmio.Basic.Time;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic;

/// <summary>
///    Registers the library's services with dependency injection.
/// </summary>
public static class ServiceProviderExtension
{
   /// <summary>
   ///    Registers <see cref="SystemClock" /> as <see cref="IClock" /> and <see cref="SystemCalendar" /> as <see cref="ICalendar" />, both as singletons.
   /// </summary>
   /// <param name="services">The service collection to add the services to.</param>
   public static void AddBasic(this IServiceCollection services)
   {
      services.AddSingleton<IClock, SystemClock>();
      services.AddSingleton<ICalendar, SystemCalendar>();
   }
}
