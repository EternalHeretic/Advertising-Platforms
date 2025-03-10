using Advertising_Platforms.Models;
using System.Collections.Concurrent;

namespace Advertising_Platforms.Services
{
    public class AdService
    {
        private readonly ConcurrentDictionary<string, AdPlatform> _adPlatforms = new();

        public void LoadAdPlatformsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var name = parts[0];
                    var locations = parts[1].Split(',').ToList();
                    _adPlatforms[name] = new AdPlatform { Name = name, Locations = locations };
                }
            }
        }

        public List<string> GetAdPlatformsForLocation(string location)
        {
            return _adPlatforms.Values
                .Where(platform => platform.Locations.Any(loc => location.StartsWith(loc)))
                .Select(platform => platform.Name)
                .ToList();
        }
    }
}
