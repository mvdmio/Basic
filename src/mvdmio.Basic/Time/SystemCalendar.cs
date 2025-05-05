using System.Globalization;
using mvdmio.Basic.Time.Interfaces;

namespace mvdmio.Basic.Time;

public class SystemCalendar : ICalendar
{
   public Calendar Calendar => CultureInfo.CurrentCulture.Calendar;
}