using UnityEngine;
using UnityEngine.Events;

namespace Entities_Scripts
{
    public class DamageHandler : MonoBehaviour
    {
        public UnityEvent onTakeDamage;
        public int TakenDamage { get; private set; } 
        
        public void TakeDamage(int damage)
        {
            TakenDamage += damage;
            onTakeDamage?.Invoke();
            Debug.Log("Boom! : " + TakenDamage);
        }
    }
}
