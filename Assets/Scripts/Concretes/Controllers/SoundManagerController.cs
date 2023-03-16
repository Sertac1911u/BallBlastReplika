using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallBlastReplika.Controllers
{
    public class SoundManagerController : MonoBehaviour
    {
        public static SoundManagerController instance;
        public AudioSource soundEffectSource;
        public AudioSource soundEffectESource;
        public AudioSource musicSource;

        private void Start()
        {
            instance = this;
        }

        public void PlayMusic(AudioClip musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
        public void PlaySound(AudioClip soundClip)
        {
            soundEffectSource.clip= soundClip;
            soundEffectSource.Play();
        }
        public void PlayEnemySound(AudioClip soundEClip)
        {
            soundEffectESource.clip = soundEClip;
            soundEffectESource.Play();
        }
    }

}