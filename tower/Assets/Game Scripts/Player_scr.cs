using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_scr : MonoBehaviour {
    public GameObject bala;
    public Vector2 inicio;
    // Use this for initialization
    void Start () {
        inicio.x = -6f;
        inicio.y = 0.7f;
	}
	
    public void ScoreMultiplier ()  {

      //  if (PlayerPrefs.GetInt("Dificul") == 0)
      //  {
          //  Score
      //  }

    }


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bala, inicio, Quaternion.identity);

        }
		
	}
}
