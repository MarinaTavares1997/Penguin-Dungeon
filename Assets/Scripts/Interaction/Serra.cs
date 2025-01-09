using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PenguinDungeon
{
    public class Serra : MonoBehaviour
    {
        private float x;

        // Update is called once per frame
        void Update()
        {
            Rotation();        
        }

        private void Rotation()
        {
            x = x + Time.deltaTime * 500;
            transform.rotation = Quaternion.Euler(0,0,x);
        }
    }
}
