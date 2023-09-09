using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public int increaceMassDuration = 5;
    public int massChange = 5;
    public float Speed;
    public bool OnGround;
    public bool ExtraLife = false;
    public GameObject ExtraLifeIcon;
    public GameObject playerDeadUI;
    public GameObject LevelCompleteUI;
    public Rigidbody2D PlayerRigidbody { get; private set; }

    public SpriteRenderer PlayerSpriteRenderer { get; private set; }

    public Animator PlayerAnimator { get; private set; }


    public Vector3 lastPlayerPos;

    public List<Vector3> lastPlatformPos = new();


    public Vector3 lastBackgroundPos;
    public Vector3 lastGameEndPos;

    public float lastGravityScale;

    public bool lastFlipY;

    public Dictionary<GameObject, Vector3> PickupsLastPos = new();

    public PlayerController Controller { get; private set; }

    private void Awake()
    {
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();

    }
    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            lastPlatformPos.Add(GameManager.Instance.Platforms[i].transform.position);
        }
        Controller = new(this);
    }

    private void Update()
    {
        Controller.GravitySwitch();
        Controller.OnGroundCheck();
    }

    
}
