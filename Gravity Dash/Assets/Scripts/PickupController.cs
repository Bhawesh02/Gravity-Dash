using System.Collections;
using System.Collections.Generic;
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
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;
        switch (type)
        {
            case PickupType.Heart:
                playerController.ExtraLife = true;
                break;
            case PickupType.Checkpoint:
                playerController.RecordLastPos();

                break;
            case PickupType.Meat:
                playerController.IncreaseMass();
                break;
            default:
                Debug.LogError("Pickup type not specified");
                break;
        }
        Destroy(gameObject);
    }
}
