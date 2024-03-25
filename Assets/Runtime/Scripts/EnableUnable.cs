using UnityEngine;

namespace PenguinDungeon
{
    public class EnableUnable : MonoBehaviour
    {
        public GameObject espinhos;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                espinhos.SetActive(false);
            }
            else
            {
                espinhos.SetActive(true);
            }
        }
    }
}
