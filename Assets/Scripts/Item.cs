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
    public float _range;
    public int _emptyRedHeartsContainers;
    public bool _regenerateFullHealth;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.tag == "Player") {
            Shooting player = coll.GetComponent<Shooting>();
            IsaacController controller = coll.GetComponent<IsaacController>();
            PlayerHealth health = coll.GetComponent<PlayerHealth>();
            if(player != null) {
                controller.setSpeed(_speed);
                player.addDamage(_damage);
                player.addForce(_force);
                player.addCooldown(_cooldown);
                player.addRange(_range);
                health.sumEmptyPermanentHealth(_emptyRedHeartsContainers);
                health.setFullHealth(_regenerateFullHealth);
            }
            Destroy(gameObject);
        }
    }
}
