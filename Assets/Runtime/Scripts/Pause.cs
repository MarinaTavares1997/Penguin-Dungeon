using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinDungeon
{
    public class Pause : MonoBehaviour
    {
        public static bool GameIsPaused = false;

        public GameObject pauseMenuUI;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pausa();
                }
            }
        }

        public void ShowPause()
        {
            pauseMenuUI.SetActive(true);

            Pausa();
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pausa()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
        }
    }
}
