using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelOverTitle;
    [SerializeField]
    private GameObject continueButton;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController == null)
            return;
        string lastSceneName = ScenesManage.GetSceneName(Enum.GetValues(typeof(Scenes)).Cast<Scenes>().Last());
        string curSceneName = SceneManager.GetActiveScene().name;
        if (lastSceneName == curSceneName)
        {
            if (levelOverTitle != null)
                levelOverTitle.text = "Game Completed";
            Destroy(continueButton);
        }
        GameManager.Instance.SetMoveLeft(false);
        playerController.LevelCompleteUI.SetActive(true);
        playerController.enabled = false;
        
        if(curSceneName == ScenesManage.GetSceneName(Scenes.Level1))
        {
            PlayerPrefs.SetInt("Last_Level",2);
        }
    }
}
