
using UnityEngine;


public enum PickupType
{
    Heart,
    Checkpoint,
    Meat
}
public class PickupController : MonoBehaviour
{
    [SerializeField]
    private PickupType type;
    private void Start()
    {

        GameManager.Instance.Pickups[type].Add(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerView playerView = collision.gameObject.GetComponent<PlayerView>();

        if (playerView == null)
            return;
        EventService.Instance.InvokePickupCollected(type);
        GameManager.Instance.Pickups[type].Remove(gameObject);
        Destroy(gameObject);
    }
}
