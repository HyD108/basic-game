using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class GameManager : MonoBehaviour
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        private bool m_GameIsOver;
        private int m_Score;

        public int Score { get => m_Score; set => m_Score = value; }

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        // Update is called once per frame
        void Update()
        {

        }
        IEnumerator SpawnEnemy()
        {
            while (!m_GameIsOver)
            {
                if (enemyPrefabs != null && enemyPrefabs.Length > 0)
                {
                    int RandomIndex = Random.Range(0, enemyPrefabs.Length);
                    Enemy enemyPrefab = enemyPrefabs[RandomIndex];
                    if (enemyPrefab != null)
                    {
                        Instantiate(enemyPrefab, new Vector3(7, 0, 0), Quaternion.identity);
                    }
                }
                yield return new WaitForSeconds(spawnTime);
            }
        }
    }
}
