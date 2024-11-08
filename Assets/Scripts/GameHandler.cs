using UnityEngine;
using UnityEngine.UI;

namespace PenguinDungeon
{
    public class GameHandler : MonoBehaviour
    {
        public Text coinScore;
        public int coins = 0;
        public int peixe;
        public GameObject saida;

        // Update is called once per frame
        void Update()
        {
            coinScore.text = "=  " + coins.ToString();

            if(coins == peixe)
            {
                saida.SetActive(false);
            }
            else
            {
                saida.SetActive(true);
            }
        }
    }
}
