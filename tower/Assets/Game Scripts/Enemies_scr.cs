using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_scr : MonoBehaviour
{
    public string nome;
    public int health;
    public int damage;

    Rigidbody2D m_Rigidbody2D;
    float Speed;


    // Use this for initialization
    void Start()
    {
        nome = "Chinese Worker";
        health = 15;
        damage = 5;
      
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    
        Speed = 3.6f;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody2D.velocity = Vector2.left * Speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health != 0)
        {
            health -= 5;
			DestroyObject(gameObject);
        }

        if (health == 0)
        {
			DestroyObject(gameObject);
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            DestroyObject(gameObject);
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

        }

        
    }
    public void BuffCaos()
    {   // se llama desde el EnemyManager para el modo caos.
        Speed = 4.5f;
        health = 20;
    }
}

