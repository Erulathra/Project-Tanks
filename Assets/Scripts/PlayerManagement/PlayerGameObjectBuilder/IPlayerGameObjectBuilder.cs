using UnityEngine;

namespace PlayerManagement.PlayerGameObjectBuilder
{
	public interface IPlayerGameObjectBuilder
	{
		public void Reset(GameObject playerPrefab, Player player);
		public void AddAimHandler();
		public void AssingController();

		public void MoveToSpawnPoint(Vector3 spawnPointPosition);
		public GameObject GetResult();
	}
}