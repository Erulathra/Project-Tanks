using UnityEngine;

namespace PlayerManagement.SpawnPointHandler
{
	public interface ISpawnPointHandler
	{
		public Vector3 GetSpawnPoint();
	}
}