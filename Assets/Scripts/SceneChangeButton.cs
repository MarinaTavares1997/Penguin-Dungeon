using UnityEngine;
using UnityEngine.SceneManagement;

namespace PenguinDungeon
{
    public class SceneChangeButton : MonoBehaviour
    {
        public string cena;

        public void ChangeToScene()
        {
            SceneManager.LoadScene(cena);
        }
    }
}
