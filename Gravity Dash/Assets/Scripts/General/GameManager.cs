using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private PlayerView playerView;

    public List<GameObject> Platforms;
    public Dictionary<PickupType, List<GameObject>> Pickups;


    public Dictionary<GameObject, Vector3> PickupsLastPos = new();
    public BackgroundMove BackgroundMove;
    public GameObject GameEnd;
    [HideInInspector]
    public float Speed;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Speed = playerView.Speed;
        Pickups = new();
        foreach (PickupType type in Enum.GetValues(typeof(PickupType)))
        {
            Pickups[type] = new List<GameObject>();
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
        if (playerView != null)
            playerView.enabled = value;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToLobby()
    {
        SceneManager.LoadScene(ScenesManage.GetSceneName(Scenes.Lobby));
    }

    public void NextLevel()
    {
        string currSceneName = SceneManager.GetActiveScene().name;
        int nextSceneIndex = ((int)Enum.Parse(typeof(Scenes), currSceneName)) + 1;
        SceneManager.LoadScene(ScenesManage.GetSceneName((Scenes)nextSceneIndex));
    }
    
}
