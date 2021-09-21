using System;
using System.Collections;
using System.Collections.Generic;
using GameSettingsManagement.PlayerInfoManagement;
using UnityEngine;

namespace GameSettingsManagement
{
	public class RoundLogic : MonoBehaviour
	{
		public event Action<string, string> OnRoundEndEvent;

		
		[SerializeField] private float scoreBoardTime = 2f;

		private List<GameObject> players;
		private RoundManager roundManager;

		public void Awake()
		{
			players = new List<GameObject>();
		}

		public void Start()
		{
			var playerManager = GetComponent<PlayerManager>();
			roundManager = playerManager.playerSettings.GetComponent<RoundManager>();
			StartCoroutine(EndRoundCoroutine());
		}
		
		public void AddPlayer(GameObject player)
		{
			players.Add(player);
		}

		private IEnumerator EndRoundCoroutine()
		{
			while (true)
			{
				var livingPlayers = GetListOfLivingPlayers();
				if (livingPlayers.Count == 1)
				{
					var winnerPlayerInfo = livingPlayers[0].GetComponent<Player>().playerInfo;
					winnerPlayerInfo.score++;
					ShowMessage(winnerPlayerInfo);
					yield return new WaitForSeconds(scoreBoardTime);
					roundManager.LoadNextMapOrEndTheGame();
					yield break;
				}
				yield return null;
			}
		}

		private void ShowMessage(PlayerInfo winnerPlayerInfo)
		{
			var header = "Winner is <color=#" + ColorUtility.ToHtmlStringRGB(winnerPlayerInfo.Color) + ">" + winnerPlayerInfo.Name + "</color>";
			var message = " ";
			foreach (var player in players)
			{
				var playerInfo = player.GetComponent<Player>().playerInfo;
				message += "<color=#" + ColorUtility.ToHtmlStringRGB(playerInfo.Color) + ">" + playerInfo.score + "</color> ";
			}

			OnRoundEndEvent?.Invoke(header, message);
		}

		private List<GameObject> GetListOfLivingPlayers()
		{
			var temp = new List<GameObject>();
			foreach (var player in players)
				if (player.activeSelf)
					temp.Add(player);

			return temp;
		}
	}
}