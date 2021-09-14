using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Sprite [] health;
    public Image imgHealth;
    void Start()
    {     
       imgHealth.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        print("H "+DataPlayer.health);
        if(DataPlayer.health == 3)
        {
            imgHealth.sprite = health[0];
        }
        else if(DataPlayer.health == 2)
        {
            imgHealth.sprite = health[1];
        }
        else if(DataPlayer.health == 1)
        {
            imgHealth.sprite = health[2];
        }
        else if(DataPlayer.health <= 0 || DataPlayer.isGameOver)
        {
            imgHealth.enabled = false;
        }
    }
}
