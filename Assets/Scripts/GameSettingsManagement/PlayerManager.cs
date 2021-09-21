using System;
using System.Collections.Generic;
using Cinemachine;
using GameSettingsManagement.PlayerGameObjectBuilder;
using GameSettingsManagement.PlayerInfoManagement;
using PlayerManagement;
using PlayerManagement.SpawnPointHandler;
using UnityEngine;

namespace GameSettingsManagement
{
	public class PlayerManager : MonoBehaviour
	{
		[SerializeField] private GameObject playerPrefab;
		[SerializeField] private CinemachineTargetGroup targetGroup;

		private PlayerInputDeviceInfo playerInputDeviceInfo;
		private ISpawnPointHandler spawnPointHandler;
		
		private List<GameObject> playersGameObjects;
		[HideInInspector] public GameObject playerSettings;
		private PlayerInfoManager playerInfoManager;

		private void Awake()
		{
			playerSettings = GameObject.Find("GameSettings");
			if (playerSettings == null)
			{
				Debug.LogError("No settings game object (You need to start a game from Lobby)");
				Destroy(gameObject);
			}
		}

		private void Start()
		{
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
			
			PreparePlayerToGame(playerInput, playerGameObject);
			AddPlayerObjectsToRoundLogic(playerGameObject);
		}

		private void PreparePlayerToGame(PlayerInput playerInput, GameObject playerGameObject)
		{
			var playerStats = playerGameObject.GetComponent<Player>();
			playerStats.playerInfo = playerInfoManager.GetPlayerInfo(playerInput.index);
			playerStats.ApplyColor();
		}

		private void AddPlayerObjectsToRoundLogic(GameObject playerGameObject)
		{
			var roundLogic = GetComponent<RoundLogic>();
			roundLogic.AddPlayer(playerGameObject);
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