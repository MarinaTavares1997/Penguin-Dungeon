using System;
using UnityEngine;

namespace PenguinDungeon.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public static event Action OnPlayerDamaged;
        public static event Action OnPlayerDeath;
        public float health, maxHealth;

        // Start is called before the first frame update
        void Start()
        {
            health = maxHealth;
        }

        private void OnDestroy() {
            PlayerManager.isGameOver = true;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;

            OnPlayerDamaged?.Invoke();

            if(health <= 0)
            {
                health = 0;
                OnPlayerDeath?.Invoke();
                PlayerManager.isGameOver = true;
                Destroy(gameObject);
            }
        }
    }
}
