using Pool;
using UnityEngine;

namespace Tank.Scripts.Shooting.Shell
{
	public class RigidbodyShellScript : MonoBehaviour
	{
		[SerializeField] private float shellLife = 10f;

		private Timer explodeTimer;
		public ObjectPoolManager ExplosionPool { get; set; }
		private IShellCollisionsHandler shellCollisionsHandler;


		private void Awake()
		{
			ExplosionPool = GameObject.FindWithTag("ExplosionPool").GetComponent<ObjectPoolManager>();

			shellCollisionsHandler = GetComponent<IShellCollisionsHandler>();
			shellCollisionsHandler.OnCollisionEnter += Explode;
			shellCollisionsHandler.OnCollisionEnter += ReturnToPool;
		}

		private void Update()
		{
			explodeTimer.Update();
		}

		private void OnEnable()
		{
			explodeTimer = new Timer(shellLife);
			explodeTimer.OnTimerEnd += Explode;
			explodeTimer.OnTimerEnd += ReturnToPool;
		}

		private void OnDisable()
		{
			explodeTimer.OnTimerEnd -= Explode;
			explodeTimer.OnTimerEnd -= ReturnToPool;
		}

		private void ReturnToPool()
		{
			ResetParameters();
			GetComponent<PoolMember>().ReturnToPool();
		}
		private void Explode()
		{
			AnimateExplosion();
		}
		
		private void AnimateExplosion()
		{
			var explosion = ExplosionPool.GetObject();
			explosion.transform.position = GetHitPoint();
			explosion.SetActive(true);
		}
		
		private Vector3 GetHitPoint()
		{
			var raycastShellCollisionsHandler = GetComponent<RaycastShellCollisionsHandler>();
			if (raycastShellCollisionsHandler == null) return transform.position;
			return raycastShellCollisionsHandler.GetHitPoint() == Vector3.zero ? transform.position : raycastShellCollisionsHandler.GetHitPoint();
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