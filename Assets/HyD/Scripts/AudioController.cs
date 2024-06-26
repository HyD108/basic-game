using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyD
{
    public class AudioController : MonoBehaviour
    {
        [Header("Main Setting:")]
        [Range(0f, 1f)]
        public float musicVol = 0.3f;
        [Range(0f, 1f)]
        public float soundVol = 1f;

        public AudioSource musicAus;
        public AudioSource soundAus;

        [Header("Music and Sound in Gameplay:")]
        public AudioClip playerAtk;
        public AudioClip enemyDead;
        public AudioClip GameOver;
        public AudioClip[] bgms;

        private void Start()
        {
            if (musicAus == null ||  soundAus == null) return;

            musicVol = Pref.musicVol1;
            soundVol = Pref.soundVol1;

            musicAus.volume = musicVol;
            soundAus.volume = soundVol;
        }

        public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
        {
            if(!aus)
            {
                aus = soundAus;                      
            }

            if (aus == null) return;

            if (sounds == null || sounds.Length <= 0 ) return;

            int randInx = Random.Range(0, sounds.Length);
            if (sounds[randInx])
                aus.PlayOneShot(sounds[randInx], soundVol);
        }

        public void PlaySound(AudioClip sound, AudioSource aus = null)
        {
            if (!aus) 
                aus = soundAus;

            if(aus == null) return;

            if(sound)
                aus.PlayOneShot(sound,soundVol);
        }

        public void PlayMusic(AudioClip[] musics, bool isLoop = true)
        {
            if ( musicAus == null || musics == null || musics.Length <= 0) return;

            int randIdx = Random.Range(0, musics.Length);

            if (musics[randIdx])
            {
                musicAus.clip = musics[randIdx];
                musicAus.loop = isLoop;
                musicAus.volume = musicVol;
                musicAus.Play();
            }
        }

        public void PlayMusic(AudioClip music , bool isLoop = true)
        {
            if (musicAus == null || music == null) return;
            musicAus.clip = music;
            musicAus.loop = isLoop;
            musicAus.volume = musicVol;
            musicAus.Play();
        }

        public void SetMusicVolume(float volume)
        {
            if(musicAus == null) return;
            musicAus.volume = volume;
        }

        public void StopMusic()
        {
            if (musicAus == null) return;
            musicAus.Stop();
        }

        public void PlayBhm()
        {
            PlayMusic(bgms);
        }
    }

}