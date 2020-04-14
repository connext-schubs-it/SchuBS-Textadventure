using System.IO;

using Newtonsoft.Json;

namespace SchuBS_Textadventure.Data
{
    [JsonObject]
    public abstract class StorageObject<T> where T : class, new()
    {
        public static T Load()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(File.ReadAllText($"{typeof(T).Name}.json"));
            }
            catch
            {
                return new T();
            }
        }

        public void Save() => File.WriteAllText($"{ToString()}.json", JsonConvert.SerializeObject(this));

        public override string ToString() => GetType().Name;
    }
}
