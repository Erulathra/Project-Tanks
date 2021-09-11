using Entities_Scripts.ExplosionScripts;

namespace Tank.Scripts.Shooting
{
	public interface IShootingHandler
	{
		void ExplosionData(ExplosionData explosionData);
		void Shoot();
	}
}