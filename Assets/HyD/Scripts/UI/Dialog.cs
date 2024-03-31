using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HyD
{
    public class Dialog : MonoBehaviour
    {
        public Text titleText;
        public Text contentText;


        public virtual void Show(bool IsShow)
        {
            gameObject.SetActive(IsShow);
        }

        public virtual void UpdateDialod(string title, string content)
        {
            if (titleText != null)
                titleText.text = title;
            if (contentText)
                contentText.text = content;
        }
        public virtual void UpdateDialog()

        {

        }
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }   
}
