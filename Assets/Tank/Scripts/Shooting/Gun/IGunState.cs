namespace Tank.Scripts.Shooting.Gun
{
	public interface IGunState
	{
		IGunState DoState(TankShootingController gun);
		void Update();
	}
}