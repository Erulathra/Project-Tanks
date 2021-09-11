using System;
using System.Collections.Generic;
using Cinemachine;
using PlayerManagement.PlayerGameObjectBuilder;
using PlayerManagement.SpawnPointHandler;
using UnityEngine;

namespace PlayerManagement
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab;
		[SerializeField] private CinemachineTargetGroup targetGroup;

		private PlayerInfo playerInfo;
		private ISpawnPointHandler spawnPointHandler;
		
		private List<GameObject> playersGameObjects;

		//TODO Dodawanie do kamery
		private void Start()
		{
			var playerSettings = GameObject.Find("PlayerSettings").GetComponent<PlayerInfo>();
			if (playerSettings == null) Destroy(gameObject);

			playerInfo = playerSettings.GetComponent<PlayerInfo>();
			spawnPointHandler = GetComponent<ISpawnPointHandler>();

			SpawnPlayersAndAssingDevices();
		}

		private void SpawnPlayersAndAssingDevices()
		{
			foreach (var player in playerInfo.Players) TryInstantiatePlayerGameObject(player);
		}

		private void TryInstantiatePlayerGameObject(Player player)
		{
			try
			{
				InstantiatePlayerGameObject(player);
			}
			catch (NoneControllerException)
			{ }
		}

		private void InstantiatePlayerGameObject(Player player)
		{
			IPlayerGameObjectBuilder playerGameObjectBuilder = CreatePlayerGameObjectBuilder(player);
			playerGameObjectBuilder.Reset(playerPrefab, player);
			playerGameObjectBuilder.AddAimHandler();
			playerGameObjectBuilder.AssingController();
			playerGameObjectBuilder.MoveToSpawnPoint(spawnPointHandler.GetSpawnPoint());
			playerGameObjectBuilder.AddToTargetGroup(targetGroup);
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
	}

	internal class NoneControllerException : Exception
	{ }
}