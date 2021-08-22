using Tank.Scripts.Shooting.ExplosionScripts;

namespace Tank.Scripts.Shooting
{
	public interface IShootingHandler
	{
		void ExplosionData(ExplosionData explosionData);
		void Shoot();
	}
}