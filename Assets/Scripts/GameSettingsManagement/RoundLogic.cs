using System.Collections.Generic;
using GameSettingsManagement.PlayerInfoManagement;
using TMPro;
using UnityEngine;

namespace GameSettingsManagement
{
	//todo Wiadomości jako obserwator
	public class RoundLogic : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI messageBoard;
		private List<GameObject> players;

		public void Awake()
		{
			players = new List<GameObject>();
			messageBoard.gameObject.SetActive(false);
		}

		public void AddPlayer(GameObject player)
		{
			players.Add(player);
		}

		private void Update()
		{
			List<GameObject> livingPlayers = GetListOfLivingPlayers();
			if (livingPlayers.Count == 1)
			{
				var winnerPlayerInfo = livingPlayers[0].GetComponent<Player>().playerInfo;
				messageBoard.gameObject.SetActive(true);
				messageBoard.color = winnerPlayerInfo.Color;
				messageBoard.text = "And the Winner is " + winnerPlayerInfo.Name;
			}
		}

		private List<GameObject> GetListOfLivingPlayers()
		{
			var temp = new List<GameObject>();
			foreach (var player in players)
				if(player.activeSelf) temp.Add(player);
			
			return temp;
		}

	}
}