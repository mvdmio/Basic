using FluentAssertions;
using mvdmio.Basic.Time;
using mvdmio.UnitTest.Common.xUnit;

namespace mvdmio.Basic.Tests.Unit;

public class CalendarServiceTests
{
   private readonly TestClock _clock;
   private readonly TestCalendar _calendar;
   private readonly CalendarService _calendarService;
   

   public CalendarServiceTests()
   {
      _clock = new TestClock();
      _calendar = new TestCalendar();
      _calendarService = new CalendarService(_clock, _calendar);
   }
   
   [Theory]
   [InlineData("2025-05-05", "2025-05-05", DayOfWeek.Monday)]
   [InlineData("2025-05-05", "2025-05-04", DayOfWeek.Sunday)]
   public void StartOfWeek(string date, string expectedStartOfWeek, DayOfWeek firstDayOfWeek)
   {
      // Arrange
      var input = DateOnly.Parse(date);
      var expected = DateOnly.Parse(expectedStartOfWeek);
      
      // Act
      var startOfWeek = _calendarService.StartOfWeek(input, firstDayOfWeek);
      
      // Assert
      startOfWeek.Should().Be(expected);
   }
   
   [Theory]
   [InlineData("2025-05-05", "2025-05-11", DayOfWeek.Monday)]
   [InlineData("2025-05-05", "2025-05-10", DayOfWeek.Sunday)]
   public void EndOfWeek(string date, string expectedStartOfWeek, DayOfWeek firstDayOfWeek)
   {
      // Arrange
      var input = DateOnly.Parse(date);
      var expected = DateOnly.Parse(expectedStartOfWeek);
      
      // Act
      var startOfWeek = _calendarService.EndOfWeek(input, firstDayOfWeek);
      
      // Assert
      startOfWeek.Should().Be(expected);
   }
   
   [Theory]
   [InlineData("2025-05-05", 19)]
   [InlineData("2025-05-04", 18)]
   public void IsoWeekNumber(string date, int expectedWeekNumber)
   {
      // Arrange
      var input = DateOnly.Parse(date);
      
      // Act
      var startOfWeek = _calendarService.IsoWeekNumber(input);
      
      // Assert
      startOfWeek.Should().Be(expectedWeekNumber);
   }
}