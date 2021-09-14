using Entities_Scripts.ExplosionScripts;
using PlayerManagement.SpawnPointHandler;
using Pool;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Scripts.Logic
{

	public class TankLogic : MonoBehaviour
	{
		public UnityEvent OnDie;

		public int startHealthPoints = 100;
		public int startHearts = 3;
		
		public int Hearts { get; private set; }
		private int healthPoints;

		private ObjectPoolManager explosionPool;
		private ISpawnPointHandler spawnPointHandler;
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

			ResetHearts();
			ResetHealth();
		}

		public void ResetHearts()
		{
			Hearts = startHearts;
		}

		public void ResetHealth()
		{
			healthPoints = startHealthPoints;
		}

		public void HandleDamage(int damage)
		{
			if (healthPoints <= 0) return;
			healthPoints -= damage;
			DieIfHealthPointsAreNegative();
		}

		private void DieIfHealthPointsAreNegative()
		{
			if (healthPoints > 0) return;
			Explode();
			OnDie?.Invoke();
			LoseOrRespawn();
		}
		
		private void Explode()
		{
			explosionSpawner.SetPosition(transform.position);
			explosionSpawner.Spawn();
			explosionSpawner.Explode();
		}

		private void LoseOrRespawn()
		{
			if (Hearts <= 0) LoseRound();
			else Respawn();
		}
		
		private void LoseRound()
		{
			gameObject.SetActive(false);
		}

		private void Respawn()
		{
			transform.position = spawnPointHandler.GetSpawnPoint();
			ResetHealth();
			Hearts--;
		}
	}
}