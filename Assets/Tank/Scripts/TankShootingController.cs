using System;
using UnityEngine;

namespace Tank.Scripts
{
	[RequireComponent(typeof(GamepadHandler))]
	public class TankShootingController : MonoBehaviour
	{
		[SerializeField] private Transform muzzle;

		private IGamepadHandler gamepadHandler;
		private TankShootParticleEffectHandler tankShootParticleEffectHandler;
		
		public event Action OnShoot;

		private void Start()
		{
			gamepadHandler = GetComponent<IGamepadHandler>();
			tankShootParticleEffectHandler = GetComponent<TankShootParticleEffectHandler>();
		}

		private void Update()
		{
			HandleShooting();
		}

		private void HandleShooting()
		{
			if (!gamepadHandler.IsShooting) return;
			OnShoot?.Invoke();
		}
	}
}