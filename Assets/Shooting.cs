using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float Force = 20f;
    public float Cooldown = 1.25f;

    private float NextShoot;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        if(gamepad == null) {
            return;
        }

        if(gamepad.rightStick.IsActuated() && Time.time > NextShoot) {
            NextShoot = Time.time + Cooldown;
            Shoot();
        }
    }

    void Shoot() {
        var gamepad = Gamepad.current;
        Vector3 lookDirection = new Vector3(gamepad.rightStick.ReadValue().x, gamepad.rightStick.ReadValue().y, 0f);
        print("X:" + gamepad.rightStick.ReadValue().x + "       ///////////    Y: " + gamepad.rightStick.ReadValue().y);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * Force, ForceMode2D.Impulse);
    }
}
