using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinDungeon
{
    public class SaveData : MonoBehaviour
    {
        private int currentSceneIndex;

        public void SaveGame()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        }
    }
}
