using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
<<<<<<< Updated upstream
            GameManager.Instance.GameOver();
=======
            playerController.PlayerDead();
>>>>>>> Stashed changes
        }
    }
}
