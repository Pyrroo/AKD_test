using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;


    public void FixedUpdate()
    {
        Vector3 direction = transform.forward * joystick.Vertical + transform.right * joystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
