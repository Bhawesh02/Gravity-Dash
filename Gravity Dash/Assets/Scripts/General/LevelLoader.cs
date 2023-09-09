using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    [SerializeField]
    private GameObject lockedUI;
    [SerializeField]
    private new Scenes name;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        if (name == Scenes.level2 && PlayerPrefs.GetInt("Last_Level", 1) < 2)
        {
            lockedUI.SetActive(true);
            return;
        }
        SceneManager.LoadScene(ScenesManage.GetSceneName(name));
    }
}
