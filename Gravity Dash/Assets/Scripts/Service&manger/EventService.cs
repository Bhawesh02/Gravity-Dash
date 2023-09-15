
using System;

public class EventService : SingeltonGeneric<EventService>
{
    public event Action PlayerDied;
    public void InvokePlayerDied()
    {
        PlayerDied?.Invoke();
    }
}
