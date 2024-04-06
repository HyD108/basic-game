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
        private Player m_curPlayer;
        public Shop shopMng;


        public int Score { get => m_Score; set => m_Score = value; }

        // Start is called before the first frame update
        void Start()
        {
            
            if(IsComponentNull()) return;
            guiMng.ShowGameGui(false);

        }
        public bool IsComponentNull()
        {
            return guiMng == null || shopMng == null;
        }
        public void PlayGame()
        {
            ActivePlayer();

            StartCoroutine(SpawnEnemy());
            guiMng.ShowGameGui(true);
            guiMng.UpdateGamePlayCoins();
            
        }

        public void ActivePlayer()
        {
            if (IsComponentNull()) return;
            if (m_curPlayer)
            {
                Destroy(m_curPlayer.gameObject);
            }
            var shopItems = shopMng.items;

            if(shopItems == null || shopItems.Length <= 0) return;

            var newPlayerPb = shopItems[Pref.curPlayerid].playerPrefabs;

            if (newPlayerPb != null) 
                m_curPlayer = Instantiate(newPlayerPb,new Vector3(-7f, -1f,0f), Quaternion.identity);   
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

        
    }
}
