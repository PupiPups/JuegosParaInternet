using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject boss;
    public float spawnTime = 0.2f;            // How long between each spawn.
    Vector3 spawnPoint = new Vector3 (12.0f,1.0f,2.5f);         // An array of the spawn points this enemy can spawn from.
    public int Enemigos;
    public int Jefes;
    public bool discordia;
    public Enemies_scr malos;

   private void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        Enemigos = PlayerPrefs.GetInt("Enemigos");
        Jefes = PlayerPrefs.GetInt("Jefes");
        if (PlayerPrefs.GetString("Chaos") == "true")
        {
            discordia = true;
        }
        else
        {
            discordia = false;
        }
    }


    private void Spawn()
    {
        if (PlayerPrefs.GetInt("Enemigos") >= 0)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Enemigos--;
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }
        else {
            yield break;
        }
        if (Jefes >= 0)
        {
          //  cantBoss--;
          //  Instantiate(boss, spawnPoint, Quaternion.identity);       activar cuando la clase boss este creado
        }
        else
        {
            yield break;
        }
    }
    private void Caos()
    {
        spawnTime = 0.02f; //aumenta la rapidez del spawn   
        malos.BuffCaos(); //llama al metodo buffcaos de la clase enemi
    }
}