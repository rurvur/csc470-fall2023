using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject PinPrefab;
    public GameObject BlockPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            generateBlock();
        }
    }

    void generatePin()
    {
        float x = Random.Range(-3, 3);
        float y = -4.5f;
        float z = Random.Range(-70, 0);
        Vector3 pos = new Vector3(x, y, z);
        Vector3 rot = new Vector3(0, 0, 0);
        GameObject Pin = Instantiate(PinPrefab, pos, Quaternion.Euler(rot));
    }

    void generateBlock()
    {
        float x = Random.Range(-3, 3);
        float y = -4.5f;
        float z = Random.Range(-70, 0);
        Vector3 pos = new Vector3(x, y, z);
        GameObject Block = Instantiate(BlockPrefab, pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
