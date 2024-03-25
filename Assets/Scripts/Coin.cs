using UnityEngine;

namespace PenguinDungeon
{
    public class Coin : MonoBehaviour
    {
        public GameHandler GH;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            
                GH.coins++;
            }
        }
    }
}
