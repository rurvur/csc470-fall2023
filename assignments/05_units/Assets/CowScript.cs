using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    int chance = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Perish()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        chance = Random.Range(0, 10000);
        if (chance == 666)
        {
            Perish();
        }
    }
}
