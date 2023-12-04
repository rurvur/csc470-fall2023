using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    TerrainBuilder tb;
    Renderer rend;
    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject genObj = GameObject.Find("TerrainBuilder");
        tb = genObj.GetComponent<TerrainBuilder>();
        rend = gameObject.GetComponentInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
