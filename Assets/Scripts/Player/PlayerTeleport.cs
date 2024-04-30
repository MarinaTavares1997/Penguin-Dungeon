using UnityEngine;

namespace PenguinDungeon.Player
{
    public class PlayerTeleport : MonoBehaviour
    {
        private GameObject currentTeleporter;

        // Update is called once per frame
        void Update()
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Portal>().GetDestination().position;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Portal"))
            {
                currentTeleporter = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if(collision.CompareTag("Portal"))
            {
                if(collision.gameObject == currentTeleporter)
                {
                    currentTeleporter = null;
                }
            }
        }
    }
}
