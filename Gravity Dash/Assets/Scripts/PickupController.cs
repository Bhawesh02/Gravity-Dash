using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PickupType
{
    Heart
}
public class PickupController : MonoBehaviour
{
    [SerializeField]
    private PickupType type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;
        switch (type)
        {
            case PickupType.Heart:
                Debug.Log("Extra life");
                break;
            default:
                Debug.LogError("Pickup type not specified");
                break;
        }
        Destroy(gameObject);
    }
}
