using System.IO;
using UnityEngine;

public class FileStorageProvider : AStorageProvider
{
    private const string DEAFULT_FOLDER_NAME = "Saves";
    private readonly string _basePath;
    public FileStorageProvider()
    {
        _basePath = Path.Combine(Application.persistentDataPath, DEAFULT_FOLDER_NAME);

        if (!Directory.Exists(_basePath))
            Directory.CreateDirectory(_basePath);
    }
    
    private string GetFullPath(string key)
    {
        return Path.Combine(_basePath, key + ".json");
    }
    
    //TODO finish all methods accordingly using File.WriteAllText, File.ReadAllText etc. All method names are self explanatory
    public override void Write(string key, string content)
    {
    }

    public override string Read(string key)
    {
    }

    public override bool Exists(string key)
    {
        return File.Exists(GetFullPath(key));
    }

    public override void Delete(string key)
    {
    }
}