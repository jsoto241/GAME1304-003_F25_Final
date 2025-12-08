using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public bool spawnOnStart = true;
    // Start is called before the first frame update
    void Start()

    {
        if (spawnOnStart)
        {
            SpawnPrefab();
        }
        
    }
    public void SpawnPrefab()
    {
        GameObject newEnemy = Instantiate(prefabToSpawn, transform.position, transform.rotation);
        newEnemy.tag = "Enemy";
    
        Debug.Log("It Is ALIIIIVE {prefabToSpawn.name} at {transform.position}");
    }



}
