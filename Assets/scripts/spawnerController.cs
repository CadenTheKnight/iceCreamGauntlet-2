using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{

    public float spawnFrequency; 
    float spawnTimer;
    public bool horizontal = true; //false means vertical spawner
    public bool rightOrUp = true; //right for true, left for false; up for true, down for false
    public bool isPool = false; 

    public GameObject childToSpawn;
    
    private Vector3 spawnPosition;
    private float offset = 1.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnFrequency;
        if(isPool){
            offset = 3;
        }

        spawnPosition = transform.position;
        if(horizontal){
            if(rightOrUp){
                spawnPosition = spawnPosition + Vector3.right * offset;
            }
            else{
                spawnPosition = spawnPosition + Vector3.left * offset;
            }
        }
        else{
            if(rightOrUp){
                spawnPosition = spawnPosition + Vector3.up * offset;
            }
            else{
                spawnPosition = spawnPosition + Vector3.down * offset;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer < 0)
        {
            SpawnEnemy();
            spawnTimer = spawnFrequency;
        }
    }

    void SpawnEnemy(){
        //Debug.Log("Child spawned");
        GameObject child = (GameObject)Instantiate(childToSpawn, spawnPosition, Quaternion.identity);
        //enemyController childScript = child.GetComponent<enemyController>();
        //childScript.SetSpawnDirection(horizontal, positive);
    }

   


}
