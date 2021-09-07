using UnityEngine;
using UnityEngine.VFX;

namespace Tank.Scripts.Shooting
{
	public class ParticleEffectHandlerVFX : ParticleEffectHandler
	{
		[SerializeField] private VisualEffect visualEffect;

		public override void Play()
		{
			visualEffect.Play();
		}
	}
	
}