namespace Utility
{
    public interface IPooledObject
    {
        void BackToPool();
        void SetPool(ObjectPool pool);
    }
}