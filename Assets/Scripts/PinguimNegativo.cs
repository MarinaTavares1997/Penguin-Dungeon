using UnityEngine;

namespace PenguinDungeon
{
    public class PinguimNegativo : MonoBehaviour
    {
        public Transform m_Player;
        public float m_Velocidade;

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, m_Player.position, m_Velocidade * Time.deltaTime);
        }
    }
}
