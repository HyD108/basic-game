using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HyD
{
    public class ShopDialog : Dialog, IComponentChecking
    {
        public Transform gridRoot;
        public ShopItemUI itemUIPrefab;
        private Shop m_shopMng;
        private GameManager m_gm;

        public bool IsComponentNull()
        {
            return m_shopMng == null && m_gm == null || gridRoot == null;
        }

        public override void Show(bool IsShow)
        {
            Pref.coins = 10000;
            base.Show(IsShow);
            m_shopMng = FindObjectOfType<Shop>();
            m_gm = FindObjectOfType<GameManager>();

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (IsComponentNull()) return;

            ClearChilds();

            var items = m_shopMng.items;

            if (items == null || items.Length <= 0 ) return;

            for ( int i = 0; i < items.Length; i++ )
            {
                int idx = i;    

                var item = items[idx];

                var ItemUIClone = Instantiate(itemUIPrefab, Vector3.zero, Quaternion.identity); 

               ItemUIClone.transform.SetParent(gridRoot);
                
                ItemUIClone.transform.localScale = Vector3.one; 

                ItemUIClone.transform.localPosition = Vector3.zero;

                ItemUIClone.UpdateUI(item, idx);

                if (ItemUIClone.btn)
                {
                    ItemUIClone.btn.onClick.RemoveAllListeners();
                    ItemUIClone.btn.onClick.AddListener(() => ItemEvent(item, idx));
                }
            }
        }
        private void ItemEvent(ShopItem item, int itemIdex)
        {
            if( item == null ) return;

            bool IsUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF + itemIdex);

            if (IsUnlocked )
            {
                if (itemIdex == Pref.curPlayerid) return;

                Pref.curPlayerid = itemIdex;

                m_gm.ActivePlayer();

                UpdateUI();
            }else if(Pref.coins >= item.price)
            {
                Pref.coins -= item.price;
                Pref.SetBool(Const.PLAYER_PREFIX_PREF + itemIdex, true);
                Pref.curPlayerid = itemIdex;

                m_gm.ActivePlayer();

                UpdateUI();

                if (m_gm.guiMng)
                    m_gm.guiMng.UpdateMainCoins();
            }
            else
            {
                Debug.Log("Mot Enough Money");
            }
        }

        public void ClearChilds()
        {
            if(gridRoot == null || gridRoot.childCount <= 0) return;

            for (int i = 0;i < gridRoot.childCount; i++)
            {
                var child = gridRoot.GetChild(i);

                if (child != null)
                    Destroy(child.gameObject);
            }
        }
    }
}
