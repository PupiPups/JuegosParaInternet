using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Eventos_menu_scr : MonoBehaviour {

	// Use this for initialization
	public void Sel_Dif () {
		SceneManager.LoadScene (1);
	}
	
	// Update is called once per frame
	public void Sel_Niv (Dropdown dif) {
		PlayerPrefs.SetInt ("Dificul", dif.value);
		print (dif);
		SceneManager.LoadScene (2);
	}
}
