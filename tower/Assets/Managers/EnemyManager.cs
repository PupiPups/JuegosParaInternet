using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        if (PlayerPrefs.GetString("Chaos") == "true") {

            discordia = true;
        }
        else {

            discordia = false;
        }
    }

    private void Update()
    {
        Enemigos = PlayerPrefs.GetInt("Enemigos");
        Jefes = PlayerPrefs.GetInt("Boss");
    }


    void Spawn()
    {
        if (Enemigos > 0)
        {
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
        else if (Jefes > 0)
        {
          //  cantBoss--;
          Instantiate(boss, spawnPoint, Quaternion.identity);
        }
        else if(Enemigos == 0 && Jefes == 0)
        {
            ganar();
        }
    }
    private void Caos()
    {
        spawnTime = 0.02f; //aumenta la rapidez del spawn   
        malos.BuffCaos(); //llama al metodo buffcaos de la clase enemi
    }

    void ganar()
    {
        SceneManager.LoadScene(3);
    }
}