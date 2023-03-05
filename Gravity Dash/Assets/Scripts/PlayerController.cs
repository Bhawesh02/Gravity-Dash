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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            playerAnimator.SetBool("OnGround", true);

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
            playerAnimator.SetBool("OnGround", false);
    }
}
