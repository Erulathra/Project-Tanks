using UnityEngine;
using UnityEngine.VFX;

namespace Tank.Scripts
{
	public class TankShootParticleEffectHandlerVFX : TankShootParticleEffectHandler
	{
		[SerializeField] private VisualEffect muzzleFlash;

		protected override void Play()
		{
			muzzleFlash.Play();
		}
	}
	
}