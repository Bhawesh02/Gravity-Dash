using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoSigeltonGeneric<UIService>
{
    [SerializeField]
    private List<Button> restartButtons;
    [SerializeField]
    private List<Button> lobbyButtons;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private GameObject PlayerDeadUI;

    private void Start()
    {
        restartButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.Restart));
        lobbyButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.GoToLobby));
        continueButton.onClick.AddListener(GameManager.Instance.NextLevel);
        EventService.Instance.PlayerDied += () =>
        {
            PlayerDeadUI.SetActive(true);
        };
    }
}
