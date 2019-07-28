﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 20; 
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    } 

    private void OnTriggerEnter2D(Collider2D collider)
    {     
        Player1Control player = collider.GetComponent<Player1Control>();
        if(player != null)
        {
            player.takeDamage1(damage);
        }
        Destroy(gameObject);
    }
}
