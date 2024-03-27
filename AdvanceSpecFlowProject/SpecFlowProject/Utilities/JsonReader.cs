using Newtonsoft.Json;

namespace SpecFlowProject.Utilities
{
    public class JsonReader
    {
        public static List<T> GetData<T>(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            List<T> objectList = JsonConvert.DeserializeObject<List<T>>(json);
            return objectList;
        }
    }
}