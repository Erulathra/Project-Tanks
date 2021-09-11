using Entities_Scripts.ExplosionScripts;
using Pool;
using s1nu5;
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

            DestroyThis(explosionScript);
        }

        private void DestroyThis(Explosion explosionScript)
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            explosionScript.Explode();
            Destroy(o);
        }

        private GameObject GetExplosionObject()
        {
            var explosion = explosionPool.GetObject();
            explosion.SetActive(true);
            explosion.transform.position = transform.position;
            return explosion;
        }
    }
    
}

