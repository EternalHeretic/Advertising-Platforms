using Advertising_Platforms.Services;
using Xunit;
namespace Ad_Platforms_UnitTest
{
    public class AdServiceTests
    {
        private readonly AdService _adService = new();

        [Fact]
        public void LoadAdPlatformsFromFile_ShouldLoadDataCorrectly()
        {
            var filePath = "ad_platforms.txt";
            _adService.LoadAdPlatformsFromFile(filePath);
            var platforms = _adService.GetAdPlatformsForLocation("/ru/svrd/revda");
            Assert.Contains("–евдинский рабочий", platforms);
        }

        [Fact]
        public void GetAdPlatformsForLocation_ShouldReturnCorrectPlatforms()
        {
            var filePath = "ad_platforms.txt";
            _adService.LoadAdPlatformsFromFile(filePath);
            var platforms = _adService.GetAdPlatformsForLocation("/ru/msk");
            Assert.Contains("√азета уральских москвичей", platforms);
            Assert.Contains("яндекс.ƒирект", platforms);
        }
    }
}