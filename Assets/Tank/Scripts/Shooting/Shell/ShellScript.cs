using Pool;
using Scripts;
using UnityEngine;

namespace Tank.Scripts.Shooting.Shell
{
	public class ShellScript : MonoBehaviour
	{
		[SerializeField] private float shellLife = 10f;

		private Timer explodeTimer;
		private IShellCollisionsHandler shellCollisionsHandler;

		private void Awake()
		{
			shellCollisionsHandler = GetComponent<IShellCollisionsHandler>();
			shellCollisionsHandler.OnCollisionEnter += Explode;
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
			ResetParameters();
			GetComponent<PoolMember>().ReturnToPool();
		}

		private void ResetParameters()
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			var objectTransform = transform;
			objectTransform.position = Vector3.zero;
			objectTransform.eulerAngles = Vector3.zero;
		}
	}
}

