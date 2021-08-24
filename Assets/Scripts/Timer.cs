using System;
using UnityEngine;

namespace s1nu5
{
	public class Timer
   {
   	public event Action OnTimerEnd;
      private bool wasInvoked;
   	
      public float TimeToEnd { get; }

      public float RemainingSeconds { get; private set; }

      public bool IsTicking { get; private set; }

      public bool WasInvoked => wasInvoked;
      
   	public Timer(float remainingSeconds)
   	{
   		TimeToEnd = remainingSeconds;
   		ResetTimer();
   		IsTicking = false;
   		wasInvoked = false;
   	}
   		
   	public void Update(float deltaTime)
   	{
   		if (IsTicking == false) return; 
   		RemainingSeconds -= Time.deltaTime;
   		InvokeEventWhenTimesUp();
   	}
   
   	private void InvokeEventWhenTimesUp()
   	{
   		if (RemainingSeconds > 0) return;
   		if (wasInvoked) return;
   		OnTimerEnd?.Invoke();
   		wasInvoked = true;
   	}
   
   	public void ResetTimer()
   	{
   		IsTicking = false;
   		wasInvoked = false;
   		RemainingSeconds = TimeToEnd;
   	}
   
   	public void Start()
   	{
   		IsTicking = true;
   	}
   	
   	public void Pause()
   	{
   		IsTicking = false;
   	}
   		
   }
}
