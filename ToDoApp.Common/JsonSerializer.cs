using Newtonsoft.Json;

namespace ToDoApp.Common
{
    public class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string serializedObj)
        {
            if(serializedObj == null)
            {
                throw new ArgumentNullException(nameof(serializedObj));
            }

            return JsonConvert.DeserializeObject<T>(serializedObj);
        }

        public string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return JsonConvert.SerializeObject(obj);
        }
    }
}
