using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Mov :  NetworkBehaviour{
    public GameObject babapref;
    public Transform balaspawn;

    void Start(){
        if (isLocalPlayer){
            Camera.main.transform.position = this.transform.position - this.transform.forward * 10 + this.transform.up * 3;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }     
    }

    void Update(){
        if (!isLocalPlayer){
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space)){
            CmdFire();
        }
    }

    [Command]
    void CmdFire(){
        var bullet = (GameObject)Instantiate( babapref, balaspawn.position, transform.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        Destroy(bullet, 3.0f);
    }


    public override void OnStartLocalPlayer(){
        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
