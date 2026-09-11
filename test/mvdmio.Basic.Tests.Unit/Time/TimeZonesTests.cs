using AwesomeAssertions;
using mvdmio.Basic.Time;
using Xunit;

namespace mvdmio.Basic.Tests.Unit.Time;

public class TimeZonesTests
{
   [Fact]
   public void AsUtcInstant_LeavesUtcKind()
   {
      var utc = new DateTime(2024, 7, 14, 23, 0, 0, DateTimeKind.Utc);

      TimeZones.AsUtcInstant(utc).Should().Be(utc);
   }

   [Fact]
   public void AsUtcInstant_TreatsUnspecifiedAsUtc()
   {
      var unspecified = new DateTime(2024, 7, 14, 23, 0, 0, DateTimeKind.Unspecified);

      var utc = TimeZones.AsUtcInstant(unspecified);

      utc.Kind.Should().Be(DateTimeKind.Utc);
      utc.Should().Be(new DateTime(2024, 7, 14, 23, 0, 0, DateTimeKind.Utc));
   }

   [Fact]
   public void TryFind_ReturnsTrue_ForUsableIanaZone()
   {
      TimeZones.TryFind("Europe/Amsterdam", out _).Should().BeTrue();
   }

   [Fact]
   public void TryFind_ReturnsFalse_ForUnknownZone()
   {
      TimeZones.TryFind("Not/AZone", out var zone).Should().BeFalse();
      zone.Should().Be(TimeZoneInfo.Utc);
   }

   [Fact]
   public void TryFind_ReturnsFalse_ForBlank()
   {
      TimeZones.TryFind(" ", out _).Should().BeFalse();
   }
}
