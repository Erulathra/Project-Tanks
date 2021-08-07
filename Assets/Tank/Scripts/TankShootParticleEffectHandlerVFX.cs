using UnityEngine;
using UnityEngine.VFX;

namespace Tank.Scripts
{
	public class TankShootParticleEffectHandlerVFX : MonoBehaviour, ITankShootParticleEffectHandler
	{
		[SerializeField] private VisualEffect muzzleFlash;

		public void Play()
		{
			muzzleFlash.Play();
		}
	}
	
}