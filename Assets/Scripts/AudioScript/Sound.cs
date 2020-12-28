﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaglioneFramework
{
    /// <summary>
    /// Classe sound per inizializzare delle variabili inerente all'AudioManager
    /// </summary>
    [System.Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0f, 1f)]
        public float Volume;
        [Range(.1f, 3f)]
        public float Pitch;

        public bool Loop;

        [HideInInspector]
        public AudioSource Source;
    }
}