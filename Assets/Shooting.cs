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
        Vector3 lookVector = gamepad.rightStick.ReadValue();
        Vector3 rotatedVector = Quaternion.Euler(0,0,0) * lookVector;
        firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        
        print("X:" + gamepad.rightStick.ReadValue().x + "       ///////////    Y: " + gamepad.rightStick.ReadValue().y);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * Force, ForceMode2D.Impulse);
    }
}
