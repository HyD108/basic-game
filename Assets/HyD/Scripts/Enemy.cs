using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class Enemy : MonoBehaviour
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
            if (m_rb == null || m_player == null) return;
                       
            m_rb.velocity = new Vector2 (-speed, m_rb.velocity.y);

            if (Vector2.Distance(m_player.transform.position, transform.position) <= AtkDis)
            {
           
                m_anim.SetBool(Const.ATTACK_ANIM, true);
       
                m_rb.velocity = Vector2.zero; //(0,0)
            }
            else
            {
                m_rb.velocity = new Vector2(-speed, m_rb.velocity.y);
            }
        }
    }
}
