using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    float speed = 3.5f;
    public int health = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TrackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

    void perish()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        TrackPlayer();
        if (health == 0)
        {
            perish();
        }
    }


}
