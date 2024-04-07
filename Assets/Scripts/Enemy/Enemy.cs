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

        [SerializeField] private Animator animator;
        private static readonly int Blend = Animator.StringToHash("Blend");

        private unsafe void Start()
        {
            animator = GetComponent<Animator>() != null ? GetComponent<Animator>() : null;

            fixed (bool* flipObj = &flip)
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

        private void Update()
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            movement.MoveInRound(true);

            if (movement.GetChangeYFlip() && lastPos != position)
            {
                FlipY();
            }
        }

        private byte lastPos = 1;
        private byte position;

        public void FlipY()
        {
            lastPos = position;
            position = position == 1 ? position = 0 : position = 1;
            animator.SetFloat(Blend, position);
        }
    }
}