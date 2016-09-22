using System.IO;
using Newtonsoft.Json;
using RedisApiCache.Abstract;
using RedisApiCache.Model;
using StackExchange.Redis;

namespace RedisApiCache.Manager
{
    public class RedisManager : ICacheManager
    {
        private readonly ConfigFile _configFile;
        public RedisManager(string fileName = "redisconfig")
        {
            //consider to move another class
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.BaseDirectory;
            var filePath = Path.Combine(basePath + "/" + fileName + ".json");
            var r = new StreamReader(new FileStream(filePath, FileMode.Open));
            var json = r.ReadToEnd();
            _configFile = JsonConvert.DeserializeObject<ConfigFile>(json);
            r.Close();

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
