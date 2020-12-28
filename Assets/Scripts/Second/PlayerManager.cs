using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MaglioneFramework
{
    public class PlayerManager : MonoBehaviour
    {
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
}