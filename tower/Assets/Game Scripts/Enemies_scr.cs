using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_scr : MonoBehaviour
{
    public string nome;
    public int health;
    public int damage;
    public float speed;


    // Use this for initialization
    void Start()
    {
        nome = "Chinese Worker";
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
        if (health != 0)
        {
            health -= 5;
        }

        if (health == 0)
        {
            DestroyObject(this.gameObject);

        }
    }
}
