using UnityEngine;

namespace PenguinDungeon.Interaction
{
    public class Gaiola : MonoBehaviour
    {
        public GameObject gaiola;

        public Botao botao;

        // Start is called before the first frame update
        void Start()
        {
            botao = GameObject.Find("Botão").GetComponent<Botao>();
        }

        // Update is called once per frame
        void Update()
        {
            gaiola.SetActive(!botao.botao);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player")) return;
            gaiola.SetActive(!botao.botao);
        }
    }
}
