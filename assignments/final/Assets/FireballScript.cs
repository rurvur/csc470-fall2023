using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    private GameObject target;
    private float speed = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("EnemyPrefab");
    }

    void TrackEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        FindEnemy();
        TrackEnemy();
        Debug.Log(target);
    }

    public void FindEnemy()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemies");
        float closestEnemy = 0;
        for (int i = 0; i < targets.Length; i++)
        {
            float d = Vector3.Distance(transform.position, targets[i].transform.position);
            if (d < closestEnemy)
            {
                target = targets[i];
            }
        }
        Debug.Log(target.name);
    }
}
