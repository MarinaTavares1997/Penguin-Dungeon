using UnityEngine;
using PenguinDungeon.Core;

namespace PenguinDungeon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed; 
        [SerializeField] private bool flipX;
        [SerializeField] private bool flipY;
        
        private Movement movement;

        [SerializeField] private Animator animator;
        private static readonly int Blend = Animator.StringToHash("Blend");

        private byte lastPos = 1;
        private byte position = 0;

        private unsafe void Start()
        {
            animator = GetComponent<Animator>() != null ? GetComponent<Animator>() : null;

            fixed (bool* flipObj = &flipX)
            {
                fixed (float* ptr = &speed)
                {
                    movement = new Movement(transform, points, true)
                    {
                        MoveSpeed = ptr,
                        FlipObjectOnChangeDirection = flipObj,
                    };
                }
            }
        }

        private void FixedUpdate()
        {
            movement.MoveInRound(true);

            if(flipY) return;
            
            if (movement.GetChangeYFlip() && lastPos != position)
            {
                FlipY();
            }
        }

        private void FlipY()
        {
            lastPos = position;
            position = position == 1 ? position = 0 : position = 1;
            animator.SetFloat(Blend, position);
        }
    }
}