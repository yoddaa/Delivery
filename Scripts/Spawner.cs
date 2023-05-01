using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay = 2f;
    public float spawnDelayReduction = 0.1f;
    public float spawnRateDecreaseInterval = 10f;
   
    private float timeSinceLastSpawn = 0f;
    private float timeSinceLastSpawnRateDecrease = 0f;
    
    public AudioSource spawnerAudioSource;
    public AudioClip eggSound;

    

    private void Start()
    {
        spawnDelay = Random.Range(1f, 2f);
        spawnRateDecreaseInterval = Random.Range(5f, 10f);
        spawnDelayReduction = Random.Range(.1f, .5f);
    }

    private void Update()
    {
        if (!GameLogic.isGameOver)
        {



            // Increase the time since last spawn
            timeSinceLastSpawn += Time.deltaTime;

            // Spawn the object if enough time has passed
            if (timeSinceLastSpawn >= spawnDelay)
            {
                SpawnObject();
                timeSinceLastSpawn = 0f;
            }

            // Decrease spawn rate at intervals
            timeSinceLastSpawnRateDecrease += Time.deltaTime;
            if (timeSinceLastSpawnRateDecrease >= spawnRateDecreaseInterval)
            {
                DecreaseSpawnRate();
                timeSinceLastSpawnRateDecrease = 0f;
            }
        }
    }




    private void SpawnObject()
    {
        spawnerAudioSource.PlayOneShot(eggSound);
        // Spawn the object at this spawner's position and rotation
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        
    }

    private void DecreaseSpawnRate()
    {
        // Decrease spawn delay by the specified amount
        spawnDelay -= spawnDelayReduction;

        // Clamp spawn delay to a minimum of 0.1f seconds
        spawnDelay = Mathf.Max(spawnDelay, 0.1f);
    }
}