namespace Benefits.Shared.Interfaces
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Invalidate(string key);

        void InvalidateInstanceOf(object data);
    }
}