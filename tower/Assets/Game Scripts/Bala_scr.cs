using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_scr : MonoBehaviour {
    

    // Use this for initialization
    public void RomperBala ()
    {
        Destroy(this);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
    }

    
}
