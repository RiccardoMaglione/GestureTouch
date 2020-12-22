using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickTouchSecond : MonoBehaviour
{
    public GameObject Player;
    public Image ArrowRight;
    public Image ArrowLeft;
    public Vector2 startPos;
    public static Vector2 direction;
    public static Vector2 direction1;
    public float Speed = 5;
    void Update()
    {

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.position.x < Screen.width / 2)
            {
                // Handle finger movements based on touch phase.
                switch (touch.phase)
                {
                    // Record initial touch position.
                    case TouchPhase.Began:
                        startPos = touch.position;
                        break;
    
                    // Determine direction by comparing the current touch position with the initial one.
                    case TouchPhase.Moved:
                        direction = (touch.position - startPos).normalized;
    
                        Player.transform.Translate(Vector3.right * Speed * Time.deltaTime * direction.x);
    
    
                        direction1 = new Vector2(Mathf.RoundToInt(direction.x), 0);
                        if (direction1 == Vector2.left)
                        {
                            ArrowLeft.color = Color.grey;
                            print("Left");
                        }
                        if (direction1 == Vector2.right)
                        {
                            ArrowRight.color = Color.grey;
                            print("Right");
                        }
                        break;
    
                    // Report that a direction has been chosen when the finger is lifted.
                    case TouchPhase.Stationary:
                        Player.transform.Translate(Vector3.right * Speed * Time.deltaTime * direction.x);
                        if (direction1 == Vector2.left)
                        {
                            ArrowLeft.color = Color.grey;
                            ArrowRight.color = Color.white;
                            print("Left");
                        }
                        if (direction1 == Vector2.right)
                        {
                            ArrowRight.color = Color.grey;
                            ArrowLeft.color = Color.white;
                            print("Right");
                        }
                        break;
                    case TouchPhase.Ended:
                        direction1 = Vector3.zero;
                        if (direction1 == Vector2.zero)
                        {
                            ArrowLeft.color = Color.white;
                            ArrowRight.color = Color.white;
                            print("Right");
                        }
                        break;
    
                }
            }
            else
            {
                direction1 = Vector3.zero;
                if (direction1 == Vector2.zero)
                {
                    ArrowLeft.color = Color.white;
                    ArrowRight.color = Color.white;
                    print("Right");
                }
            }
        }
    }
}