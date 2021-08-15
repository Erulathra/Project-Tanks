using System;
using UnityEngine;

public class Timer
{
	public event Action OnTimerEnd;
	private readonly float timeToEnd;
	private float remainingSeconds;

	public Timer(float remainingSeconds)
	{
		timeToEnd = remainingSeconds;
		ResetTimer();
	}
		
	public void Update()
	{
		remainingSeconds -= Time.deltaTime;
		if(remainingSeconds <= 0) OnTimerEnd?.Invoke();
	}

	public void ResetTimer()
	{
		remainingSeconds = timeToEnd;
	}
		
}