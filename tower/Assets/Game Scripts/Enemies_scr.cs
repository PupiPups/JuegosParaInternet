using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_scr : MonoBehaviour
{
    public string name;
    public int health;
    public int damage;
    public int velocity;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (health == 0)
        {
            DestroyObject(this.gameObject);
        } 
	}
}
