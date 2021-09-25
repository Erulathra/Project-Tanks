using System;
using GameSettingsManagement;
using GameSettingsManagement.PlayerInfoManagement;
using PlayerManagement;
using TMPro;
using UnityEngine;

namespace Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        [Serializable]
        public struct DummyStatue
        {
            public GameObject gameObject;
            public TextMeshPro infoTextMesh;
        }
    
        [SerializeField] private PlayerInfoManager playerInfoManager;
        [SerializeField] private PlayerInputDeviceInfo playerInputDeviceInfo;
        [SerializeField] private RoundManager roundManager;
    
    
        [SerializeField] private DummyStatue[] dummies = new DummyStatue[4];

        private const string NoneIcon = "諸";
        private const string GamepadIcon = "調";
        private const string KeyboardIcon = "";

        private void Start()
        {
            foreach (var dummy in dummies)
            {
                dummy.gameObject.SetActive(false);
            }
        }

        void Update()
        {
            playerInfoManager.UpdatePlayersInfo();
        
            for (int i = 0; i < 4; i++)
            {
                dummies[i].infoTextMesh.text = PlayerControllerTypeToString(playerInputDeviceInfo.PlayersInput[i].playerControllerType);
                if (playerInputDeviceInfo.PlayersInput[i].playerControllerType == PlayerControllerType.None) continue;
                if (dummies[i].gameObject.activeSelf) continue;
                
                dummies[i].gameObject.SetActive(true);
                var playerComponent = dummies[i].gameObject.GetComponent<Player>();
                playerComponent.playerInfo = playerInfoManager.GetPlayerInfo(i);
                playerComponent.ApplyColor();
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

        public void TryStartTheGame()
        {
            if (playerInputDeviceInfo.GetActivePlayers() < 2) return;
        
            roundManager.StartNewGame();
        }
    
        public void ReturnToMenu()
        {
            SceneLoader.LoadMenuWithTransition();
        }
    
    }
}
