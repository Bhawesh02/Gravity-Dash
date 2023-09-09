
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
        switch (type)
        {
            case PickupType.Heart:
                playerView.ExtraLife = true;
                playerView.ExtraLifeIcon.SetActive(true);
                break;
            case PickupType.Checkpoint:
                playerView.Controller.RecordLastPos();

                break;
            case PickupType.Meat:
                playerView.Controller.IncreaseMass();
                break;
            default:
                Debug.LogError("Pickup type not specified");
                break;
        }
        GameManager.Instance.Pickups[type].Remove(gameObject);
        Destroy(gameObject);
    }
}
