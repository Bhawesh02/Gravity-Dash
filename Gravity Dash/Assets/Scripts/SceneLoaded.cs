using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneLoaded : MonoBehaviour
{
    private Button button;
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
            Debug.Log("Locked");
            return;
        }
        SceneManager.LoadScene(ScenesManage.GetSceneName(name));
    }
}
