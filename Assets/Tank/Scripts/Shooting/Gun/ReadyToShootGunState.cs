namespace Tank.Scripts.Shooting.Gun
{
	public class ReadyToShootGunState : IGunState
	{
		public IGunState DoState(TankShootingController gun)
		{
			gun.ParticleEffectHandler.Play();
			gun.ShootingHandler.Shoot();
			return new ReloadingGunState();
		}

		public void Update()
		{ }
	}
}