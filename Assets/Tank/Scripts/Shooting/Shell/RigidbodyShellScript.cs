using ExplosionScripts;
using Pool;
using Tank.Scripts.Shooting.ExplosionScripts;
using UnityEngine;
using s1nu5;


namespace Tank.Scripts.Shooting.Shell
{
	public class RigidbodyShellScript : MonoBehaviour
	{
		[SerializeField] private float shellLifeTime = 10f;

		public ExplosionData ExplosionData { get; set; }
		
		private Timer explodeTimer;
		private IShellCollisionsHandler shellCollisionsHandler;
		public ObjectPoolManager ExplosionPool { get; set; }
		
		private void Awake()
		{
			shellCollisionsHandler = GetComponent<IShellCollisionsHandler>();
			shellCollisionsHandler.OnCollisionEnter += Explode;
			shellCollisionsHandler.OnCollisionEnter += ReturnToPool;
		}

		private void Update()
		{
			explodeTimer.Update(Time.deltaTime);
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
			explosionScript.SetProperties(ExplosionData);
			AddPoolTimerComponentToExplosionObject(explosionScript);
			
			explosionScript.Explode();
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
		
		private void AddPoolTimerComponentToExplosionObject(Explosion explosionScript)
		{
			var returnToPoolTimer = explosionScript.gameObject.AddComponent<UnityEventTimer>();
			returnToPoolTimer.timeToEnd = ExplosionData.lifeTime;
			returnToPoolTimer.onTimerEnd.AddListener(explosionScript.ReturnToPool);
			returnToPoolTimer.Start();
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