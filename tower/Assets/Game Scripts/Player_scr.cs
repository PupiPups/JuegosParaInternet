using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_scr : MonoBehaviour {
    public GameObject bala;
    public Vector2 inicio;
    public int puntos;
    // Use this for initialization
    void Start () {
        inicio.x = -6f;
        inicio.y = 0.7f;
        puntos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bala, inicio, Quaternion.identity);

        }
        PlayerPrefs.SetInt("Puntos", puntos);
	}
}
