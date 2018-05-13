using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fun : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().text = "Puntos en total: " + PlayerPrefs.GetInt("Puntos");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
