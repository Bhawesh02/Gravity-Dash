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
    [SerializeField]
    private GameObject ExtraLifeIcon;

    private void Start()
    {
        restartButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.Restart));
        lobbyButtons.ForEach(btn => btn.onClick.AddListener(GameManager.Instance.GoToLobby));
        continueButton.onClick.AddListener(GameManager.Instance.NextLevel);
        EventService.Instance.PlayerDied += () =>
        {
            PlayerDeadUI.SetActive(true);
        };
        EventService.Instance.PickupCollected += (type) =>
        {
            if (type == PickupType.Heart)
                ExtraLifeIcon.SetActive(true);
        };
    }
    private void OnDestroy()
    {
        EventService.Instance.PlayerDied -= () =>
        {
            PlayerDeadUI.SetActive(true);
        };
        EventService.Instance.PickupCollected -= (type) =>
        {
            if (type == PickupType.Heart)
                ExtraLifeIcon.SetActive(true);
        };
    }
}
