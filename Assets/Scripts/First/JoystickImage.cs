using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickImage : MonoBehaviour
{
    public Vector3 pos;
    Vector3 InitialPosition;

    void Start()
    {
        InitialPosition = transform.position;
        pos = transform.position;
    }

    void Update()
    {
        #region Movimento Translate
        transform.Translate(Vector3.up * 90 * Time.deltaTime * JoystickTouch.direction.y);
        transform.Translate(Vector3.right * 90 * Time.deltaTime * JoystickTouch.direction.x);
        #endregion

        #region Blocco movimento joystick
        pos.x = Mathf.Clamp(transform.position.x, 0, 75);
        pos.y = Mathf.Clamp(transform.position.y, 0, 75);
        transform.position = pos;
        #endregion

        #region Controllo Uni-Direzionale
        if (JoystickTouch.direction1 == Vector2.up && JoystickTouch.direction1 != Vector2.down && JoystickTouch.direction1 != Vector2.left && JoystickTouch.direction1 != Vector2.right)
        {
            transform.position = new Vector3(InitialPosition.x, 75, 0);
        }
        if (JoystickTouch.direction1 != Vector2.up && JoystickTouch.direction1 == Vector2.down && JoystickTouch.direction1 != Vector2.left && JoystickTouch.direction1 != Vector2.right)
        {
            transform.position = new Vector3(InitialPosition.x, 0, 0);
        }
        if (JoystickTouch.direction1 != Vector2.up && JoystickTouch.direction1 != Vector2.down && JoystickTouch.direction1 == Vector2.left && JoystickTouch.direction1 != Vector2.right)
        {
            transform.position = new Vector3(0, InitialPosition.y, 0);
        }
        if (JoystickTouch.direction1 != Vector2.up && JoystickTouch.direction1 != Vector2.down && JoystickTouch.direction1 != Vector2.left && JoystickTouch.direction1 == Vector2.right)
        {
            transform.position = new Vector3(75, InitialPosition.y, 0);
        }
        #endregion
        #region Nessuna direzione
        if (JoystickTouch.direction1 == Vector2.zero)
        {
            transform.position = InitialPosition;
        }
        #endregion
    }
}
