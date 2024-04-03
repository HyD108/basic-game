using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class Enemy : MonoBehaviour, IComponentChecking
    {
        private Animator m_anim;
        private Rigidbody2D m_rb;
        public float speed;
        public float AtkDis;
        private Player m_player;
        private bool m_dead;

        public int minCoinBonus;
        public int maxCoinBonus;

        private GameManager m_gm;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
            m_gm = FindObjectOfType<GameManager>();
        }
        // Start is called before the first frame update
        void Start()
        {
           
        }

        // Update is called once per frame
        void Update()
        {
            if (IsComponentNull()) return;

            float DisToPlayer = Vector2.Distance(m_player.transform.position, transform.position);

            if ( DisToPlayer <= AtkDis)
            {
           
                m_anim.SetBool(Const.ATTACK_ANIM, true);
       
                m_rb.velocity = Vector2.zero; //(0,0)
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }

        public bool IsComponentNull()
        {
            return m_anim == null || m_player == null || m_rb == null || m_gm == null;
        }
        public void Die()
        {
            if(IsComponentNull() || m_dead) return;
            m_dead = true;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
            
                m_gm.Score++;
            int coinBonus = Random.Range(minCoinBonus, maxCoinBonus);           
            Pref.coins += coinBonus;    
            if (m_gm.guiMng)
            {
                m_gm.guiMng.UpdateGamePlayCoins();
            }


            Destroy(gameObject, 2f);
        }
        
    }
}
