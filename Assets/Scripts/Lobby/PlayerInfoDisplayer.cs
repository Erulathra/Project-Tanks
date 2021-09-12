using UnityEngine;
using PlayerManagement;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerInfoDisplayer : MonoBehaviour
{
    [FormerlySerializedAs("playerInfo")] [SerializeField] private PlayerInputDeviceInfo playerInputDeviceInfo;
    [SerializeField] private TextMeshProUGUI[] playerInfoTextMeshes;

    private const string NoneIcon = "諸";
    private const string GamepadIcon = "調";
    private const string KeyboardIcon = "";
    
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            playerInfoTextMeshes[i].text = "Player " + (i + 1).ToString() + "\n" + PlayerControllerTypeToString(playerInputDeviceInfo.PlayersInput[i].playerControllerType);
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
