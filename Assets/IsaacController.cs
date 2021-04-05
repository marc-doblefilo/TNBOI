using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsaacController : MonoBehaviour
{

    Rigidbody2D body;
    public Transform firePoint;

    public float runSpeed = 20.0f;
    Vector2 headPos;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
    }

    void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if(gamepad == null) {
            return;
        }

        body.velocity = gamepad.leftStick.ReadValue() * runSpeed;
        
        Vector3 lookVector = gamepad.rightStick.ReadValue();
        Vector3 rotatedVector = Quaternion.Euler(0,0,0) * lookVector;
        firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
    }
}
