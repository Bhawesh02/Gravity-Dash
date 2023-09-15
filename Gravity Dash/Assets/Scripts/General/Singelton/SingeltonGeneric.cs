

public class SingeltonGeneric<T> where T : class, new()
{
    SingeltonGeneric() { }
    private static T instance = null;
    public static T Instance
    {
        get
        {
            instance ??= new();
            return instance;
        }
    }
}
