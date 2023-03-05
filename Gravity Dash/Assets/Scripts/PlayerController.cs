using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    private Rigidbody2D playerRigidbody;

    private SpriteRenderer playerSpriteRenderer;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody.gravityScale *= -1;
            playerSpriteRenderer.flipY = !playerSpriteRenderer.flipY;
        }
    }

}
