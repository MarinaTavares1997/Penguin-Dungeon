using System;
using PlasticPipe.Server;
using UnityEngine;

namespace PenguinDungeon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private void Start()
        {
            var movement = new Movement(this.transform);
        }
    }
}