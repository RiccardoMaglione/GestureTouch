using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

namespace MaglioneFramework
{
    public class AudioManager : MonoBehaviour
    {
        #region Variables
        public Sound[] Sounds;
        public static AudioManager Instance;
        public static bool isPause = true;
        #endregion

        #region Lifecycle
        private void Awake()
        {
            #region Singleton
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            #endregion

            foreach (Sound S in Sounds)
            {
                S.Source = gameObject.AddComponent<AudioSource>();
                S.Source.clip = S.Clip;
                S.Source.volume = S.Volume;
                S.Source.pitch = S.Pitch;
                S.Source.loop = S.Loop;
            }
        }

        void Start()
        {
            Play("Theme");

        }
        #endregion

        #region Standard Method
        /// <summary>
        /// Metodo per far partire un audio
        /// </summary>
        /// <param name="Name"></param>
        public void Play(string Name)
        {
            Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
            if (S == null)
            {
                Debug.LogWarning("Sound: " + Name + "not found!");
                return;
            }
            S.Source.Play();
        }

        /// <summary>
        /// Metodo per far fermare un audio
        /// </summary>
        /// <param name="Name"></param>
        public void Stop(string Name)
        {
            Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
            if (S == null)
            {
                Debug.LogWarning("Sound: " + Name + "not found!");
                return;
            }
            S.Source.Stop();
        }

        /// <summary>
        /// Metodo per mettere in pausa un audio
        /// </summary>
        /// <param name="Name"></param>
        public void Pause(string Name)
        {
            Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
            if (S == null)
            {
                Debug.LogWarning("Sound: " + Name + "not found!");
                return;
            }
            S.Source.Pause();
        }

        /// <summary>
        /// Metodo per cambiare volume a un audio
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="SliderVolume"></param>
        public void Volume(string Name, Slider SliderVolume)
        {
            Sound S = Array.Find(Sounds, Sound => Sound.Name == Name);
            if (S == null)
            {
                Debug.LogWarning("Sound: " + Name + "not found!");
                return;
            }
            S.Source.volume = SliderVolume.value;
            PlayerPrefs.SetFloat("Volume", SliderVolume.value);
        }
        #endregion

        #region Advance Method
        /// <summary>
        /// Metodo per mettere e togliere la pausa attraverso un solo pulsante
        /// </summary>
        /// <param name="Name"></param>
        public void EffectivePause(string Name)
        {
            if (isPause == true)
            {
                Pause(Name);
                isPause = false;
            }
            else if (isPause == false)
            {
                Instance.Play(Name);
                isPause = true;
            }
        }
        #endregion
    }
}