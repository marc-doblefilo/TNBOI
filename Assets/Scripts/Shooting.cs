using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float Force = 10f;
    public float Cooldown = 0.75f;
    public float Damage = 1.0f;
    public float Range = 10.0f;

    private float NextShoot;

    public Text DamageUIText;
    public Text ForceUIText;
    public Text CooldownUIText;
    public Text RangeUIText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DamageUIText.text = Damage.ToString();
        ForceUIText.text = Force.ToString();
        CooldownUIText.text = Cooldown.ToString();
        RangeUIText.text = Range.ToString();

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
        //Vector3 rotatedVector = Quaternion.Euler(0,0,0) * lookVector;
        //firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        if(lookVector.x > 0 && lookVector.x > lookVector.y) {
            Vector3 rotatedVector = new Vector3(1, 0, 0);
            firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        } else if(lookVector.x < 0 && lookVector.x < lookVector.y) {
            Vector3 rotatedVector = new Vector3(-1, 0, 0);
            firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        } else if(lookVector.y > 0 && lookVector.y > lookVector.x) {
            Vector3 rotatedVector = new Vector3(0, 1, 0);
            firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        } else if(lookVector.y < 0 && lookVector.y < lookVector.x) {
            Vector3 rotatedVector = new Vector3(0, -1, 0);
            firePoint.rotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVector);
        } 

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Tear tear = bullet.GetComponent<Tear>();
        tear.damage = Damage;
        tear.bulletSpeed = Force;
        tear.range = Range;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * Force, ForceMode2D.Impulse);
    }

    public void addDamage(float modifier) {
        Damage += modifier;
    }

    public void addForce(float modifier) {
        Force += modifier;
    }

    public void addCooldown(float modifier) {
        Cooldown += modifier;
    }

    public void addRange(float modifier) {
        Range += modifier;
    }
}
