using StackExchange.Redis;

namespace RedisApiCache.CacheConnection
{
    public class RedisConnection
    {
        public void Connection()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.99.100:6379");
            IDatabase db = redis.GetDatabase();

            string inputValue = "Test 1";
            db.StringSet("mykey", inputValue);
        }

    }
}
