using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeadUIController : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button lobbyButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(GameManager.Instance.Restart);
        lobbyButton.onClick.AddListener(GameManager.Instance.GoToLobby);
    }
}
