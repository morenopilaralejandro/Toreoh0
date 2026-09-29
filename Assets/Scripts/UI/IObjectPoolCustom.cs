public interface IObjectPoolCustom<T>
{
    T Get();
    void Release(T element);
    void Clear();
}
