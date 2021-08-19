using Entities_Scripts;
using Pool;
using UnityEngine;

namespace Tank.Scripts.Shooting.ExplosionScripts
{
	public class Explosion : MonoBehaviour
	{
		[SerializeField] private float radius = 3f;
		[SerializeField] private float force = 100f;
		[SerializeField] private int damage = 100;


		private ParticleEffectHandler particleEffectHandler;

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

		private void ApplyPhysics(Collider[] nearbyColliders)
		{
			foreach (var hitCollider in nearbyColliders) ApplyExplosionForceToHitRigidbody(hitCollider);
		}

		private Collider[] GetNearbyColliders()
		{
			var hitColliders = Physics.OverlapSphere(transform.position, radius);
			return hitColliders;
		}

		private void ApplyExplosionForceToHitRigidbody(Collider hitCollider)
		{
			var hitRigidbody = hitCollider.GetComponent<Rigidbody>();
			if (hitRigidbody == null) return;
			
			hitRigidbody.AddExplosionForce(force, transform.position, radius);
		}
		
		private void ApplyDamage(Collider[] nearbyColliders)
		{
			foreach (var hitCollider in nearbyColliders) ApplyExplosionDamageToHitRigidbody(hitCollider);
		}

		private void ApplyExplosionDamageToHitRigidbody(Collider hitCollider)
		{
			var hitDamageHandler = hitCollider.GetComponent<DamageHandler>();
			if (hitDamageHandler == null) return;
			
			//TODO Distance to damage
			
			hitDamageHandler.TakeDamage(damage);
		}

		public void ReturnToPool()
		{
			var poolMember = GetComponent<PoolMember>();
			poolMember.ReturnToPool();
		}
	}
}