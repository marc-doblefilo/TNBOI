using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IsaacController : MonoBehaviour
{

    Rigidbody2D body;
    public Transform firePoint;
    public Animator animator;

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
        if(gamepad.leftStick.ReadValue().y < 0 && gamepad.leftStick.ReadValue().y < gamepad.leftStick.ReadValue().x) {
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);

            animator.SetBool("MoveDown", true);
        } else if(gamepad.leftStick.ReadValue().y > 0 && gamepad.leftStick.ReadValue().y > gamepad.leftStick.ReadValue().x) {
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", false);

            animator.SetBool("MoveUp", true);
        } else if(gamepad.leftStick.ReadValue().x < 0 && gamepad.leftStick.ReadValue().x < gamepad.leftStick.ReadValue().y) {
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveUp", false);

            animator.SetBool("MoveLeft", true);
        } else if(gamepad.leftStick.ReadValue().x > 0 && gamepad.leftStick.ReadValue().x > gamepad.leftStick.ReadValue().y) {
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);

            animator.SetBool("MoveRight", true);
        } else {
            animator.SetBool("MoveDown", false);
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveUp", false);
            animator.SetBool("MoveRight", false);
        }
    }
}
