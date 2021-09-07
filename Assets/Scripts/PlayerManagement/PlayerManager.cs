using System;
using System.Collections.Generic;
using PlayerManagement;
using Tank.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

using Tank.Scripts.Input;

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
		if (playerSettings == null) Destroy(this.gameObject);
		
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
		GameObject playerGameObject;
		if (player.playerControllerType == PlayerControllerType.Gamepad) playerGameObject = InstantiatePlayerGameObjectAndAddGamepadAimHandler(player);
		else if (player.playerControllerType == PlayerControllerType.MouseAndKeyboard)playerGameObject = InstantiatePlayerGameObjectAndAddMouseAimHandler(player);
		else if (player.playerControllerType == PlayerControllerType.None) return;
		else throw new NotImplementedException();

		MoveToSpawnPoint(playerGameObject);
		AssingDevice(player, playerGameObject);
	}
	
	private GameObject InstantiatePlayerGameObjectAndAddGamepadAimHandler(Player player)
	{
		var playerGameObject = Instantiate(playerPrefab);
		return playerGameObject;
	}
	
	private GameObject InstantiatePlayerGameObjectAndAddMouseAimHandler(Player player)
	{
		var playerGameObject = Instantiate(playerPrefab);
		
		//TODO wyczyścić ten kod
		Destroy(playerGameObject.GetComponent<GamepadAimHandler>());
		var mouseAimHandler = playerGameObject.AddComponent<MouseAimHandler>();
		var inputHandler = playerGameObject.GetComponent<InputHandler>();
		inputHandler.AimHandler = mouseAimHandler;
		

		return playerGameObject;
	}

	private void MoveToSpawnPoint(GameObject playerGameObject)
	{
		playerGameObject.transform.position = GetSpawnPoint();
	}

	private Vector3 GetSpawnPoint()
	{
		var spawnPoint = spawnPoints[spawnPointIndex];
		spawnPointIndex++;
		return spawnPoint.position;
	}
//Todo czyszcenie kodu
	private void AssingDevice(Player player, GameObject playerGameObject)
	{
		var playerInput = playerGameObject.GetComponent<PlayerInput>();
		if (player.playerControllerType == PlayerControllerType.Gamepad)
		{
			playerInput.SwitchCurrentControlScheme(player.InputDevice);
		}
		else
		{
			InputDevice[] inputDevices = new InputDevice[2];
			inputDevices[0] = player.InputDevice;
			inputDevices[1] = Mouse.current;
			playerInput.SwitchCurrentControlScheme(inputDevices);
		}
	}
}