using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;


    [SerializeField]
    private SpriteRenderer backgorundSprite1;


    private Vector3 inititalPos;

    private void Awake()
    {
        inititalPos = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 bgpos = transform.position;
        if (bgpos.x <= inititalPos.x - backgorundSprite1.size.x/2 )
            bgpos = inititalPos;
        else
            bgpos.x -= GameManager.Instance.Speed * Time.deltaTime;
        transform.position = bgpos;


    }
}
