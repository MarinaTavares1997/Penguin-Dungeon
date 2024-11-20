using UnityEngine;

namespace PenguinDungeon.Interaction
{
    public class Ativaragua : MonoBehaviour
    {
        public GameObject agua;
    
        public Alavanca Alavanca;

        // Start is called before the first frame update
        void Start()
        {
            Alavanca = GameObject.Find("Alavanca").GetComponent<Alavanca>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Alavanca.alavanca)
            {
                agua.SetActive(true);
            }
            else
            {
                agua.SetActive(false);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (Alavanca.alavanca)
                {
                    agua.SetActive(true);
                }
                else
                {
                    agua.SetActive(false);
                }
           
            }
        }

    }
}
