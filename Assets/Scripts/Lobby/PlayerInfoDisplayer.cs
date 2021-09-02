using UnityEngine;
using PlayerManagement;
using UnityEngine.UI;

public class PlayerInfoDisplayer : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Text[] playerInfoTextMeshes;
    
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            playerInfoTextMeshes[i].text = "Player " + (i + 1).ToString() + " - " + PlayerControllerTypeToString(playerInfo.Players[i].playerControllerType);
        }
    }
    private string PlayerControllerTypeToString(PlayerControllerType p)
    {
        if (p == PlayerControllerType.Gamepad)
            return "Gamepad";
        if (p == PlayerControllerType.MouseAndKeyboard)
            return "Mouse and Keyboard";
        
        return "None";
    }
}
