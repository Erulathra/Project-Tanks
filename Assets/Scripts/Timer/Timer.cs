using System;

namespace s1nu5
{
	public class Timer
   {
   	public event Action OnTimerEnd;
   	
      public float TimeToEnd { get; }

      public float RemainingSeconds { get; private set; }

      public bool IsTicking { get; private set; }

      
   	public Timer(float remainingSeconds)
   	{
   		TimeToEnd = remainingSeconds;
   		Stop();
   		IsTicking = false;
   	}
   		
   	public void Update(float deltaTime)
   	{
   		if (IsTicking == false) return;
	      RemainingSeconds -= deltaTime;
	      StopRemainingSecondsAtZero();
	      InvokeEventWhenTimesUp();
   	}

      private void StopRemainingSecondsAtZero()
      {
	      if (RemainingSeconds < 0) RemainingSeconds = 0;
      }

      private void InvokeEventWhenTimesUp()
   	{
   		if (RemainingSeconds > 0) return;
   		OnTimerEnd?.Invoke();
         Pause();
      }
   
   	public void Stop()
   	{
   		IsTicking = false;
   		RemainingSeconds = TimeToEnd;
         Pause();
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
