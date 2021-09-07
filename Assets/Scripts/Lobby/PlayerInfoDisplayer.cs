using UnityEngine;
using PlayerManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerInfoDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private TextMeshProUGUI[] playerInfoTextMeshes;

    private const string NoneIcon = "諸";
    private const string GamepadIcon = "調";
    private const string KeyboardIcon = "";
    
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            playerInfoTextMeshes[i].text = "Player " + (i + 1).ToString() + "\n" + PlayerControllerTypeToString(playerInfo.Players[i].playerControllerType);
        }
    }
    private string PlayerControllerTypeToString(PlayerControllerType p)
    {
        if (p == PlayerControllerType.Gamepad)
            return GamepadIcon;
        if (p == PlayerControllerType.MouseAndKeyboard)
            return KeyboardIcon;
        
        return NoneIcon;
    }
}
