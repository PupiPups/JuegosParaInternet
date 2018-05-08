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
        int cantidad;
        cantidad = PlayerPrefs.GetInt("Enemigos");
        if (health != 0)
        {
            health -= 5;
		    Object.Destroy(other.gameObject);
        }

        if (health == 0)
        {
            Object.Destroy(gameObject);
            cantidad--;
            PlayerPrefs.SetInt("Enemigos", cantidad);
        }

        
    }
    public void BuffCaos()
    {   // se llama desde el EnemyManager para el modo caos.
        Speed = 4.5f;
        health = 20;
    }
}

