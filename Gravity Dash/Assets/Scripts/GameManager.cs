using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private List<GameObject> platforms;
    [SerializeField]
    private BackgroundMove backgroundMove;
    
    [HideInInspector]
    public float speed;

    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        speed = playerController.Speed;
    }

    public void GameOver()
    {
        playerController.enabled = false;
        platforms.ForEach(platform => platform.GetComponent<MoveLeft>().enabled = false) ;
        backgroundMove.enabled = false;
        Debug.Log("GameOver");
    }
}
