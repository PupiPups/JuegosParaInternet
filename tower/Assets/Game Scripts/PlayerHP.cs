using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {
    public Slider hp;
    

	void Start () {
        hp.value = 10f;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    

    public void perdervida()
    {
        if (hp.value > 0)
        {
            hp.value -= 1;

        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
