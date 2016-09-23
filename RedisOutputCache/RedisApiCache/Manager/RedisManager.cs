using System.IO;
using Newtonsoft.Json;
using RedisApiCache.Abstract;
using RedisApiCache.Model;
using RedisApiCache.Utils;
using StackExchange.Redis;

namespace RedisApiCache.Manager
{
    public class RedisManager : ICacheManager
    {
        private readonly ConfigFile _configFile;
        public RedisManager(string fileName = "redisconfig")
        {
            _configFile = ConfigFileReader.ReadConfigFile(fileName);
        }

        public bool SetValue(string key, string value)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configFile.Host + ":" + _configFile.Port))
            {
                IDatabase db = redis.GetDatabase();

                return db.StringSet(key, value);

            }
        }

        public string GetValue(string key)
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configFile.Host + ":" + _configFile.Port))
            {
                IDatabase db = redis.GetDatabase();

                return db.StringGet(key);

            }
        }
    }
}