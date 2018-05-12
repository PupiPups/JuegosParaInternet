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

    public void Sel_Menu()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    public void Sel_Niv(Dropdown dif) {
        PlayerPrefs.SetInt("Dificul", dif.value);
        if (PlayerPrefs.GetInt ("Dificul") == 0) {
			PlayerPrefs.SetInt ("Enemigos", 3);
			PlayerPrefs.SetInt ("Jefes", 0);
			PlayerPrefs.SetString ("Chaos", "false");
			SceneManager.LoadScene (2);

		} else if (PlayerPrefs.GetInt ("Dificul") == 1) {
			PlayerPrefs.SetInt ("Enemigos", 5);
			PlayerPrefs.SetInt ("Jefes", 1);
			PlayerPrefs.SetString ("Chaos", "false");
			SceneManager.LoadScene (2);
		} else if (PlayerPrefs.GetInt ("Dificul") == 2) {
			PlayerPrefs.SetInt ("Enemigos", 10);
			PlayerPrefs.SetInt ("Jefes", 1);
			PlayerPrefs.SetString ("Chaos", "false");
			SceneManager.LoadScene (2);
		} else if (PlayerPrefs.GetInt ("Dificul") == 3) {
			PlayerPrefs.SetInt ("Enemigos", 20);
			PlayerPrefs.SetInt ("Jefes", 2);
			PlayerPrefs.SetString ("Chaos", "true");
			SceneManager.LoadScene (2);
		}
		else if (PlayerPrefs.GetInt ("Dificul") == 4) {
			PlayerPrefs.SetInt ("Enemigos", 50);
			PlayerPrefs.SetInt ("Jefes", 10);
			PlayerPrefs.SetString ("Chaos", "true");
			SceneManager.LoadScene (2);
		}
	}


}
