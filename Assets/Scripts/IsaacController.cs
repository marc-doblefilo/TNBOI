using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class IsaacController : MonoBehaviour
{

    Rigidbody2D body;
    public Transform firePoint;
    public Animator animator;
    public Text SpeedUIText;

    private float runSpeed = 5.0f;
    public float Speed = 1f;
    Vector2 headPos;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
    }

    void FixedUpdate()
    {
        SpeedUIText.text = Speed.ToString();

        var gamepad = Gamepad.current;
        if(gamepad == null) {
            return;
        }

        body.velocity = gamepad.leftStick.ReadValue() * runSpeed * Speed;
        animator.SetFloat("Horizontal", gamepad.leftStick.ReadValue().x);
        animator.SetFloat("Vertical", gamepad.leftStick.ReadValue().y);
        animator.SetFloat("Speed", gamepad.leftStick.ReadValue().sqrMagnitude);
    }
}
