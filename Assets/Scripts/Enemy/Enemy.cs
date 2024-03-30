using UnityEngine;
using PenguinDungeon.Core;

namespace PenguinDungeon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        [SerializeField] private bool flip;
        
        private Movement movement;
        
        private unsafe void Start()
        {
            fixed (bool* flipObj = &flip)
            {
                fixed (float* ptr = &speed)
                {
                    movement = new Movement(transform, points, true)
                    {
                        MoveSpeed = ptr,
                        FlipObjectOnChangeDirection = flipObj
                    };
                }
            }
        }

        private void Update()
        {
            movement.MoveInRound(true);
        }
    }
}