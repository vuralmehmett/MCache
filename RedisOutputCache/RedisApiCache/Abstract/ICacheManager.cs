namespace RedisApiCache.Abstract
{
    public interface ICacheManager
    {
        bool SetValue(string key, string value);
        string GetValue(string key);
    }
}
