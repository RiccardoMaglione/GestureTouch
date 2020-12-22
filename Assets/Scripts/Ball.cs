using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static Rigidbody rb;
    public float dashForceInspector = 5;
    public static float dashForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dashForce = dashForceInspector;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Flag")
        {
            print("You win");
        }
    }
}
