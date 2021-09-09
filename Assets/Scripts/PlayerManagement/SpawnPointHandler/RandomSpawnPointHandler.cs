using System.Collections.Generic;
using UnityEngine;

namespace PlayerManagement.SpawnPointHandler
{
	public class RandomSpawnPointHandler : MonoBehaviour, ISpawnPointHandler
	{
		[SerializeField] private Transform spawnPointParent;
		[SerializeField] private float safeSphereRadius;
		private List<Transform> playersTransforms;
		
		private List<Transform> spawnPoints;
		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			spawnPoints = new List<Transform>();
			foreach (Transform child in spawnPointParent) spawnPoints.Add(child);
			

			if(spawnPoints.Count < 4) Debug.LogWarning("There are only " + spawnPoints.Count + " spawnPoints, when there can be " +
			                                                                 4 + " players!");
		}
		
		public Vector3 GetSpawnPoint()
		{
			GetAllPlayersTransform();
			for (;;)
			{
				var spawnPointIndex = Random.Range(0, spawnPoints.Count);
				if (IsNoPlayerInRadiusOf(spawnPoints[spawnPointIndex].position))
					return spawnPoints[spawnPointIndex].position;
			}
		}
		
		private void GetAllPlayersTransform()
		{
			playersTransforms = new List<Transform>();
			var playerObjects = GameObject.FindGameObjectsWithTag("Player");
			foreach (var player in playerObjects)
			{
				playersTransforms.Add(player.transform);
			}
		}
		
		private bool IsNoPlayerInRadiusOf(Vector3 spawnPoint)
		{
			foreach (var playerTransform in playersTransforms)
			{
				var distance = (playerTransform.position - spawnPoint).magnitude;
				if (distance < safeSphereRadius) return false;
			}

			return true;
		}
	}
}