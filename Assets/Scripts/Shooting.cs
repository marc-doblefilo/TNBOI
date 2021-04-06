using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float Force = 20f;
    public float Cooldown = 1.25f;
    public float Damage = 1.0f;

    private float NextShoot;

    public Text DamageUIText;
    public Text ForceUIText;
    public Text CooldownUIText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DamageUIText.text = Damage.ToString();
        ForceUIText.text = Force.ToString();
        CooldownUIText.text = Cooldown.ToString();

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

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Tear tear = bullet.GetComponent<Tear>();
        tear.damage = Damage;

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * Force, ForceMode2D.Impulse);
    }

    public void setDamage(float modifier) {
        Damage += modifier;
    }

    public void setForce(float modifier) {
        Force += modifier;
    }

    public void setCooldown(float modifier) {
        Cooldown += modifier;
    }
}
