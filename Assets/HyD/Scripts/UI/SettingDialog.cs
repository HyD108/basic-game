using HyD;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HyD
{
    public class SettingDialog : Dialog, IComponentChecking
    {
        public Slider musicSlider;
        public Slider soundSlider;
        private AudioController m_auCtr;

        public bool IsComponentNull()
        {
            return m_auCtr == null || musicSlider == null || soundSlider == null;
        }

        public override void Show(bool IsShow)
        {
            base.Show(IsShow);

            m_auCtr = FindObjectOfType<AudioController>();

            if (IsComponentNull() ) return;

            musicSlider.value = Pref.musicVol1;
            soundSlider.value = Pref.soundVol1;

        }

        public void OnMusicChange(float value)
        {
            if(IsComponentNull()) return;

            m_auCtr.musicVol = value;
            m_auCtr.musicAus.volume = value;

            Pref.musicVol1 = value;
        }
        public void OnSoundChange(float value)
        {
            if (IsComponentNull()) return;
            m_auCtr.soundVol = value;
            m_auCtr.soundAus.volume = value;
            Pref.soundVol1  = value;
        }
    }
}
