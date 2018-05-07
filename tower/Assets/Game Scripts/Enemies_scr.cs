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
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (health != 0)
        {
            health -= 5;
			DestroyObject (other.gameObject);
        }

        if (health == 0)
        {
			DestroyObject (other.gameObject);
            DestroyObject(this.gameObject);

        }
    }
}
