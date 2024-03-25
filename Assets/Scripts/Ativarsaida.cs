using UnityEngine;

namespace PenguinDungeon
{
    public class Ativarsaida : MonoBehaviour
    {
        public GameObject saida;

        public GameObject pinguimnegativo;

        // Update is called once per frame
        void Update()
        {
            pinguimnegativo = GameObject.Find("Pinguim negativo");

            if(!GameObject.Find("Pinguim negativo"))
            {
                saida.SetActive(false);
            }
            else
            {
                saida.SetActive(true);
            }
        }
    }
}
