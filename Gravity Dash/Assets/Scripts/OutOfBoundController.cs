using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.PlayerDead();
        }
    }
}
