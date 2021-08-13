using UnityEngine;

namespace Tank.Scripts.Shooting
{
	[RequireComponent(typeof(GamepadHandler))]
	public class TankShootingController : MonoBehaviour
	{
		private IGamepadHandler gamepadHandler;
		private ParticleEffectHandler particleEffectHandler;
		private IShootingHandler shootingHandler;
		
		private void Start()
		{
			gamepadHandler = GetComponent<IGamepadHandler>();
			shootingHandler = GetComponent<IShootingHandler>();
			gamepadHandler.OnShoot += HandleShooting;
			particleEffectHandler = GetComponent<ParticleEffectHandler>();
		}

		private void OnDestroy()
		{
			gamepadHandler.OnShoot -= HandleShooting;
		}
		
		private void HandleShooting()
		{
			particleEffectHandler.Play();
			shootingHandler.Shoot();
		}
	}
}