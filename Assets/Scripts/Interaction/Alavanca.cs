using UnityEngine;

namespace PenguinDungeon.Interaction
{
    public class Alavanca : MonoBehaviour
    {
        public bool alavanca;
        public float tempo;
        public float tempototal;
        public GameObject armadilha;
    
        void Update()
        {
            tempototal -= 1 * Time.deltaTime;
            armadilha.SetActive(!(tempo <= 0));
        }
    }
}
