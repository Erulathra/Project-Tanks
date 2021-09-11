using Cinemachine;
using UnityEngine;

namespace PlayerManagement.PlayerGameObjectBuilder
{
	public interface IPlayerGameObjectBuilder
	{
		public void Reset(GameObject playerPrefab, Player player);
		public void AddAimHandler();
		public void AssingController();
		public void MoveToSpawnPoint(Vector3 spawnPointPosition);
		public void AddToTargetGroup(CinemachineTargetGroup targetGroup);
		public GameObject GetResult();
	}
}