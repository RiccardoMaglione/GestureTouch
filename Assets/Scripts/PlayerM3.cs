using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerM3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
