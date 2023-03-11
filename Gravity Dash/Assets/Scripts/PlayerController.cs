using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int increaceMassDuration = 5;
    private int massChange = 5;
    public float Speed;
    public bool OnGround;
    public bool ExtraLife = false;
    public GameObject ExtraLifeIcon;
    [SerializeField]
    private GameObject playerDeadUI;
    public GameObject LevelCompleteUI;
    private Rigidbody2D playerRigidbody;

    private SpriteRenderer playerSpriteRenderer;

    private Animator playerAnimator;


    private Vector3 lastPlayerPos;

    private List<Vector3> lastPlatformPos = new();


    private Vector3 lastBackgroundPos;
    private Vector3 lastGameEndPos;

    private float lastGravityScale;

    private bool lastFlipY;

    private Dictionary<GameObject, Vector3> PickupsLastPos = new();

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();

    }
    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            lastPlatformPos.Add(GameManager.Instance.Platforms[i].transform.position);
        }
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
    public void PlayerDead()
    {
        if (ExtraLife)
        {

            RespawnPlayer();
            ExtraLifeIcon.SetActive(false);
            return;
        }
        GameManager.Instance.SetMoveLeft(false);
        playerDeadUI.SetActive(true);
    }

    public void RecordLastPos()
    {
        if (!OnGround && lastPlayerPos != Vector3.zero)
            return;
        lastPlayerPos = gameObject.transform.position;
        lastGravityScale = playerRigidbody.gravityScale;
        lastFlipY = playerSpriteRenderer.flipY;

        lastBackgroundPos = GameManager.Instance.BackgroundMove.gameObject.transform.position;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            lastPlatformPos[i] = GameManager.Instance.Platforms[i].transform.position;
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => RecordPickupPosition(gameObj));
        }
        lastGameEndPos = GameManager.Instance.GameEnd.transform.position;
    }


    private void RecordPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        if (PickupsLastPos.ContainsKey(gameObj))
            PickupsLastPos[gameObj] = gameObj.transform.position;
        else
            PickupsLastPos.Add(gameObj, gameObj.transform.position);
    }

    private void RespawnPlayer()
    {


        GameManager.Instance.BackgroundMove.gameObject.transform.position = lastBackgroundPos;
        for (int i = 0; i < GameManager.Instance.Platforms.Count; i++)
        {
            GameManager.Instance.Platforms[i].transform.position = lastPlatformPos[i];
        }
        foreach (var type in GameManager.Instance.Pickups)
        {
            type.Value.ForEach(gameObj => ReloadPickupPosition(gameObj));
        }
        playerRigidbody.gravityScale = lastGravityScale;
        playerSpriteRenderer.flipY = lastFlipY;
        playerRigidbody.velocity = new(0, 0);
        gameObject.transform.position = lastPlayerPos;
        GameManager.Instance.GameEnd.transform.position = lastGameEndPos ;

        ExtraLife = false;

    }
    private void ReloadPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        gameObj.transform.position = PickupsLastPos[gameObj];
    }
    public void IncreaseMass()
    {
        playerRigidbody.mass *= massChange;
        StartCoroutine(ReduceMass());
    }
   
    IEnumerator ReduceMass()
    {
        yield return new WaitForSeconds(increaceMassDuration);
        playerRigidbody.mass /= massChange;
    }
}
