using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSphere : MonoBehaviour
{
    public int Speed = 5;
    void Update()
    {
        if (this.gameObject.name == "GoUp") //Up to Down
        {
            transform.Translate(-transform.up * Speed * Time.deltaTime);
        }
        if (this.gameObject.name == "GoDown") //Down to Up
        {
            transform.Translate(transform.up * Speed * Time.deltaTime);
        }
        if (this.gameObject.name == "GoRight") //Right to Left
        {
            transform.Translate(transform.right * Speed * Time.deltaTime);
        }
        if (this.gameObject.name == "GoLeft") //Left to Right
        {
            transform.Translate(-transform.right * Speed * Time.deltaTime);
        }
    }
}
