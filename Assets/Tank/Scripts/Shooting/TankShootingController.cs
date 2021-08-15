using System;
using Tank.Scripts.Shooting.Gun;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Tank.Scripts.Shooting
{
	[RequireComponent(typeof(GamepadHandler))]
	public class TankShootingController : MonoBehaviour
	{
		[SerializeField] public float reloadingTime = 1;
		public ParticleEffectHandler ParticleEffectHandler { get; private set; }
		public IShootingHandler ShootingHandler { get; private set; }
		
		private IGamepadHandler gamepadHandler;
		private IGunState gunState;
		
		private void Start()
		{
			PrepareThisComponent();
		}

		private void PrepareThisComponent()
		{
			gamepadHandler = GetComponent<IGamepadHandler>();
			ShootingHandler = GetComponent<IShootingHandler>();
			ParticleEffectHandler = GetComponent<ParticleEffectHandler>();

			gamepadHandler.OnShoot += HandleShooting;
			gunState = new ReadyToShootGunState();
		}

		private void Update()
		{
			gunState.Update();
		}

		private void OnDestroy()
		{
			gamepadHandler.OnShoot -= HandleShooting;
		}
		
		private void HandleShooting()
		{
			gunState = gunState.DoState(this);
		}
	}
}