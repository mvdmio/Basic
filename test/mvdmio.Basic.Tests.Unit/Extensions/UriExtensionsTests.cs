using AwesomeAssertions;
using mvdmio.Basic.Extensions;
using mvdmio.UnitTest.Common.xUnit;
using Xunit;

namespace mvdmio.Basic.Tests.Unit.Extensions;

public class UriExtensionsTests : XUnitTestBase
{
   public class RootDomainTests : UriExtensionsTests
   {
      [Theory]
      [InlineData("https://example.com", "example.com")]
      [InlineData("https://sub.example.com", "example.com")]
      [InlineData("https://deep.sub.example.com", "example.com")]
      [InlineData("https://very.deep.sub.example.com", "example.com")]
      [InlineData("https://example.com/path/to/resource", "example.com")]
      [InlineData("https://sub.example.com/path?query=value", "example.com")]
      [InlineData("https://example.co.uk", "example.co.uk")]
      [InlineData("https://sub.example.co.uk", "example.co.uk")]
      [InlineData("http://localhost", "localhost")]
      [InlineData("https://192.168.1.1", "192.168.1.1")]
      public void ReturnsRootDomain(string uri, string expectedRootDomain)
      {
         var uriObj = new Uri(uri);
         uriObj.RootDomain.Should().Be(expectedRootDomain);
      }
   }

   public class RootDomainEqualsTests : UriExtensionsTests
   {
      [Theory]
      [InlineData("https://example.com", "https://example.com", true)]
      [InlineData("https://sub.example.com", "https://example.com", true)]
      [InlineData("https://example.com", "https://sub.example.com", true)]
      [InlineData("https://deep.sub.example.com", "https://other.sub.example.com", true)]
      [InlineData("https://example.com", "https://other.com", false)]
      [InlineData("https://sub.example.com", "https://sub.other.com", false)]
      [InlineData("https://example.com/path", "https://example.com/different/path", true)]
      public void ComparesRootDomains(string uri1, string uri2, bool expectedEquals)
      {
         var uriObj1 = new Uri(uri1);
         var uriObj2 = new Uri(uri2);
         uriObj1.RootDomainEquals(uriObj2).Should().Be(expectedEquals);
      }

      [Theory]
      [InlineData("https://EXAMPLE.COM", "https://example.com", true)]
      [InlineData("https://Example.Com", "https://example.com", true)]
      [InlineData("https://SUB.EXAMPLE.COM", "https://sub.example.com", true)]
      public void IsCaseInsensitive(string uri1, string uri2, bool expectedEquals)
      {
         var uriObj1 = new Uri(uri1);
         var uriObj2 = new Uri(uri2);
         uriObj1.RootDomainEquals(uriObj2).Should().Be(expectedEquals);
      }
   }

   public class AbsoluteUriWithoutQueryAndFragmentTests : UriExtensionsTests
   {
      [Theory]
      [InlineData("https://example.com", "https://example.com/")]
      [InlineData("https://example.com/", "https://example.com/")]
      [InlineData("https://example.com/path", "https://example.com/path")]
      [InlineData("https://example.com/path/to/resource", "https://example.com/path/to/resource")]
      [InlineData("https://example.com?query=value", "https://example.com/")]
      [InlineData("https://example.com/path?query=value", "https://example.com/path")]
      [InlineData("https://example.com/path?query=value&other=param", "https://example.com/path")]
      [InlineData("https://example.com#fragment", "https://example.com/")]
      [InlineData("https://example.com/path#fragment", "https://example.com/path")]
      [InlineData("https://example.com/path?query=value#fragment", "https://example.com/path")]
      [InlineData("https://example.com:8080/path?query=value#fragment", "https://example.com:8080/path")]
      [InlineData("https://user:pass@example.com/path?query=value", "https://user:pass@example.com/path")]
      public void RemovesQueryAndFragment(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.AbsoluteUriBase.Should().Be(expectedUri);
      }
   }

   public class NormalizedAbsoluteUriTests : UriExtensionsTests
   {
      [Theory]
      [InlineData("https://example.com", "https://example.com/")]
      [InlineData("https://example.com/", "https://example.com/")]
      [InlineData("https://example.com/path", "https://example.com/path")]
      [InlineData("https://example.com/path/", "https://example.com/path")]
      [InlineData("https://example.com/path/to/resource/", "https://example.com/path/to/resource")]
      public void RemovesTrailingSlashExceptForRoot(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.NormalizedAbsoluteUri.Should().Be(expectedUri);
      }
      
      [Theory]
      [InlineData("https://example.com?query=value", "https://example.com/?query=value")]
      [InlineData("https://example.com/path?query=value", "https://example.com/path?query=value")]
      [InlineData("https://example.com/path?query=value&other=param", "https://example.com/path?query=value&other=param")]
      [InlineData("https://example.com/path?id=1", "https://example.com/path?id=1")]
      [InlineData("https://example.com/path?id=2", "https://example.com/path?id=2")]
      public void KeepsQueryParameters(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.NormalizedAbsoluteUri.Should().Be(expectedUri);
      }
      
      [Theory]
      [InlineData("https://example.com#fragment", "https://example.com/")]
      [InlineData("https://example.com/path#fragment", "https://example.com/path")]
      [InlineData("https://example.com/path?query=value#fragment", "https://example.com/path?query=value")]
      public void RemovesFragments(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.NormalizedAbsoluteUri.Should().Be(expectedUri);
      }
      
      [Theory]
      [InlineData("HTTPS://EXAMPLE.COM/path", "https://example.com/path")]
      [InlineData("HTTP://EXAMPLE.COM/path", "http://example.com/path")]
      [InlineData("https://Example.Com/Path", "https://example.com/Path")]
      [InlineData("https://SUB.EXAMPLE.COM/path", "https://sub.example.com/path")]
      public void NormalizesSchemeAndHostToLowercase(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.NormalizedAbsoluteUri.Should().Be(expectedUri);
      }
      
      [Theory]
      [InlineData("https://example.com:443/path", "https://example.com/path")]
      [InlineData("http://example.com:80/path", "http://example.com/path")]
      [InlineData("https://example.com:8080/path", "https://example.com:8080/path")]
      [InlineData("http://example.com:8080/path", "http://example.com:8080/path")]
      public void RemovesDefaultPorts(string uri, string expectedUri)
      {
         var uriObj = new Uri(uri);
         uriObj.NormalizedAbsoluteUri.Should().Be(expectedUri);
      }
      
      [Theory]
      [InlineData("https://example.com/path", "https://example.com/path")]
      [InlineData("HTTPS://EXAMPLE.COM/path", "https://example.com/path")]
      public void SameUrlsNormalizeToSameValue(string uri1, string uri2)
      {
         var uriObj1 = new Uri(uri1);
         var uriObj2 = new Uri(uri2);
         uriObj1.NormalizedAbsoluteUri.Should().Be(uriObj2.NormalizedAbsoluteUri);
      }
      
      [Theory]
      [InlineData("https://example.com/path?id=1", "https://example.com/path?id=2")]
      [InlineData("https://example.com/path", "https://example.com/other")]
      [InlineData("https://example.com/path", "https://other.com/path")]
      public void DifferentUrlsNormalizeToDifferentValues(string uri1, string uri2)
      {
         var uriObj1 = new Uri(uri1);
         var uriObj2 = new Uri(uri2);
         uriObj1.NormalizedAbsoluteUri.Should().NotBe(uriObj2.NormalizedAbsoluteUri);
      }
   }
}
