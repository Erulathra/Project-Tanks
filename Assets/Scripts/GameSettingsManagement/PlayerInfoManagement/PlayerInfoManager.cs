using System.Collections.Generic;
using PlayerManagement;
using UnityEngine;

namespace GameSettingsManagement.PlayerInfoManagement
{
    public class PlayerInfoManager : MonoBehaviour
    {
        private List<PlayerInfo> players;

        private void Awake()
        {
            players = new List<PlayerInfo>();
        }

        public void UpdatePlayersInfo()
        {
            var playersInput = GetComponent<PlayerInputDeviceInfo>();
            IPlayerInfoGetter infoGetter = new ConstantPlayerInfoGetter();
            
            for (int i = 0; i < 4; i++)
            {
                var playerInput = playersInput.PlayersInput[i];
                if(playerInput.playerControllerType == PlayerControllerType.None) continue;
                
                players.Add(infoGetter.GetPlayerInfo(i));
            }
        }
        public void AssociateGameObjectWithPlayerInfo(GameObject gameObject, int playerIndex)
        {
            players[playerIndex].associatedGameObject = gameObject;
        }

        public PlayerInfo GetPlayerInfo(int playerIndex)
        {
            var temp = new PlayerInfo(players[playerIndex]);
            return temp;
        }

        public void SetHearts(int hearts, int playerIndex)
        {
            players[playerIndex].hearts = hearts;
        }

        public void ApplySettings()
        {
            foreach (var player in players)
            {
                ApplyColor(player);
            }
        }

        private void ApplyColor(PlayerInfo playerInfo)
        {
            var playerGameObject = playerInfo.associatedGameObject;
            var renderers = playerGameObject.GetComponentsInChildren<MeshRenderer>();
            foreach (var renderer in renderers)
            {
                renderer.material.color = playerInfo.Color;
            }
        }
    }
}
