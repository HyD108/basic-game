using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HyD
{
    public class ShopItemUI : MonoBehaviour
    {
        public Text priceTxt;
        public Image hub;
        public Button btn;
        public void UpdateUI(ShopItem item, int itemIdx)
        {
            if(item == null) return;
            
            if(hub)
                hub.sprite = item.previewImg;
            
            bool IsUnlocked = Pref.GetBool(Const.PLAYER_PREFIX_PREF +  itemIdx);

            if(IsUnlocked)
            {
                if(Pref.curPlayerid == itemIdx)
                {
                    if (priceTxt)
                        priceTxt.text = "Active";

                } else if (priceTxt)
                {
                    priceTxt.text = "Owned";
                }
            } else
            {
                if(priceTxt)
                    priceTxt.text = item.price.ToString();
            }
        }
    }

}