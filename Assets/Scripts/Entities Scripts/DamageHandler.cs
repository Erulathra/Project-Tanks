using UnityEngine;
using UnityEngine.Events;

namespace Entities_Scripts
{
    public class DamageHandler : MonoBehaviour
    {
        public UnityEvent<int> onTakeDamage;
        public int TakenDamage { get; private set; } 
        
        public void TakeDamage(int damage)
        {
            TakenDamage += damage;
            onTakeDamage?.Invoke(damage);
        }

        public void ResetDamage()
        {
            TakenDamage = 0;
        }
    }
}
