using Entities_Scripts;
using Pool;
using Tank.Scripts.Shooting;
using Tank.Scripts.Shooting.ExplosionScripts;
using UnityEngine;

namespace ExplosionScripts
{
	public class Explosion : MonoBehaviour
	{
		private ExplosionData explosionData;
		private ParticleEffectHandler particleEffectHandler;

		public void SetProperties(ExplosionData explosionData)
		{
			this.explosionData = explosionData;
		}
		
		private void Awake()
		{
			particleEffectHandler = GetComponent<ParticleEffectHandler>();
		}
		
		public void Explode()
		{
			var hitColliders = GetNearbyColliders();
			ApplyPhysics(hitColliders);
			ApplyDamage(hitColliders);
			particleEffectHandler.Play();
		}
		
		private Collider[] GetNearbyColliders()
		{
			var hitColliders = Physics.OverlapSphere(transform.position, explosionData.radius);
			return hitColliders;
		}
		
		private void ApplyPhysics(Collider[] nearbyColliders)
		{
			foreach (var hitCollider in nearbyColliders)
			{
				if (hitCollider.CompareTag("Explosion")) continue;
				ApplyExplosionForceToHitRigidbody(hitCollider);
			}
		}

		private void ApplyExplosionForceToHitRigidbody(Collider hitCollider)
		{
			
			var hitRigidbody = hitCollider.GetComponent<Rigidbody>();
			if (hitRigidbody == null) return;
			
			hitRigidbody.AddExplosionForce(explosionData.force, transform.position, explosionData.radius);
		}
		
		private void ApplyDamage(Collider[] nearbyColliders)
		{
			foreach (var hitCollider in nearbyColliders) ApplyExplosionDamageToHitRigidbody(hitCollider);
		}

		private void ApplyExplosionDamageToHitRigidbody(Collider hitCollider)
		{
			if (hitCollider.CompareTag("Explosion")) return;
			var hitDamageHandler = hitCollider.GetComponent<DamageHandler>();
			if (hitDamageHandler == null) return;
			
			//TODO Distance to damage
			
			hitDamageHandler.TakeDamage(explosionData.damage);
		}
		
		public void ReturnToPool()
		{
			var poolMember = GetComponent<PoolMember>();
			poolMember.ReturnToPool();
		}
	}
}