using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 20;
    
    public void TakeDamage(float damage) {
        health -= damage;
        print(health);

        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
