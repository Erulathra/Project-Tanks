using Entities_Scripts.ExplosionScripts;
using PlayerManagement.SpawnPointHandler;
using Pool;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Scripts.Logic
{
	public class TankLogic : MonoBehaviour
	{
		private int healthPoints = 100;
		private ObjectPoolManager explosionPool;
		private ISpawnPointHandler spawnPointHandler;

		private UnityEvent OnDie;
		private ExplosionSpawner explosionSpawner;
		
		private void Start()
		{
			var playerManager = GameObject.Find("Player Manager");
			spawnPointHandler = playerManager.GetComponent<ISpawnPointHandler>();
		
			ExplosionData explosionData;
			explosionData.damage = 0;
			explosionData.force = 0;
			explosionData.radius = 3;
			
			explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<ObjectPoolManager>();

			explosionSpawner = new ExplosionSpawner();
			explosionSpawner.SetPool(explosionPool);
			explosionSpawner.SetData(explosionData);
		}


		public void HandleDamage(int damage)
		{
			if (healthPoints <= 0) return;
			healthPoints -= damage;
			DieIfHealthPointsAreNegative();
		}

		public void DieIfHealthPointsAreNegative()
		{
			if (healthPoints > 0) return;
			Explode();
			OnDie?.Invoke();
			Respawn();
		}

		private void Respawn()
		{
			transform.position = spawnPointHandler.GetSpawnPoint();
			healthPoints = 100;
		}

		private void Explode()
		{
			explosionSpawner.SetPosition(transform.position);
			explosionSpawner.Spawn();
			explosionSpawner.Explode();
		}

		
	}
}