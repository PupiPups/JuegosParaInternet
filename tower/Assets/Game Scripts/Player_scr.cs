using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_scr : MonoBehaviour {
    public GameObject bala;
    public Vector2 inicio;
    public int health;
    // Use this for initialization
    void Start () {
        inicio.x = -6f;
        inicio.y = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bala, inicio, Quaternion.identity);
        }
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
}
