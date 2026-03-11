
namespace DalApi;
public interface ICrud<T>
{
    //ממשק שכולם משתמשים בו
    int Create(T item);
    T? Read(int id);
    List<T?> ReadAll(Func<T , bool>?filter=null);
    void Update(T item);
    void Delete(int id);
}
