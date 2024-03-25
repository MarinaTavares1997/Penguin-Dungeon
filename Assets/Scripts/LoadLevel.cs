using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinDungeon
{
    public class LoadLevel : MonoBehaviour
    {
        public int iLevelToLoad;
        public string sLevelToLoad;
        public bool useIntegerToLoadLevel = false;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject collisionGameObject = collision.gameObject;

            if(collisionGameObject.name == "Player")
            {
                LoadScene();
            }
        }

        void LoadScene()
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }
}
