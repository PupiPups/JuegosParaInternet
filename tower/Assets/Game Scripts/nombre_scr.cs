using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class nombre_scr : MonoBehaviour {
    public Text texto;
    public string nombre;
	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Collider2D>().tag == "Player")
        {
            nombre = PlayerPrefs.GetString("Player_Nombre");
        }
        else if (gameObject.GetComponent<Collider2D>().tag == "Enemy")
        {
            nombre = PlayerPrefs.GetString("Enemy_Nombre");
        }
        else if (gameObject.GetComponent<Collider2D>().tag == "Boss")
        {
            nombre = PlayerPrefs.GetString("Boss_Nombre");
        }
        
    }

    // Update is called once per frame
    void Update () {
        texto.text = nombre;
    }


}
