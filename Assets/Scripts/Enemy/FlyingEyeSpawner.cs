using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlyingEyeSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] prefabs;

    [SerializeField] private float spawnTime;

    private float timeToSpawn;

    void Awake()
    {
        timeToSpawn = spawnTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        setTimeToSpawn(Time.fixedDeltaTime);
    }

    private void setTimeToSpawn(float dt){
        timeToSpawn -= dt;
        if (timeToSpawn <= 0){
            spawnEye();
            timeToSpawn = spawnTime;
        }

    }

    private void spawnEye(){
        int prefab = Random.Range(0,prefabs.Length);
        Instantiate(prefabs[prefab], transform.position, transform.rotation);
    }
}
