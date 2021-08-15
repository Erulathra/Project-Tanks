using UnityEngine;

namespace Tank.Scripts.Shooting.Gun
{
	public class ReloadingGunState : IGunState
	{
		private float timeFromStart;

		public ReloadingGunState()
		{
			timeFromStart = 0f;
		}
		
		public IGunState DoState(TankShootingController gun)
		{
			if (timeFromStart < gun.reloadingTime) return this;
			return new ReadyToShootGunState();
		}

		public void Update()
		{
			timeFromStart += Time.deltaTime;
		}
	}
}