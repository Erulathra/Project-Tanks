using System;
using UnityEngine;

public class Timer
{
	public event Action OnTimerEnd;
	private readonly float timeToEnd;
	private float remainingSeconds;

	private bool isTicking;
	private bool wasInvoked;
	
	public Timer(float remainingSeconds)
	{
		timeToEnd = remainingSeconds;
		ResetTimer();
	}
		
	public void Update()
	{
		if (isTicking == false) return; 
		remainingSeconds -= Time.deltaTime;
		InvokeEventWhenTimesUp();
	}

	private void InvokeEventWhenTimesUp()
	{
		if (remainingSeconds > 0) return;
		if (wasInvoked) return;
		OnTimerEnd?.Invoke();
		wasInvoked = true;
	}

	public void ResetTimer()
	{
		isTicking = false;
		wasInvoked = false;
		remainingSeconds = timeToEnd;
	}

	public void Start()
	{
		isTicking = true;
	}
	
	public void Pause()
	{
		isTicking = false;
	}
		
}