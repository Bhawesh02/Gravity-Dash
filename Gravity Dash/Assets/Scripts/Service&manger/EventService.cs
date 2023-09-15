
using System;

public class EventService : SingeltonGeneric<EventService>
{
    public event Action PlayerDied;
    public event Action<PickupType> PickupCollected;
    public event Action ExtraLifeUsed;
    public event Action LevelCompleted;
    public void InvokePlayerDied()
    {
        PlayerDied?.Invoke();
    }
    public void InvokePickupCollected(PickupType type) {
        PickupCollected?.Invoke(type);
    }
    public void InvokeExtraLifeUsed()
    {
        ExtraLifeUsed?.Invoke();
    }
    public void InvokeLevelCompleted()
    {
        LevelCompleted?.Invoke();
    }
}
