using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaglioneFramework
{
    public class Volume : MonoBehaviour
    {
        public Slider SliderVolume;                                     //Inizializzo slider per volume

        #region Lifecycle
        private void Start()
        {
            SliderVolume.value = PlayerPrefs.GetFloat("Volume");        //Setto il valore del volume prendendolo dai playerprefs
        }
        private void Update()
        {
            ChangeVolume();
        }
        #endregion

        public void ChangeVolume()
        {
            AudioManager.Instance.Volume("Theme", SliderVolume);        //Setto il valore del volume prendendolo inserendolo nei playerprefs
        }
    }
}