using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    int chance = 0;
    public GameObject Editor;
    
    // Start is called before the first frame update
    void Start()
    {
        Editor = GameObject.Find("Canvas");
    }

    void Perish()
    {
        Destroy(gameObject);
        Editor.GetComponent<TextEditor>().perished();
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
