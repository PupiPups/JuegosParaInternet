﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_scr : MonoBehaviour
{
    public string name;
    public int health;
    public int damage;
    public float speed;

   Rigidbody2D bala;
    


    // Use this for initialization
    void Start()
    {
        name = "Chinese Worker";
        health = 15;
        damage = 5;
        speed = 3.6f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Bala"))
        //{
            if (health != 0)
            {
                health -= 5;
                DestroyObject(collision.gameObject);

            }

            if (health == 0)
            {
                DestroyObject(collision.gameObject);
                DestroyObject(this.gameObject);

            }
        //}        
    }
}
