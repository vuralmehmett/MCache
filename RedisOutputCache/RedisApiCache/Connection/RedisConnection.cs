using System.IO;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisApiCache.Connection
{
    public class RedisConnection
    {
        private readonly ConfigFile _configFile;
        public RedisConnection(string fileName = "redisconfig")
        {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.BaseDirectory;
            var filePath = Path.Combine(basePath + "/" + fileName + ".json");
            var r = new StreamReader(new FileStream(filePath, FileMode.Open));
            var json = r.ReadToEnd();
            _configFile = JsonConvert.DeserializeObject<ConfigFile>(json);
            r.Close();
        }

        public void Connection()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(_configFile.Host + ":" + _configFile.Port);

            IDatabase db = redis.GetDatabase();

            string inputValue = "Test 1";
            db.StringSet("mykey", inputValue);
        }
    }
}
