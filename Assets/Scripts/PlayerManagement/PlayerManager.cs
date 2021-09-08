using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerManagement
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab;
		[SerializeField] private Transform spawnPointParent;


		private PlayerInfo playerInfo;
		private List<GameObject> playersGameObjects;

		private int spawnPointIndex; //TODO zamienić na interfejs
		private List<Transform> spawnPoints;

		//TODO Dodawanie do kamery
		private void Start()
		{
			var playerSettings = GameObject.Find("PlayerSettings").GetComponent<PlayerInfo>();
			if (playerSettings == null) Destroy(gameObject);

			playerInfo = playerSettings.GetComponent<PlayerInfo>();

			spawnPoints = new List<Transform>();
			foreach (Transform child in spawnPointParent) spawnPoints.Add(child);

			SpawnPlayersAndAssingDevices();
		}

		private void SpawnPlayersAndAssingDevices()
		{
			foreach (var player in playerInfo.Players) InstantiatePlayerGameObject(player);
		}

		private void InstantiatePlayerGameObject(Player player)
		{
			try
			{
				IPlayerGameObjectBuilder playerGameObjectBuilder = CreatePlayerGameObjectBuilder(player);
				playerGameObjectBuilder.Reset(playerPrefab, player);
				playerGameObjectBuilder.AddAimHandler();
				playerGameObjectBuilder.AssingController();
				playerGameObjectBuilder.MoveToSpawnPoint(GetSpawnPoint());
			}
			catch(NoneControllerException)
			{
				return;
			}
		}

		private IPlayerGameObjectBuilder CreatePlayerGameObjectBuilder(Player player)
		{
			IPlayerGameObjectBuilder playerGameObjectBuilder;
			if (player.playerControllerType == PlayerControllerType.Gamepad)
				playerGameObjectBuilder = gameObject.AddComponent<PlayerGameObjectBuilderWithGamepad>();
			else if (player.playerControllerType == PlayerControllerType.MouseAndKeyboard)
				playerGameObjectBuilder = gameObject.AddComponent<PlayerGameObjectBuilderWithKeyboard>();
			else if (player.playerControllerType == PlayerControllerType.None)
				throw new NoneControllerException();
			else
				throw new NotImplementedException();
			return playerGameObjectBuilder;
		}

		private Vector3 GetSpawnPoint()
		{
			var spawnPoint = spawnPoints[spawnPointIndex];
			spawnPointIndex++;
			return spawnPoint.position;
		}
	}
	
	internal class NoneControllerException : Exception
	{
	
	}
}