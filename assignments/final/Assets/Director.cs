using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    int credits;
    int credspeed;
    int frame;
    int wavecount;
    public GameObject EnemyPrefab;
    public GameObject ElitePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        credits = 0;
        credspeed = 1;
        frame = 0;
        wavecount = 0;
    }

    void spawnWave(int creds)
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-10.0f, 10.0f);
        if (wavecount >= 10)
        {
            while (creds >= 50)
            {
                pos.x += Random.Range(-15.0f, 10.0f);
                pos.z += Random.Range(-15.0f, 10.0f);
                spawnElite(pos);
                pos = transform.position;
                creds -= 50;
                Debug.Log("Elite spawned!");
            }
        }
        while (creds >= 5)
        {
            pos.x += Random.Range(-15.0f, 10.0f);
            pos.z += Random.Range(-15.0f, 10.0f);
            spawnEnemy(pos);
            pos = transform.position;
            creds -= 5;
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
        if (frame % 6000 == 0)
        {
            spawnWave(credits);
            wavecount++;
            credits = 0;
        }
        if (frame % 15000 == 0)
        {
            credspeed += 1;
        }
    }
}
