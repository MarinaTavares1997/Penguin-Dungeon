﻿using UnityEngine;

namespace PenguinDungeon
{
    public class EnableUnable2 : MonoBehaviour
    {
        public GameObject espinhos;

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                espinhos.SetActive(true);
            }
            else
            {
                espinhos.SetActive(false);
            }
        }
    }
}
