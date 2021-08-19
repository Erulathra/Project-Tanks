using Pool;
using Tank.Scripts.Shooting.ExplosionScripts;
using UnityEngine;


namespace Tank.Scripts.Shooting.Shell
{
	public class RigidbodyShellScript : MonoBehaviour
	{
		[SerializeField] private float shellLifeTime = 10f;
		[SerializeField] private float explosionLifeTime = 2f;
		
		
		private Timer explodeTimer;
		public ObjectPoolManager ExplosionPool { get; set; }
		private IShellCollisionsHandler shellCollisionsHandler;

		
		private void Awake()
		{
			//ExplosionPool = GameObject.FindWithTag("ExplosionPool").GetComponent<ObjectPoolManager>();

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
			explodeTimer = new Timer(shellLifeTime);
			explodeTimer.OnTimerEnd += Explode;
			explodeTimer.OnTimerEnd += ReturnToPool;
			explodeTimer.Start();
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
			var explosion = GetExplosionObject();
			var explosionScript = explosion.GetComponent<Explosion>();
			AddPoolTimerComponentToExplosionObject(explosionScript);

			explosionScript.Explode();
		}

		private void AddPoolTimerComponentToExplosionObject(Explosion explosionScript)
		{
			var returnToPoolTimer = explosionScript.gameObject.AddComponent<UnityEventTimer>();
			returnToPoolTimer.timeToEnd = explosionLifeTime;
			returnToPoolTimer.onTimerEnd.AddListener(explosionScript.Explode);
			returnToPoolTimer.Start();
		}

		private GameObject GetExplosionObject()
		{
			var explosion = ExplosionPool.GetObject();
			explosion.transform.position = GetHitPoint();
			explosion.SetActive(true);
			return explosion;
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