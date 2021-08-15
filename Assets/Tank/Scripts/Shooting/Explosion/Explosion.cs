using Pool;
using UnityEngine;

namespace Tank.Scripts.Shooting.Explosion
{
	public class Explosion : MonoBehaviour
	{
		private ParticleEffectHandler particleEffectHandler;
		[SerializeField] private float timeToAnimationOver = 2f;

		private Timer destroyTimer;

		private void Awake()
		{
			particleEffectHandler = GetComponent<ParticleEffectHandler>();

		}

		private void OnEnable()
		{
			destroyTimer = new Timer(timeToAnimationOver);
			destroyTimer.ResetTimer();
			destroyTimer.OnTimerEnd += ReturnToPool;

			particleEffectHandler.Play();
		}

		private void OnDisable()
		{
			destroyTimer.OnTimerEnd -= ReturnToPool;
		}

		private void Update()
		{
			destroyTimer.Update();
		}

		private void ReturnToPool()
		{
			GetComponent<PoolMember>().ReturnToPool();
		}
		
	}
}