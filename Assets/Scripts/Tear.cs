using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tear : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag != "Player") {
            Enemy enemy = coll.GetComponent<Enemy>();
            if(enemy != null) {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
