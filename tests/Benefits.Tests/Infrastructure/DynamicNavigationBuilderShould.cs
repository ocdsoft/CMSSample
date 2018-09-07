using Benefits.Shared.Infrastructure;
using Xunit;

namespace Benefits.Tests
{
    public class DynamicNavigationBuilderShould
    {
        [Theory]
        [InlineData("home", "home")]
        [InlineData("benefits/marketing", "benefits")]
        [InlineData("benefits/wellness", "benefits")]
        public void GetSlugPrefix(string fullSlug, string expected)
        {
            var sut = new DynamicNavigationBuilder();
            string actual = sut.GetSlugPrefix(fullSlug);

            Assert.Equal(expected, actual);
        }
    }
}