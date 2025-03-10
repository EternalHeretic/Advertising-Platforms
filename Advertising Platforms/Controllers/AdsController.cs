using Advertising_Platforms.Services;
using Microsoft.AspNetCore.Mvc;

namespace Advertising_Platforms.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly AdService _adService;

        public AdsController(AdService adService)
        {
            _adService = adService;
        }

        [HttpPost("load")]
        public IActionResult LoadAdPlatforms([FromBody] string filePath)
        {
            _adService.LoadAdPlatformsFromFile(filePath);
            return Ok();
        }

        [HttpGet("search")]
        public IActionResult SearchAdPlatforms(string location)
        {
            var platforms = _adService.GetAdPlatformsForLocation(location);
            return Ok(platforms);
        }
    }
}
