using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
   
    public GameObject ExtraLifeIcon;
    public GameObject playerDeadUI;
    public GameObject LevelCompleteUI;
    public Rigidbody2D PlayerRigidbody { get; private set; }

    public SpriteRenderer PlayerSpriteRenderer { get; private set; }

    public Animator PlayerAnimator { get; private set; }


    public PlayerScriptableObject PlayerScriptableObject;

    public PlayerController Controller { get; private set; }

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        Controller = new(this, PlayerScriptableObject);
    }
    private void Start()
    {
        
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            Controller.Model.LastPlatformPos.Add(GameManager.Instance.Platforms[i].transform.position);
        }
        
    }

    private void Update()
    {
        Controller.GravitySwitch();
        Controller.OnGroundCheck();
    }

    
}
