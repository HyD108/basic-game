using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace HyD
{
    public class GUImanager : MonoBehaviour
    {
        public GameObject HomeGui;
        public GameObject GameGui;
        public Text MainCoinTxt;
        public Dialog gameoverDialog;
        public Text gameplayCoinTxt;

        private void Start()
        {
            
        }
        public void ShowGameGui(bool IsShow)
        {
            if (GameGui)
                GameGui.SetActive(IsShow);
            if (HomeGui)
            {
                HomeGui.SetActive(!IsShow);
            }
        }

        public void UpdateMainCoins()
        {
            if (MainCoinTxt)
                MainCoinTxt.text = Pref.coins.ToString();
        }

        public void UpdateGamePlayCoins()
        {
            if (gameplayCoinTxt)
                gameplayCoinTxt.text = Pref.coins.ToString();
        }
    }
}
