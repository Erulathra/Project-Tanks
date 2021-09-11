using Pool;
using UnityEngine;

namespace Entities_Scripts.ExplosionScripts
{
	public class ExplosionSpawner
	{
		private ObjectPoolManager explosionPool;
		private ExplosionData explosionData;
		private Vector3 position;
		private GameObject explosion;
		

		public void SetPool(ObjectPoolManager explosionPool)
		{
			this.explosionPool = explosionPool;
		}

		public void SetData(ExplosionData explosionData)
		{
			this.explosionData = explosionData;
		}

		public void SetPosition(Vector3 position)
		{
			this.position = position;
		}

		public void Spawn()
		{
			explosion = explosionPool.GetObject();
			explosion.SetActive(true);
			explosion.transform.position = position;
		}
		
		public void Explode()
		{
			var explosionScript = explosion.GetComponent<Explosion>();
			explosionScript.SetProperties(explosionData);
			explosionScript.Explode();
		}
	}
}