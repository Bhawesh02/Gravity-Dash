using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private PlayerController playerController;


    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    public List<GameObject> Platforms;
    public Dictionary<PickupType, List<GameObject>> Pickups;
    public Dictionary<GameObject, Vector3> PickupsLastPos = new();
    public BackgroundMove BackgroundMove;

    [HideInInspector]
    public float Speed;

    private Vector3 lastPlayerPos;

    private List<Vector3> lastPlatformPos = new();


    private Vector3 lastBackgroundPos;

    private float lastGravityScale;

    private bool lastFlipY;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Speed = playerController.Speed;
        playerRigidBody = playerController.GetComponent<Rigidbody2D>();
        playerSpriteRenderer = playerController.GetComponent<SpriteRenderer>();
        Pickups = new();
        foreach (PickupType type in Enum.GetValues(typeof(PickupType)))
        {
            Pickups[type] = new List<GameObject>();
        }
        for (int i = 0; i < Platforms.Count; i++)
        {
            lastPlatformPos.Add(Platforms[i].transform.position);
        }
    }


    public void SetMoveLeft(bool value)
    {
        Platforms.ForEach(platform => platform.GetComponent<MoveLeft>().enabled = value);
        BackgroundMove.enabled = value;
        foreach (PickupType type in Enum.GetValues(typeof(PickupType)))
        {
            Pickups[type].ForEach(pickup => pickup.GetComponent<MoveLeft>().enabled = value);
        }
        if (playerController != null)
            playerController.enabled = value;
    }


    public void LevelOver()
    {
        SetMoveLeft(false);
        playerController.enabled = false;
    }
}
