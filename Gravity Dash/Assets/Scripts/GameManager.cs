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
<<<<<<< Updated upstream
    private Rigidbody2D playerRigidBody;
    private SpriteRenderer playerSpriteRenderer;
    public List<GameObject> Platforms;
    public Dictionary<PickupType, List<GameObject>> Pickups ;
    public Dictionary<GameObject, Vector3> PickupsLastPos = new();
=======


    public List<GameObject> Platforms;
    public Dictionary<PickupType, List<GameObject>> Pickups;
>>>>>>> Stashed changes
    public BackgroundMove BackgroundMove;
    
    [HideInInspector]
    public float Speed;

<<<<<<< Updated upstream
    private Vector3 lastPlayerPos;

    private List<Vector3> lastPlatformPos = new();

    private Vector3 lastBackgroundPos;

    private float lastGravityScale;

    private bool lastFlipY;

=======
>>>>>>> Stashed changes
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Speed = playerController.Speed;
        Pickups = new();
        foreach(PickupType type in Enum.GetValues(typeof(PickupType)))
        {
            Pickups[type] = new List<GameObject>();
        }
<<<<<<< Updated upstream
        for(int i=0;i<Platforms.Count;i++)
        {
            lastPlatformPos.Add(Platforms[i].transform.position);
        }
    }

    public void GameOver()
    {
        if (playerController.ExtraLife)
        {
            RespawnPlayer();
            return;
        }
        playerController.enabled = false;
        Platforms.ForEach(platform => platform.GetComponent<MoveLeft>().enabled = false) ;
        BackgroundMove.enabled = false;
        
        Debug.Log("GameOver");
=======
        
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
>>>>>>> Stashed changes
    }


<<<<<<< Updated upstream
        
        BackgroundMove.gameObject.transform.position = lastBackgroundPos;
        for (int i = 0; i < Platforms.Count; i++)
        {
             Platforms[i].transform.position = lastPlatformPos[i];
        }
        foreach (var type in Pickups)
        {
            type.Value.ForEach(gameObj => ReloadPickupPosition(gameObj));
        }
        playerRigidBody.gravityScale = lastGravityScale;
        playerSpriteRenderer.flipY = lastFlipY;
        playerRigidBody.velocity = new(0,0);
        playerController.gameObject.transform.position = lastPlayerPos;
        playerController.ExtraLife = false;
    }

    private void ReloadPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        gameObj.transform.position = PickupsLastPos[gameObj];
    }

    public void RecordLastPos()
    {
        lastPlayerPos = playerController.gameObject.transform.position;
        lastGravityScale = playerRigidBody.gravityScale;
        lastFlipY = playerSpriteRenderer.flipY;
        lastBackgroundPos = BackgroundMove.gameObject.transform.position;
        for (int i = 0; i < Platforms.Count; i++)
        {
            lastPlatformPos[i] = Platforms[i].transform.position;
        }
        foreach(var type in Pickups)
        {
            type.Value.ForEach(gameObj =>RecordPickupPosition(gameObj));
        }
    }

    private void RecordPickupPosition(GameObject gameObj)
    {
        if (gameObj == null)
            return;
        if (PickupsLastPos.ContainsKey(gameObj))
            PickupsLastPos[gameObj] = gameObj.transform.position;
        else
            PickupsLastPos.Add(gameObj, gameObj.transform.position);
=======
    

    


    public void LevelOver()
    {
        SetMoveLeft(false);
        playerController.enabled = false;
>>>>>>> Stashed changes
    }
}
