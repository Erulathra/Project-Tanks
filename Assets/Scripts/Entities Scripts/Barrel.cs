using ExplosionScripts;
using Pool;
using Tank.Scripts.Shooting.ExplosionScripts;
using UnityEngine;

namespace Entities_Scripts
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private ExplosionData explosionData;
        public ObjectPoolManager explosionPool;
        
        private void Start()
        {
            explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<ObjectPoolManager>();
        }

        public void Explode()
        {
            var explosion = GetExplosionObject();
            var explosionScript = explosion.GetComponent<Explosion>();
            AddPoolTimerComponentToExplosionObject(explosionScript);

            gameObject.SetActive(false);
            explosionScript.Explode();
            Destroy(gameObject);
        }
        
        private GameObject GetExplosionObject()
        {
            var explosion = explosionPool.GetObject();
            explosion.SetActive(true);
            explosion.transform.position = transform.position;
            return explosion;
        }
        
        private void AddPoolTimerComponentToExplosionObject(Explosion explosionScript)
        {
            var returnToPoolTimer = explosionScript.gameObject.AddComponent<UnityEventTimer>();
            returnToPoolTimer.timeToEnd = explosionData.lifeTime;
            returnToPoolTimer.onTimerEnd.AddListener(explosionScript.ReturnToPool);
            returnToPoolTimer.Start();
        }
    }
}
