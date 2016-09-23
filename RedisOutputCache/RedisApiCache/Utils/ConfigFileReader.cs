using System.IO;
using Newtonsoft.Json;
using RedisApiCache.Model;

namespace RedisApiCache.Utils
{
    public static class ConfigFileReader
    {
        public static ConfigFile ReadConfigFile(string fileName)
        {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.BaseDirectory;
            var filePath = Path.Combine(basePath + "/" + fileName + ".json");
            var r = new StreamReader(new FileStream(filePath, FileMode.Open));
            var json = r.ReadToEnd();
            var file = JsonConvert.DeserializeObject<ConfigFile>(json);
            r.Close();

            return file;

        }
    }
}
