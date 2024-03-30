using UnityEngine;

namespace PenguinDungeon
{
    public class DontDestroyScore : MonoBehaviour
    {
        public GameObject gameobj;

        // Start is called before the first frame update
        void Start()
        {
            if(!GameObject.Find("Canvas 1(Clone)"))
            {
                Instantiate(gameobj);
            }
        }

    }
}
