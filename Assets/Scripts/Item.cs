using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "Player") {
            Shooting player = coll.GetComponent<Shooting>();
            if(player != null) {
                player.setDamage(2);
            }
            Destroy(gameObject);
        }
    }
}
