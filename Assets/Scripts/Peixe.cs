using UnityEngine;

namespace PenguinDungeon
{
    public class Peixe : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {

            if(collision.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
