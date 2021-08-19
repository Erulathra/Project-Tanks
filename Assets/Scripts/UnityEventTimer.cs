using UnityEngine;
using UnityEngine.Events;

public class UnityEventTimer : MonoBehaviour
{
	public float timeToEnd;
	public UnityEvent onTimerEnd;

	private Timer timer;
 //todo tu się pomyśli
	private void OnEnable()
	{
		timer = new Timer(timeToEnd);
		if(onTimerEnd != null) Start();
		
		onTimerEnd ??= new UnityEvent();
		
		timer.OnTimerEnd += InvokeEvent;
	}

	private void OnDisable()
	{
		timer.OnTimerEnd -= InvokeEvent;
	}

	private void InvokeEvent()
	{
		onTimerEnd?.Invoke();
	}

	private void Update()
	{
		timer.Update();
	}
	
	public void Start()
	{
		timer.Start();
	}
	
	public void Pause()
	{
		timer.Pause();
	}
	
	
}