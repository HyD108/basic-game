using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HyD
{
    public class GameOverDialog : Dialog
    {
        public Text bestScoreTxt;

        public override void Show(bool IsShow)
        {
            base.Show(IsShow);

            if (bestScoreTxt)
                bestScoreTxt.text = Pref.Bestscore.ToString("0000");
        }

        public void Replay()
        {
            Close();
            SceneManager.LoadScene(Const.GAMEPLAY_SCENE);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

}