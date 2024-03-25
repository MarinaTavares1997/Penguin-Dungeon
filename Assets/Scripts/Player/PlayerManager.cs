using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinDungeon.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static bool isGameOver;

        public GameObject gameOverScreen;

        private void Awake()
        {
            isGameOver = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(isGameOver)
            {
                gameOverScreen.SetActive(true);
            }
        }

        public void Restart(string lvlName)
        {
            SceneManager.LoadScene(lvlName);
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
