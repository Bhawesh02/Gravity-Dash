using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody;

    private SpriteRenderer playerSpriteRenderer;

    private Animator playerAnimator;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.gravityScale *= -1;
            playerSpriteRenderer.flipY = !playerSpriteRenderer.flipY;
        }
        if (playerRigidbody.velocity.y != 0)
            playerAnimator.SetBool("OnGround",false);
        else
            playerAnimator.SetBool("OnGround", true);
    }
    
}
