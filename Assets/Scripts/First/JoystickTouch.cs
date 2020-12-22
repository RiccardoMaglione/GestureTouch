using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTouch : MonoBehaviour
{
    public GameObject Player;
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

                    Player.transform.Translate(Vector3.up * Speed * Time.deltaTime * direction.y);
                    Player.transform.Translate(Vector3.right * Speed * Time.deltaTime * direction.x);


                    direction1 = new Vector2(Mathf.RoundToInt(direction.x), Mathf.RoundToInt(direction.y));
                    if (direction1 == Vector2.up)
                    {
                        print("Up");
                    }
                    if (direction1 == Vector2.down)
                    {
                        print("Down");
                    }
                    if (direction1 == Vector2.left)
                    {
                        print("Left");
                    }
                    if (direction1 == Vector2.right)
                    {
                        print("Right");
                    }
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Stationary:
                    Player.transform.Translate(Vector3.up * Speed * Time.deltaTime * direction.y);
                    Player.transform.Translate(Vector3.right * Speed * Time.deltaTime * direction.x);
                    break;
                case TouchPhase.Ended:
                    direction1 = Vector3.zero;
                    break;
            }
        }
    }
}
