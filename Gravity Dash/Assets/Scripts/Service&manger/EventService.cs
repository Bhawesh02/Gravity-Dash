
using System;

public class EventService : SingeltonGeneric<EventService>
{
    public event Action PlayerDied;
    public event Action<PickupType> PickupCollected;
    public void InvokePlayerDied()
    {
        PlayerDied?.Invoke();
    }
    public void InvokePickupCollected(PickupType type) {
        PickupCollected?.Invoke(type);
    }
}
