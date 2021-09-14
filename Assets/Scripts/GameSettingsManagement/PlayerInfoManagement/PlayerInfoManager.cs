using System;
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
    
        public PlayerInfo GetPlayerInfo(int playerIndex)
        {
            var temp = new PlayerInfo(players[playerIndex]);
            return temp;
        }

    }
}
