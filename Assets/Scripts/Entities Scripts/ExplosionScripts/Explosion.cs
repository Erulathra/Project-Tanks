using Pool;
using Tank.Scripts.Shooting;
using UnityEngine;

namespace Entities_Scripts.ExplosionScripts
{
	public class Explosion : MonoBehaviour
	{
		private ExplosionData explosionData;
		private ParticleEffectHandler particleEffectHandler;

		private void Awake()
		{
			particleEffectHandler = GetComponent<ParticleEffectHandler>();
		}

		public void SetProperties(ExplosionData explosionData)
		{
			this.explosionData = explosionData;
		}

		public virtual void Explode()
		{
			var hitColliders = GetNearbyColliders();
			ApplyPhysics(hitColliders);
			ApplyDamage(hitColliders);
			SetScale();
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

			hitDamageHandler.TakeDamage(explosionData.damage);
		}

		private void SetScale()
		{
			transform.localScale = Vector3.one * explosionData.radius;
		}

		public void ReturnToPool()
		{
			transform.localScale = Vector3.one;
			var poolMember = GetComponent<PoolMember>();
			poolMember.ReturnToPool();
		}
	}
}