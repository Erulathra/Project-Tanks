using Cinemachine;
using PlayerManagement;
using UnityEngine;

namespace GameSettingsManagement.PlayerGameObjectBuilder
{
	public abstract class PlayerGameObjectBuilder : MonoBehaviour, IPlayerGameObjectBuilder
	{
		protected PlayerInput PlayerInput;
		protected GameObject PlayerGameObject;
	
		public void Reset(GameObject playerPrefab, PlayerInput playerInput)
		{
			PlayerGameObject = Instantiate(playerPrefab);
			PlayerInput = playerInput;
		}

		public abstract void AddAimHandler();
		public abstract void AssingController();
		public GameObject GetResult()
		{
			return PlayerGameObject;
		}

		public void ChangeColor(Color color)
		{
			throw new System.NotImplementedException();
		}

		public void MoveToSpawnPoint(Vector3 spawnPointPosition)
		{
			PlayerGameObject.transform.position = spawnPointPosition;
		}

		public void AddToTargetGroup(CinemachineTargetGroup targetGroup)
		{
			targetGroup.AddMember(PlayerGameObject.transform, 1f, 1f);
		}

	}
}