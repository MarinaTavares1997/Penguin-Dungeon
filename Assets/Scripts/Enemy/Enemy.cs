using UnityEngine;
using PenguinDungeon.Core;
using UnityEngine.Events;

namespace PenguinDungeon.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        [SerializeField] private float speed;
        [SerializeField] private bool flip;

        [SerializeField] private UnityEvent onChangeDirection;

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
                        onChangeTarget = onChangeDirection
                    };
                }
            }
        }

        private void Update()
        {
            movement.MoveInRound(true);
        }

        private byte position;

        public void FlipY()
        {
            position = position == 0 ? position = 1 : position = 0;
            Debug.Log(position);
            animator.SetFloat("blend", position);
        }
    }
}