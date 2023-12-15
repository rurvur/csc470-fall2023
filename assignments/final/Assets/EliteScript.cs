using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteScript : MonoBehaviour
{
    public GameObject player;
    float speed = 10f;
    public int health = 50;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObj");
    }

    void TrackPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform.position);
    }

    void perish()
    {
        player.GetComponent<Controller>().giveEXP(1);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            health -= 10;
            Destroy(other.gameObject);
        }

    }


}
