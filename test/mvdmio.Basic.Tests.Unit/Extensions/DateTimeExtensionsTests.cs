using AwesomeAssertions;
using mvdmio.Basic.Extensions;

namespace mvdmio.Basic.Tests.Unit.Extensions;

public class DateTimeExtensionsTests
{
   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-05-15T00:00:00")]
   [InlineData("2025-05-15T00:00:00", "2025-05-15T00:00:00")]
   [InlineData("2025-05-15T23:59:59.999", "2025-05-15T00:00:00")]
   [InlineData("2025-12-31T10:30:45", "2025-12-31T00:00:00")]
   [InlineData("2025-01-01T10:30:45", "2025-01-01T00:00:00")]
   public void StartOfDay(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.StartOfDay.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-05-15T23:59:59.9999999")]
   [InlineData("2025-05-15T00:00:00", "2025-05-15T23:59:59.9999999")]
   [InlineData("2025-05-15T23:59:59.999", "2025-05-15T23:59:59.9999999")]
   public void EndOfDay(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.EndOfDay.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-05T10:30:45", "2025-05-05T00:00:00")]
   [InlineData("2025-05-06T10:30:45", "2025-05-05T00:00:00")]
   [InlineData("2025-05-04T10:30:45", "2025-04-28T00:00:00")]
   [InlineData("2025-05-03T10:30:45", "2025-04-28T00:00:00")]
   [InlineData("2025-05-07T10:30:45", "2025-05-05T00:00:00")]
   public void StartOfWeek(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.StartOfWeek.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-05T10:30:45", "2025-05-11T23:59:59.9999999")]
   [InlineData("2025-05-04T10:30:45", "2025-05-04T23:59:59.9999999")]
   [InlineData("2025-05-06T10:30:45", "2025-05-11T23:59:59.9999999")]
   public void EndOfWeek(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.EndOfWeek.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-05-01T00:00:00")]
   [InlineData("2025-05-01T10:30:45", "2025-05-01T00:00:00")]
   [InlineData("2025-05-31T10:30:45", "2025-05-01T00:00:00")]
   [InlineData("2025-01-15T10:30:45", "2025-01-01T00:00:00")]
   [InlineData("2025-12-15T10:30:45", "2025-12-01T00:00:00")]
   public void StartOfMonth(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.StartOfMonth.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-05-31T23:59:59.9999999")]
   [InlineData("2025-01-15T10:30:45", "2025-01-31T23:59:59.9999999")]
   [InlineData("2025-02-15T10:30:45", "2025-02-28T23:59:59.9999999")]
   [InlineData("2025-04-15T10:30:45", "2025-04-30T23:59:59.9999999")]
   [InlineData("2025-06-15T10:30:45", "2025-06-30T23:59:59.9999999")]
   [InlineData("2025-12-15T10:30:45", "2025-12-31T23:59:59.9999999")]
   public void EndOfMonth_NonLeapYear(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.EndOfMonth.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2024-02-15T10:30:45", "2024-02-29T23:59:59.9999999")]
   [InlineData("2024-01-15T10:30:45", "2024-01-31T23:59:59.9999999")]
   [InlineData("2024-02-29T23:59:59", "2024-02-29T23:59:59.9999999")]
   [InlineData("2024-03-01T00:00:00", "2024-03-31T23:59:59.9999999")]
   public void EndOfMonth_LeapYear(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.EndOfMonth.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-01-01T00:00:00")]
   [InlineData("2025-01-15T10:30:45", "2025-01-01T00:00:00")]
   [InlineData("2025-12-31T23:59:59", "2025-01-01T00:00:00")]
   [InlineData("2025-01-01T00:00:00", "2025-01-01T00:00:00")]
   public void StartOfYear(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.StartOfYear.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45", "2025-12-31T23:59:59.9999999")]
   [InlineData("2025-12-31T23:59:59", "2025-12-31T23:59:59.9999999")]
   [InlineData("2025-01-01T00:00:00", "2025-12-31T23:59:59.9999999")]
   [InlineData("2024-12-31T10:30:45", "2024-12-31T23:59:59.9999999")]
   public void EndOfYear(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.EndOfYear.Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-05", 19)]
   [InlineData("2025-01-01", 1)]
   [InlineData("2025-12-31", 1)]
   [InlineData("2025-05-04", 18)]
   [InlineData("2024-12-30", 1)]
   [InlineData("2024-12-31", 1)]
   [InlineData("2020-12-31", 53)]
   public void WeekNumber(string input, int expectedWeekNumber)
   {
      var dateTime = DateTime.Parse(input);
      dateTime.WeekNumber.Should().Be(expectedWeekNumber);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45.123", "2025-05-15T10:30:45.000", 1000)]
   [InlineData("2025-05-15T10:30:45.567", "2025-05-15T10:30:45.500", 500)]
   [InlineData("2025-05-15T10:30:45.789", "2025-05-15T10:30:40.000", 10000)]
   public void Floor_WithInterval(string input, string expected, int intervalMs)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      var interval = TimeSpan.FromMilliseconds(intervalMs);
      dateTime.Floor(interval).Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2025-05-15T10:30:45.123456", "2025-05-15T10:30:45.123000")]
   public void Floor_Default(string input, string expected)
   {
      var dateTime = DateTime.Parse(input);
      var expectedDateTime = DateTime.Parse(expected);
      dateTime.Floor().Should().Be(expectedDateTime);
   }

   [Theory]
   [InlineData("2024-02-29T10:30:45", "2024-02-01T00:00:00", "2024-02-29T23:59:59.9999999")]
   [InlineData("2024-02-01T00:00:00", "2024-02-01T00:00:00", "2024-02-29T23:59:59.9999999")]
   public void LeapYear_February(string input, string expectedStart, string expectedEnd)
   {
      var dateTime = DateTime.Parse(input);
      var expectedStartDateTime = DateTime.Parse(expectedStart);
      var expectedEndDateTime = DateTime.Parse(expectedEnd);
      
      dateTime.StartOfMonth.Should().Be(expectedStartDateTime);
      dateTime.EndOfMonth.Should().Be(expectedEndDateTime);
   }

   [Theory]
   [InlineData("2023-02-28T10:30:45", "2023-02-01T00:00:00", "2023-02-28T23:59:59.9999999")]
   public void NonLeapYear_February(string input, string expectedStart, string expectedEnd)
   {
      var dateTime = DateTime.Parse(input);
      var expectedStartDateTime = DateTime.Parse(expectedStart);
      var expectedEndDateTime = DateTime.Parse(expectedEnd);
      
      dateTime.StartOfMonth.Should().Be(expectedStartDateTime);
      dateTime.EndOfMonth.Should().Be(expectedEndDateTime);
   }

   [Theory]
   [InlineData("2024-12-31T23:59:59", "2024-01-01T00:00:00", "2024-12-31T23:59:59.9999999")]
   [InlineData("2024-01-01T00:00:00", "2024-01-01T00:00:00", "2024-12-31T23:59:59.9999999")]
   public void LeapYear_StartEndOfYear(string input, string expectedStart, string expectedEnd)
   {
      var dateTime = DateTime.Parse(input);
      var expectedStartDateTime = DateTime.Parse(expectedStart);
      var expectedEndDateTime = DateTime.Parse(expectedEnd);
      
      dateTime.StartOfYear.Should().Be(expectedStartDateTime);
      dateTime.EndOfYear.Should().Be(expectedEndDateTime);
   }

   [Fact]
   public void StartOfDay_PreservesKind()
   {
      var utcDateTime = new DateTime(2025, 5, 15, 10, 30, 45, DateTimeKind.Utc);
      var localDateTime = new DateTime(2025, 5, 15, 10, 30, 45, DateTimeKind.Local);
      var unspecifiedDateTime = new DateTime(2025, 5, 15, 10, 30, 45, DateTimeKind.Unspecified);
      
      utcDateTime.StartOfDay.Kind.Should().Be(DateTimeKind.Utc);
      localDateTime.StartOfDay.Kind.Should().Be(DateTimeKind.Local);
      unspecifiedDateTime.StartOfDay.Kind.Should().Be(DateTimeKind.Unspecified);
   }

   [Fact]
   public void StartOfWeek_MondayReturnsSameDay()
   {
      var monday = new DateTime(2025, 5, 5, 10, 30, 45);
      monday.StartOfWeek.Should().Be(new DateTime(2025, 5, 5, 0, 0, 0));
   }

   [Fact]
   public void StartOfWeek_SundayReturnsPreviousMonday()
   {
      var sunday = new DateTime(2025, 5, 4, 10, 30, 45);
      sunday.StartOfWeek.Should().Be(new DateTime(2025, 4, 28, 0, 0, 0));
   }

   [Fact]
   public void EndOfWeek_ReturnsSunday()
   {
      var monday = new DateTime(2025, 5, 5, 0, 0, 0);
      var expectedEnd = new DateTime(2025, 5, 11, 23, 59, 59, 999).AddTicks(9999);
      monday.EndOfWeek.Should().Be(expectedEnd);
   }

   [Theory]
   [InlineData("2025-04-30T10:30:45", "2025-04-01T00:00:00", "2025-04-30T23:59:59.9999999")]
   [InlineData("2025-06-30T10:30:45", "2025-06-01T00:00:00", "2025-06-30T23:59:59.9999999")]
   [InlineData("2025-09-30T10:30:45", "2025-09-01T00:00:00", "2025-09-30T23:59:59.9999999")]
   [InlineData("2025-11-30T10:30:45", "2025-11-01T00:00:00", "2025-11-30T23:59:59.9999999")]
   public void MonthBoundary_30Days(string input, string expectedStart, string expectedEnd)
   {
      var dateTime = DateTime.Parse(input);
      var expectedStartDateTime = DateTime.Parse(expectedStart);
      var expectedEndDateTime = DateTime.Parse(expectedEnd);
      
      dateTime.StartOfMonth.Should().Be(expectedStartDateTime);
      dateTime.EndOfMonth.Should().Be(expectedEndDateTime);
   }

   [Theory]
   [InlineData("2025-01-31T10:30:45", "2025-01-01T00:00:00", "2025-01-31T23:59:59.9999999")]
   [InlineData("2025-03-31T10:30:45", "2025-03-01T00:00:00", "2025-03-31T23:59:59.9999999")]
   [InlineData("2025-05-31T10:30:45", "2025-05-01T00:00:00", "2025-05-31T23:59:59.9999999")]
   [InlineData("2025-07-31T10:30:45", "2025-07-01T00:00:00", "2025-07-31T23:59:59.9999999")]
   [InlineData("2025-08-31T10:30:45", "2025-08-01T00:00:00", "2025-08-31T23:59:59.9999999")]
   [InlineData("2025-10-31T10:30:45", "2025-10-01T00:00:00", "2025-10-31T23:59:59.9999999")]
   [InlineData("2025-12-31T10:30:45", "2025-12-01T00:00:00", "2025-12-31T23:59:59.9999999")]
   public void MonthBoundary_31Days(string input, string expectedStart, string expectedEnd)
   {
      var dateTime = DateTime.Parse(input);
      var expectedStartDateTime = DateTime.Parse(expectedStart);
      var expectedEndDateTime = DateTime.Parse(expectedEnd);
      
      dateTime.StartOfMonth.Should().Be(expectedStartDateTime);
      dateTime.EndOfMonth.Should().Be(expectedEndDateTime);
   }
}
