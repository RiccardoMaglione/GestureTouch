using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerM2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Hole")
        {
            SceneManager.LoadScene("GameOver");
        }
        if (other.name == "Flag")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static bool isGrounded = true;
    public bool isGroundInspector;
    public static Rigidbody rb;
    public float jumpForceInspector = 5;
    public static float jumpForce;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpForce = jumpForceInspector;
    }
    private void Update()
    {
        isGroundInspector = isGrounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
