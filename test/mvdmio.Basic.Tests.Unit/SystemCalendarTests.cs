using AwesomeAssertions;
using mvdmio.Basic.Time;
using Xunit;

namespace mvdmio.Basic.Tests.Unit;

public class SystemCalendarTests
{
   private readonly TestClock _clock;
   private readonly SystemCalendar _calendar;

   public SystemCalendarTests()
   {
      _clock = new TestClock();
      _calendar = new SystemCalendar(_clock);
   }

   [Theory]
   [InlineData("2025-05-05", "2025-05-05")]
   [InlineData("2025-05-06", "2025-05-05")]
   [InlineData("2025-05-07", "2025-05-05")]
   [InlineData("2025-05-08", "2025-05-05")]
   [InlineData("2025-05-09", "2025-05-05")]
   [InlineData("2025-05-10", "2025-05-05")]
   [InlineData("2025-05-11", "2025-05-05")]
   public void StartOfWeek(string date, string expectedStartOfWeek)
   {
      // Arrange
      var input = DateOnly.Parse(date);
      var expected = DateOnly.Parse(expectedStartOfWeek);

      // Act
      var startOfWeek = _calendar.StartOfWeek(input);

      // Assert
      startOfWeek.Should().Be(expected);
   }

   [Fact]
   public void StartOfWeek_ZeroArg_UsesClockToday()
   {
      // Arrange
      _clock.Today = DateOnly.Parse("2025-05-07");
      var expected = DateOnly.Parse("2025-05-05");

      // Act
      var startOfWeek = _calendar.StartOfWeek();

      // Assert
      startOfWeek.Should().Be(expected);
   }

   [Theory]
   [InlineData("2025-05-05", "2025-05-11")]
   [InlineData("2025-05-06", "2025-05-11")]
   [InlineData("2025-05-07", "2025-05-11")]
   [InlineData("2025-05-08", "2025-05-11")]
   [InlineData("2025-05-09", "2025-05-11")]
   [InlineData("2025-05-10", "2025-05-11")]
   [InlineData("2025-05-11", "2025-05-11")]
   public void EndOfWeek(string date, string expectedEndOfWeek)
   {
      // Arrange
      var input = DateOnly.Parse(date);
      var expected = DateOnly.Parse(expectedEndOfWeek);

      // Act
      var endOfWeek = _calendar.EndOfWeek(input);

      // Assert
      endOfWeek.Should().Be(expected);
   }

    [Fact]
    public void EndOfWeek_ZeroArg_UsesClockToday()
    {
       // Arrange
       _clock.Today = DateOnly.Parse("2025-05-07");
       var expected = DateOnly.Parse("2025-05-11");

       // Act
       var endOfWeek = _calendar.EndOfWeek();

       // Assert
       endOfWeek.Should().Be(expected);
    }

    [Theory]
    [InlineData("2025-05-05", 19)]
    [InlineData("2025-05-04", 18)]
    public void IsoWeekNumber(string date, int expectedWeekNumber)
    {
       // Arrange
       var input = DateOnly.Parse(date);

       // Act
       var weekNumber = _calendar.IsoWeekNumber(input);

       // Assert
       weekNumber.Should().Be(expectedWeekNumber);
    }

    [Fact]
    public void IsoWeekNumber_ZeroArg_UsesClockToday()
    {
       // Arrange
       _clock.Today = DateOnly.Parse("2025-05-05");

       // Act
       var weekNumber = _calendar.IsoWeekNumber();

       // Assert
       weekNumber.Should().Be(19);
    }
}
