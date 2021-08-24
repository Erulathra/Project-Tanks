using UnityEngine;
using UnityEngine.Events;
using s1nu5;

public class UnityEventTimer : MonoBehaviour
{
	[SerializeField] private bool isStartingOnEnable = false;

	public float timeToEnd;
	public UnityEvent onTimerEnd;

	private Timer timer;

	public void Start()
	{
		timer = new Timer(timeToEnd);
		
		timer.Start();
		timer.OnTimerEnd += InvokeEvent;
	}

	private void Update()
	{
		timer.Update(Time.deltaTime);
	}
	private void OnEnable()
	{
		onTimerEnd = new UnityEvent();
		if (timer != null) timer.OnTimerEnd += InvokeEvent;
		if (isStartingOnEnable) Start();
	}

	private void OnDisable()
	{
		timer.OnTimerEnd -= InvokeEvent;
	}

	private void InvokeEvent()
	{
		onTimerEnd?.Invoke();
	}

	public void Pause()
	{
		timer.Pause();
	}
}