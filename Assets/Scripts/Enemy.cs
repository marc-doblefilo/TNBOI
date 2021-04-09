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

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.collider.tag == "Player") {
            PlayerHealth Player = coll.collider.GetComponent<PlayerHealth>();
            if(Player != null) {
                Player.PlayerTakeDamage();
            }
        }
    }
}
