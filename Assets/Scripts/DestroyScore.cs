using UnityEngine;

namespace PenguinDungeon
{
    public class DestroyScore : MonoBehaviour
    {
        public GameObject gameobj;

        // Start is called before the first frame update
        private void Start()
        {
            if(GameObject.Find("Canvas 1(Clone)"))
            {
                gameobj = GameObject.Find("Canvas 1(Clone)");
                Destroy(gameobj);
            }
        }
    }
}
