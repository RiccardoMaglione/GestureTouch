using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaglioneFramework
{
    public class ChangeScene : MonoBehaviour
    {
        public GameObject PanelRule;

        public void MenuToFirst()
        {
            SceneManager.LoadScene("First");
        }
        public void MenuToSecond()
        {
            SceneManager.LoadScene("Second");
        }
        public void MenuToThird()
        {
            SceneManager.LoadScene("Third");
        }
        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void DeactivateRule()
        {
            if (PanelRule != null)
            {
                PanelRule.SetActive(false);
            }
        }
    }
}
