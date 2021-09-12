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

		private PlayerInputDeviceInfo playerInputDeviceInfo;
		private ISpawnPointHandler spawnPointHandler;
		
		private List<GameObject> playersGameObjects;

		//TODO Dodawanie do kamery
		private void Start()
		{
			var playerSettings = GameObject.Find("PlayerSettings").GetComponent<PlayerInputDeviceInfo>();
			if (playerSettings == null) Destroy(gameObject);

			playerInputDeviceInfo = playerSettings.GetComponent<PlayerInputDeviceInfo>();
			spawnPointHandler = GetComponent<ISpawnPointHandler>();

			SpawnPlayersAndAssingDevices();
		}

		private void SpawnPlayersAndAssingDevices()
		{
			foreach (var player in playerInputDeviceInfo.Players) TryInstantiatePlayerGameObject(player);
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