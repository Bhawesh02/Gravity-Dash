using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerView playerView = collision.gameObject.GetComponent<PlayerView>();
        if (playerView != null)
        {
            playerView.Controller.PlayerDead();
        }
    }
}
