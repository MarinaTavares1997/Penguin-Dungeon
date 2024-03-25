using System.Collections.Generic;
using PenguinDungeon.Player;
using UnityEngine;

namespace PenguinDungeon
{
    public class HealthHeartBar : MonoBehaviour
    {
        public GameObject heartPrefab;
        public PlayerHealth playerHealth;
        List<HealthHeart> heart = new List<HealthHeart>();

        private void OnEnable()
        {
            PlayerHealth.OnPlayerDamaged += DrawHearts;
        }

        private void OnDisable()
        {
            PlayerHealth.OnPlayerDamaged -= DrawHearts;
        }

        private void Start()
        {
            DrawHearts();
        }

        public void DrawHearts()
        {
            ClearHearts();

            float maxHealthRemainder = playerHealth.maxHealth % 2;
            int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);
            for(int i = 0; i < heartsToMake; i++)
            {
                CreateEmptyHeart();
            }

            for(int i = 0; i < heart.Count; i++)
            {
                int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
                heart[i].SetHeartImage((HeartStatus)heartStatusRemainder);
            }
        }

        public void CreateEmptyHeart()
        {
            GameObject newHeart = Instantiate(heartPrefab);
            newHeart.transform.SetParent(transform);

            HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
            heartComponent.SetHeartImage(HeartStatus.Empty);
            heart.Add(heartComponent);
        }

        public void ClearHearts()
        {
            foreach(Transform t in transform)
            {
                Destroy(t.gameObject);
            }
            heart = new List<HealthHeart>();
        }
    }
}
