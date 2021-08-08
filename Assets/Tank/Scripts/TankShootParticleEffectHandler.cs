using UnityEngine;

namespace Tank.Scripts
{
	public abstract class TankShootParticleEffectHandler : MonoBehaviour
	{
		public void Start()
		{
			var tankShootingController = GetComponent<TankShootingController>();
			tankShootingController.OnShoot += Play;
		}

		protected abstract void Play();
	}
}