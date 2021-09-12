using System;
using System.Collections.Generic;
using Cinemachine;
using PlayerManagement.PlayerGameObjectBuilder;
using PlayerManagement.PlayerInfoManagement;
using PlayerManagement.SpawnPointHandler;
using UnityEngine;

namespace PlayerManagement
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab;
		[SerializeField] private CinemachineTargetGroup targetGroup;

		private PlayerInputDeviceInfo playerInputDeviceInfo;
		private ISpawnPointHandler spawnPointHandler;
		
		private List<GameObject> playersGameObjects;
		private GameObject playerSettings;
		private PlayerInfoManager playerInfoManager;
		

		private void Start()
		{
			playerSettings = GameObject.Find("PlayerSettings");
			if (playerSettings == null) Destroy(gameObject);

			playerInputDeviceInfo = playerSettings.GetComponent<PlayerInputDeviceInfo>();
			spawnPointHandler = GetComponent<ISpawnPointHandler>();

			playerInfoManager = playerSettings.GetComponent<PlayerInfoManager>();
			
			SpawnPlayersAndAssingDevices();
		}

		private void SpawnPlayersAndAssingDevices()
		{
			foreach (var player in playerInputDeviceInfo.PlayersInput) TryInstantiatePlayerGameObject(player);
		}

		private void TryInstantiatePlayerGameObject(PlayerInput playerInput)
		{
			try
			{
				InstantiatePlayerGameObject(playerInput);
			}
			catch (NoneControllerException)
			{ }
		}

		private void InstantiatePlayerGameObject(PlayerInput playerInput)
		{
			IPlayerGameObjectBuilder playerGameObjectBuilder = CreatePlayerGameObjectBuilder(playerInput);
			playerGameObjectBuilder.Reset(playerPrefab, playerInput);
			playerGameObjectBuilder.AddAimHandler();
			playerGameObjectBuilder.AssingController();
			playerGameObjectBuilder.MoveToSpawnPoint(spawnPointHandler.GetSpawnPoint());
			playerGameObjectBuilder.AddToTargetGroup(targetGroup);
			
			var playerGameObject = playerGameObjectBuilder.GetResult();
			playerInfoManager.AssociateGameObjectWithPlayerInfo(playerGameObject, playerInput.index);
		}

		private IPlayerGameObjectBuilder CreatePlayerGameObjectBuilder(PlayerInput playerInput)
		{
			IPlayerGameObjectBuilder playerGameObjectBuilder;
			if (playerInput.playerControllerType == PlayerControllerType.Gamepad)
				playerGameObjectBuilder = gameObject.AddComponent<PlayerGameObjectBuilderWithGamepad>();
			else if (playerInput.playerControllerType == PlayerControllerType.MouseAndKeyboard)
				playerGameObjectBuilder = gameObject.AddComponent<PlayerGameObjectBuilderWithKeyboard>();
			else if (playerInput.playerControllerType == PlayerControllerType.None)
				throw new NoneControllerException();
			else
				throw new NotImplementedException();
			return playerGameObjectBuilder;
		}
	}

	internal class NoneControllerException : Exception
	{ }
}