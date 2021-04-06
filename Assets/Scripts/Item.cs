using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Animator animator;

    public float _speed;
    public float _damage;
    public float _force;
    public float _cooldown;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "Player") {
            Shooting player = coll.GetComponent<Shooting>();
            IsaacController controller = coll.GetComponent<IsaacController>();
            if(player != null) {
                controller.setSpeed(_speed);
                player.setDamage(_damage);
                player.setForce(_force);
                player.setCooldown(_cooldown);
            }
            Destroy(gameObject);
        }
    }
}
