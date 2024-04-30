using PenguinDungeon.Player;
using UnityEngine;

namespace PenguinDungeon
{
    public class DamageOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            }
        }
    }
}
