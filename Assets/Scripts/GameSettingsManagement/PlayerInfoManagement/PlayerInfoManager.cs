using System;
using System.Collections.Generic;
using System.Linq;
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
            return players[playerIndex];
        }

        public List<PlayerInfo> GetScoreBoard()
        {
            List<PlayerInfo> tempPlayerList = new List<PlayerInfo>(players);
            List<PlayerInfo> scoreBoardPlayerList = new List<PlayerInfo>();

            var playerCount = tempPlayerList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                var player = FindPlayerWithHighestScore(tempPlayerList);

                scoreBoardPlayerList.Add(player);
                tempPlayerList.Remove(player);
            }

            return scoreBoardPlayerList;
        }

        public PlayerInfo FindPlayerWithHighestScore()
        {
            return FindPlayerWithHighestScore(players);
        }
        public PlayerInfo FindPlayerWithHighestScore(List<PlayerInfo> playerList)
        {
            var foundPlayer = playerList.First();
            foreach (var player in playerList)
            {
                if (foundPlayer.score < player.score)
                    foundPlayer = player;
            }

            return foundPlayer;
        }
    }
}
