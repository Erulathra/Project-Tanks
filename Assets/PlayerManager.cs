using System;
using System.Collections.Generic;
using PlayerManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private GameObject playerPrefab;
	[SerializeField] private Transform spawnPointParent;


	private PlayerInfo playerInfo;
	private List<GameObject> playersGameObjects;

	private int spawnPointIndex; //TODO zamienić na klasę
	private List<Transform> spawnPoints;

	//TODO Dodawanie do kamery
	private void Start()
	{
		playerInfo = GameObject.Find("PlayerSettings").GetComponent<PlayerInfo>();

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
		if (player.playerControllerType == PlayerControllerType.Gamepad) playerGameObject = InstantiatePlayerGameObjectAndAddGamepadHandler(player);
		else if (player.playerControllerType == PlayerControllerType.MouseAndKeyboard) throw new NotImplementedException();
		else if (player.playerControllerType == PlayerControllerType.None) return;
		else throw new NotImplementedException();

		MoveToSpawnPoint(playerGameObject);
		AssingDevice(player, playerGameObject);
	}
	
	private GameObject InstantiatePlayerGameObjectAndAddGamepadHandler(Player player)
	{
		var playerGameObject = Instantiate(playerPrefab);
		//gameObject.AddComponent<GamepadHandler>(); //TODO Tu też trzeba poprawić
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

	private void AssingDevice(Player player, GameObject playerGameObject)
	{
		var playerInput = playerGameObject.GetComponent<PlayerInput>();
		playerInput.SwitchCurrentControlScheme(player.InputDevice);
	}
}