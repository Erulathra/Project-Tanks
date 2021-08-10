using System;
using UnityEngine;

namespace Scripts
{
	public class Timer
	{
		public event Action OnTimerEnd;
		private float remainingSeconds;

		public Timer(float remainingSeconds)
		{
			this.remainingSeconds = remainingSeconds;
		}
		
		public void Update()
		{
			remainingSeconds -= Time.deltaTime;
			if(remainingSeconds <= 0) OnTimerEnd.Invoke();
		}
		
	}
}