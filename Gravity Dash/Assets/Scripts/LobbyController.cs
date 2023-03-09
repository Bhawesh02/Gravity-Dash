using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private GameObject startUi;
    [SerializeField]
    private GameObject selectLevelUi;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Button selectLevelButton;

    [SerializeField]
    private List<Button> backButton;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(Quit);
        backButton.ForEach(btn=>btn.onClick.AddListener(delegate { Back(btn); }));
        continueButton.onClick.AddListener(ContinueGame);
        selectLevelButton.onClick.AddListener(SelectLevel);
    }

    private void SelectLevel()
    {
        selectLevelUi.SetActive(true); ;
    }

    private void ContinueGame()
    {
        int lastLevel = PlayerPrefs.GetInt("Last_Level",1);
        SceneManager.LoadScene(lastLevel);
    }

    private void Back(Button btn)
    {
        btn.transform.parent.gameObject.SetActive(false);
    }

    private void StartGame()
    {
        startUi.SetActive(true);
    }

    private void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
