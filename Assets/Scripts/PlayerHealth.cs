using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int PermanentHealth = 3;
    public float Health = 3;
    public float ExtraHealth = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private void Update() {
        if(PermanentHealth < Health) {
            Health = PermanentHealth;
        }

        for(int i = 0; i < hearts.Length; i++) {
            if(Health-i == 0.5f) {
                hearts[i].sprite = halfHeart;
            } else if(i < Health) {
                hearts[i].sprite = fullHeart;
            } else {
                hearts[i].sprite = emptyHeart;
            }


            if(i < PermanentHealth) {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    public void PlayerTakeDamage() {
        Health -= 0.5f;
        print(Health);

        if(Health <= 0) {
            print("DEAD");
        }
    }

    public void sumEmptyPermanentHealth(int numberofHeartsup) {
        PermanentHealth += numberofHeartsup;
    }

    public void setFullHealth(bool isTrue) {
        if(isTrue == true)
        Health = PermanentHealth;
    }
}
