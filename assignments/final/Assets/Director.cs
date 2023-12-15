using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    int credits;
    int credspeed;
    int frame;
    public GameObject EnemyPrefab;
    public GameObject ElitePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        credits = 0;
        credspeed = 1;
        frame = 0;
    }

    void spawnWave(int creds)
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-10.0f, 10.0f);
        while (creds >= 25)
        {
            pos.x += Random.Range(-3.0f, 3.0f);
            spawnElite(pos);
            pos = transform.position;
            creds -= 25;
            Debug.Log("Elite spawned!");
        }
        while (creds >= 1)
        {
            pos.x += Random.Range(-3.0f, 3.0f);
            spawnEnemy(pos);
            pos = transform.position;
            creds -= 1;
            Debug.Log("Enemy spawned!");
            
        }
    }

    void spawnEnemy(Vector3 pos)
    {
        GameObject enemObj = Instantiate(EnemyPrefab, pos, transform.rotation);
    }

    void spawnElite(Vector3 pos)
    {
        GameObject enemObj = Instantiate(EnemyPrefab, pos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame % 300 == 0)
        {
            credits += credspeed;
        }
        if (frame % 3000 == 0)
        {
            spawnWave(credits);
            credits = 0;
            credspeed += 1;
        }
    }
}
