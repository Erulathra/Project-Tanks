using Scripts;
using UnityEngine;

namespace Tank.Scripts.Shooting.Shell
{
	public class ShellScript : MonoBehaviour
	{
		[SerializeField] private float shellLife = 10f;

		private Timer explodeTimer;
		private IShellCollisionsHandler ShellCollisionsHandler;

		private void Awake()
		{
			ShellCollisionsHandler = GetComponent<IShellCollisionsHandler>();
			ShellCollisionsHandler.OnCollisionEnter += Explode;
		}

		private void OnEnable()
		{
			explodeTimer = new Timer(shellLife);
			explodeTimer.OnTimerEnd += Explode;
		}

		private void OnDisable()
		{
			explodeTimer.OnTimerEnd -= Explode;
		}

		private void Update()
		{
			explodeTimer.Update();
		}

		private void Explode()
		{
			Debug.Log("Boom!!!");
			ShellContainer.Instance.ReturnShell(this.gameObject);
		}
	}
}

