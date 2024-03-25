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
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_rb = GetComponent<Rigidbody2D>();
            m_player = FindObjectOfType<Player>();
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
            return m_anim == null || m_player == null || m_rb == null;
        }
        public void Die()
        {
            if(IsComponentNull()) return;
            m_anim.SetTrigger(Const.DEAD_ANIM);
            m_rb.velocity = Vector2.zero;
            gameObject.layer = LayerMask.NameToLayer(Const.DEAD_ANIM);
        }
        
    }
}