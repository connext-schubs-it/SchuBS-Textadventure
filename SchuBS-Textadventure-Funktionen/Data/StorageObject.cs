using System.IO;

using Newtonsoft.Json;

namespace SchuBS_Textadventure.Data
{
    /// <summary>
    /// Ein Objekt, dass aus einer .json Datei erzeugt und in diese gespeichert werden kann.<br/>
    /// Pro abgeleiteter Klasse wird eine Datei mit dem Namen der Klasse erzeugt.
    /// </summary>
    /// <typeparam name="T">Die abgeleitete Klasse.</typeparam>
    [JsonObject]
    public abstract class StorageObject<T> where T : class, new()
    {
        /// <summary>
        /// Das Objekt, dass die Daten enthält.
        /// </summary>
        public static T Instance { get; } = Load();

        private static T Load()
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

        /// <summary>
        /// Speichert die Änderungen an diesem Objekt.
        /// </summary>
        public static void Save() => File.WriteAllText($"{typeof(T).Name}.json", JsonConvert.SerializeObject(Instance));
    }
}
