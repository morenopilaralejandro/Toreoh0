public interface IObjectPoolCustom<T>
{
    int CountInactive;

    T Get();
    void Release(T element);
    T Clear();
}
