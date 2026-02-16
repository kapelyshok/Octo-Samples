using UnityEngine;
//I prefer Newtonsoft for Serialization 
using Newtonsoft.Json;

public class SaveService : ISaveService
{
    private readonly AStorageProvider _storage;

    public SaveService(AStorageProvider storageProvider)
    {
        _storage = storageProvider;
    }

    public void Save<T>(string key, T data)
    {
        try
        {
            string json = JsonConvert.SerializeObject(data);
            _storage.Write(key, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Save failed for key {key}: {e}");
        }
    }

    public T Load<T>(string key, T defaultValue = default)
    {
        try
        {
            if (!_storage.Exists(key))
            {
                return defaultValue;
            }

            string json = _storage.Read(key);

            if (string.IsNullOrEmpty(json))
            {
                return defaultValue;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Load failed for key {key}. Returning default. {e}");
            return defaultValue;
        }
    }

    public bool Exists(string key)
    {
        return _storage.Exists(key);
    }

    public void Delete(string key)
    {
        _storage.Delete(key);
    }
}