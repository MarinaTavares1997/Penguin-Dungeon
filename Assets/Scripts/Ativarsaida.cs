using System;
using UnityEngine;

namespace PenguinDungeon
{
    public class Ativarsaida : MonoBehaviour
    {
        public GameObject saida;

        public GameObject pinguimnegativo;
        private GameObject o;

        private void Start()
        {
            o = GameObject.Find("Pinguim negativo");
            saida.SetActive(true);
        }


        // Update is called once per frame
        void Update()
        {
            if(!o)
            {
                saida.SetActive(false);
            }
        }
    }
}
