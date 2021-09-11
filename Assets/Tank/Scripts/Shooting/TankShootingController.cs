using Entities_Scripts.ExplosionScripts;
using Tank.Scripts.Input;
using Tank.Scripts.Shooting.Gun;
using UnityEngine;

namespace Tank.Scripts.Shooting
{
	public class TankShootingController : MonoBehaviour
	{
		[SerializeField] public float reloadingTime = 1;
		[SerializeField] public ExplosionData explosionData;
		public ParticleEffectHandler ParticleEffectHandler { get; private set; }
		public IShootingHandler ShootingHandler { get; private set; }
		
		private IInputHandler inputHandler;
		private IGunState gunState;
		
		private void Start()
		{
			PrepareThisComponent();
		}

		private void PrepareThisComponent()
		{
			inputHandler = GetComponent<IInputHandler>();
			ShootingHandler = GetComponent<IShootingHandler>();
			ShootingHandler.ExplosionData(explosionData);
			ParticleEffectHandler = GetComponent<ParticleEffectHandler>();

			gunState = new ReadyToShootGunState();
		}

		private void Update()
		{
			gunState.Update();
			if (inputHandler.IsShooting)
			{
				gunState = gunState.DoState(this);
			}
			
		}
		
	}
}