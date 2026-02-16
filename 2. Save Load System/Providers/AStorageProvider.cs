public abstract class AStorageProvider
{
    public abstract void Write(string key, string content);
    public abstract string Read(string key);
    public abstract bool Exists(string key);
    public abstract void Delete(string key);
}
