using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MaglioneFramework
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        public Slider SliderVolume;
        public Text VolumeTextValue;
        #endregion
    
        private void Start()
        {
            #region Set Volume
            //Verifico a inizio gioco il valore del volume e lo setto
            SliderVolume.value = PlayerPrefs.GetFloat("Volume");
            AudioManager.Instance.Volume("Theme", SliderVolume);
            VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");
            #endregion
        }
    
        #region Method
    
        /// <summary>
        /// Metodo per cambiare il volume
        /// </summary>
        public void ChangeVolume()
        {
            AudioManager.Instance.Volume("Theme", SliderVolume);
            VolumeTextValue.text = (SliderVolume.value * 100).ToString("0");
        }
        #endregion
    }
}