using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public bool OnGround;


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
        GravitySwitch();
        OnGroundCheck();
    }

    private void OnGroundCheck()
    {
        if (playerRigidbody.velocity.y != 0)
        {
            playerAnimator.SetBool("OnGround", false);
            OnGround = false;
        }
        else
        {
            playerAnimator.SetBool("OnGround", true);
            OnGround = true;
        }
    }

    private void GravitySwitch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.gravityScale *= -1;
            playerSpriteRenderer.flipY = !playerSpriteRenderer.flipY;
        }
    }
    
}
