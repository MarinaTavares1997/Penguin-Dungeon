using UnityEngine;

namespace PenguinDungeon
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Transform destination;
        public GameObject player;

        public Transform GetDestination()
        {
            return destination;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                player.transform.position = destination.position;
            }
        }
    }
}
