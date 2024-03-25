
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class Player : MonoBehaviour, IComponentChecking 
    {
        private Animator m_anim;
        public float AtkRate;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool IsDead;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = AtkRate;
        }
        // Start is called before the first frame update
        void Start()
        {

        }
        public bool IsComponentNull()
        {
            return m_anim == null;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                if (IsComponentNull()) return;
                
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                    m_isAttacked = true;
                
            }
            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;
                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = AtkRate;
                }
            }
        }
        public void ResetAtkAnim()
        {
           if (IsComponentNull()) return;  
                m_anim.SetBool(Const.ATTACK_ANIM, false);
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsComponentNull()) return;
            if (collision.CompareTag(Const.ENEMY_WEAPON_TAG) && !IsDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                IsDead = true;
            }
        }

    }
}
