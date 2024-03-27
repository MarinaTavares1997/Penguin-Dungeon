using UnityEngine;
using PenguinDungeon.Core;

namespace PenguinDungeon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        private Movement movement;
        
        private unsafe void Start()
        {
            fixed (float* ptr = &speed)
            {
                movement = new Movement(transform, points, true)
                {
                    MoveSpeed = ptr
                };
            }
        }

        private void Update()
        {
            movement.MoveInRound(true);
        }
    }
}