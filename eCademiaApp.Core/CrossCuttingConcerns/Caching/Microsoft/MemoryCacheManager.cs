using eCademiaApp.Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.RegularExpressions;

namespace eCademiaApp.Core.CrossCuttingConcerns.Caching.Microsoft
{
    // To use memCache for storing our pages
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }

        /// <summary>This method adds a new cache object to browser.</summary>
        /// <param name="key">object you want to be cached</param>
        /// <param name="value">variable(s) you want to be cached</param>
        /// <param name="duration">cache duration</param>
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        /// <summary>This method returns if there are values matches with in cache.</summary>
        /// <param name="key">cached objects key you want to filter</param>
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        /// <summary>This method returns if there is a value matches with in cache.</summary>
        /// <param name="key">cached object key you want to filter</param>
        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        /// <summary>This method removes cached object with key.</summary>
        /// <param name="key">cached object key you want to remove</param>
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        /// <summary>This method removes cached object by pattern.</summary>
        /// <param name="key">cached object key you want to remove</param>
        public void RemoveByPattern(string pattern) // Courses.getById(id)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection",
                BindingFlags.NonPublic | BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            var cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues
                .Where(d => regex.IsMatch(d.Key.ToString()))
                .Select(d => d.Key)
                .ToList();

            foreach (var key in keysToRemove) _memoryCache.Remove(key);
        }
    }
}
