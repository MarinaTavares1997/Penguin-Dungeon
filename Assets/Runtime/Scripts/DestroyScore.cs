using UnityEngine;

namespace PenguinDungeon
{
    public class DestroyScore : MonoBehaviour
    {
        public GameObject gameobj;

        // Start is called before the first frame update
        void Start()
        {
            if(GameObject.Find("Canvas 1(Clone)"))
            {
                gameobj = GameObject.Find("Canvas 1(Clone)");
                Destroy(gameobj);
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
