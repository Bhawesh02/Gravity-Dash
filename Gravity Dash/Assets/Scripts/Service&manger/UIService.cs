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
    private GameObject playerDeadUI;
    [SerializeField]
    private GameObject extraLifeIcon;
    [SerializeField]
    private GameObject levelCompleteUI;


    private void Start()
    {
        restartButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.Restart));
        lobbyButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.GoToLobby));
        continueButton.onClick.AddListener(GameManager.Instance.NextLevel);
        EventService.Instance.PlayerDied += () =>
        {
            playerDeadUI.SetActive(true);
        };
        EventService.Instance.PickupCollected += (type) =>
        {
            if (type == PickupType.Heart)
                extraLifeIcon.SetActive(true);
        };
        EventService.Instance.ExtraLifeUsed += () =>
        {
            extraLifeIcon.SetActive(false);
        };
        EventService.Instance.LevelCompleted += () =>
        {
            levelCompleteUI.SetActive(true);
        };
    }
    private void OnDestroy()
    {
        EventService.Instance.PlayerDied -= () =>
        {
            playerDeadUI.SetActive(true);
        };
        EventService.Instance.PickupCollected -= (type) =>
        {
            if (type == PickupType.Heart)
                extraLifeIcon.SetActive(true);
        };
        EventService.Instance.ExtraLifeUsed -= () =>
        {
            extraLifeIcon.SetActive(false);
        };
        EventService.Instance.LevelCompleted -= () =>
        {
            levelCompleteUI.SetActive(true);
        };
    }
}
