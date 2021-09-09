using PlayerManagement;
using PlayerManagement.PlayerGameObjectBuilder;
using UnityEngine;

public abstract class PlayerGameObjectBuilder : MonoBehaviour, IPlayerGameObjectBuilder
{
	protected Player Player;
	protected GameObject PlayerGameObject;
	
	public void Reset(GameObject playerPrefab, Player player)
	{
		PlayerGameObject = Instantiate(playerPrefab);
		this.Player = player;
	}

	public abstract void AddAimHandler();
	public abstract void AssingController();
	public GameObject GetResult()
	{
		return PlayerGameObject;
	}

	public void MoveToSpawnPoint(Vector3 spawnPointPosition)
	{
		PlayerGameObject.transform.position = spawnPointPosition;
	}
	
}