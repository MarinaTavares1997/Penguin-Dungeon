using UnityEngine;

namespace PenguinDungeon.Core
{
    public class Movement
    {
        /// <summary>
        /// Movement Speed
        /// </summary>
        public float MoveSpeed { get; set; }

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
        // ReSharper disable once UnusedMember.Global
        public virtual void MoveToPosition(Vector2 position)
        {
            transform.Translate(position * MoveSpeed);
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
        public virtual void MoveInRound()
        {
            MoveToPosition(positions[currentPosition]);

            if (PositionChecked())
            {
                currentPosition = useRandomPosition ? Random.Range(0, positions.Length - 1) :
                    currentPosition >= positions.Length ? 0 : currentPosition++;
            }
        }
        
        /// <summary>
        /// Translate the object to one direction
        /// Have to be called in game update
        /// </summary>
        /// <param name="direction">direction to go</param>
        // ReSharper disable once UnusedMember.Global
        public void MoveToDirection(Vector2 direction)
        {
            transform.Translate(direction * MoveSpeed);
        }
    }
}
