using System.Collections.Generic;
using UnityEngine;

namespace PenguinDungeon.Core
{
    public unsafe class Movement
    {
        /// <summary>
        /// Movement Speed
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public float* MoveSpeed { get; set; }

        public bool* FlipObjectOnChangeDirection { get; set; }
        
        private readonly Transform transform;
        private readonly Vector2[] positions;

        private readonly bool useRandomPosition;

        private int currentPosition;

        /// <summary>
        /// Movement GameObjects in Unity
        /// </summary>
        /// <param name="transform">Object to movement</param>
        public Movement(Transform transform)
        {
            this.transform = transform;
            this.useRandomPosition = false;
        }

        /// <summary>
        /// Movement GameObjects in Unity
        /// </summary>
        /// <param name="transform">Object to movement</param>
        /// <param name="positions">Positions to object go</param>
        public Movement(Transform transform, Vector2[] positions)
        {
            this.transform = transform;
            this.positions = positions;
            useRandomPosition = false;
        }


        /// <summary>
        /// Movement GameObjects in Unity
        /// </summary>
        /// <param name="transform">Object to movement</param>
        /// <param name="positions">Positions to object go</param>
        public Movement(Transform transform, IReadOnlyList<Transform> positions)
        {
            this.transform = transform;
            this.positions = new Vector2[positions.Count];

            for (var i = 0; i < positions.Count; i++)
            {
                this.positions[i] = positions[i].position;
            }
        }

        /// <summary>
        /// Movement GameObjects in Unity
        /// </summary>
        /// <param name="transform">Object to movement</param>
        /// <param name="positions">Positions to object go</param>
        /// <param name="useRandomPosition">Will check the positions randomly</param>
        public Movement(Transform transform, IReadOnlyList<Transform> positions, bool useRandomPosition)
        {
            this.transform = transform;
            this.useRandomPosition = useRandomPosition;
            this.positions = new Vector2[positions.Count];

            for (var i = 0; i < positions.Count; i++)
            {
                this.positions[i] = positions[i].position;
            }
        }

        /// <summary>
        /// Movement GameObjects in Unity
        /// </summary>
        /// <param name="transform">Object to movement</param>
        /// <param name="positions">Positions to object go</param>
        /// <param name="useRandomPosition">Will check the positions randomly</param>
        public Movement(Transform transform, Vector2[] positions, bool useRandomPosition)
        {
            this.transform = transform;
            this.positions = positions;
            this.useRandomPosition = useRandomPosition;
        }

        /// <summary>
        /// Move game object to a specific position 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="deltaTime"></param>
        // ReSharper disable once MemberCanBePrivate.Global
        public void MoveToPosition(Vector2 position, bool deltaTime)
        {
            var step = deltaTime ? *MoveSpeed * Time.deltaTime : *MoveSpeed;
            transform.position = Vector2.MoveTowards(transform.position, position, step);
        }
        
        private bool PositionChecked()
        {
            return (Vector2)transform.position == positions[currentPosition];
        }

        /// <summary>
        /// Make object round one area
        /// The positions have to be defined on instantiate the object
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public void MoveInRound(bool deltaTIme)
        {
            MoveToPosition(positions[currentPosition], deltaTIme);

            if (!PositionChecked()) return;
            currentPosition = useRandomPosition ? Random.Range(0, positions.Length) :
                currentPosition >= positions.Length ? 0 : currentPosition++;
                
            if(*FlipObjectOnChangeDirection) Flip();
        }

        private void Flip()
        {
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        
        /// <summary>
        /// Translate the object to one direction
        /// Have to be called in game update
        /// </summary>
        /// <param name="direction">direction to go</param>
        // ReSharper disable once UnusedMember.Global
        public void MoveToDirection(Vector2 direction)
        {
            transform.Translate(direction * *MoveSpeed);
        }
    }
}
