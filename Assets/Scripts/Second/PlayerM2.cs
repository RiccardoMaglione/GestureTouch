using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaglioneFramework
{
    public class PlayerM2 : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Hole")
            {
                SceneManager.LoadScene("GameOver");
            }
            if (other.name == "Flag")
            {
                SceneManager.LoadScene("Winning");
            }
        }
    }
}
