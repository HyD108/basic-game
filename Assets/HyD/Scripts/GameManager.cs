using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class GameManager : MonoBehaviour, IComponentChecking
    {
        public float spawnTime;
        public Enemy[] enemyPrefabs;
        private bool m_GameIsOver;
        private int m_Score;
        public GUImanager guiMng;


        public int Score { get => m_Score; set => m_Score = value; }

        // Start is called before the first frame update
        void Start()
        {
            
            if(IsComponentNull()) return;
            guiMng.ShowGameGui(false);

        }
        public void PlayGame()
        {
            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGui(true);
            guiMng.UpdateGamePlayCoins();
        }

        public void GameOver()
        {
            if(m_GameIsOver) return;
            m_GameIsOver = true;
            Pref.Bestscore = m_Score;
            if(guiMng.gameoverDialog)
            guiMng.gameoverDialog.Show(true);
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

        public bool IsComponentNull()
        {
            return guiMng == null;
        }
    }
}
