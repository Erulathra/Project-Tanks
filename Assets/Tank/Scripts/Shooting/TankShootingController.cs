using System;
using UnityEngine;

namespace Tank.Scripts
{
	[RequireComponent(typeof(GamepadHandler))]
	public class TankShootingController : MonoBehaviour
	{
		private IGamepadHandler gamepadHandler;
		private TankShootParticleEffectHandler tankShootParticleEffectHandler;
		private IShootingHandler shootingHandler;
		
		private void Start()
		{
			gamepadHandler = GetComponent<IGamepadHandler>();
			shootingHandler = GetComponent<IShootingHandler>();
			gamepadHandler.OnShoot += HandleShooting;
			tankShootParticleEffectHandler = GetComponent<TankShootParticleEffectHandler>();
		}

		private void OnDestroy()
		{
			gamepadHandler.OnShoot -= HandleShooting;
		}
		
		private void HandleShooting()
		{
			tankShootParticleEffectHandler.Play();
			shootingHandler.Shoot();
		}
	}
}