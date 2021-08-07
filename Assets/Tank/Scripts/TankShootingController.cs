using UnityEngine;

namespace Tank.Scripts
{
	[RequireComponent(typeof(GamepadHandler))]
	public class TankShootingController : MonoBehaviour
	{
		[SerializeField] private Transform muzzle;

		private IGamepadHandler gamepadHandler;
		private ITankShootParticleEffectHandler tankShootParticleEffectHandler;

		private void Start()
		{
			gamepadHandler = GetComponent<IGamepadHandler>();
			tankShootParticleEffectHandler = GetComponent<ITankShootParticleEffectHandler>();
		}

		private void Update()
		{
			HandleShooting();
		}

		private void HandleShooting()
		{
			if (!gamepadHandler.IsShooting) return;
			tankShootParticleEffectHandler.Play();
		}
	}
}