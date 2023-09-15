
using UnityEngine;

public class MonoSigeltonGeneric<T> : MonoBehaviour where T : MonoSigeltonGeneric<T>
{
    public static T Instance { get; private set; }
    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = (T)this;
        else
            Destroy(gameObject);
    }
}
