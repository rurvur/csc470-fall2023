using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{
    //NOTICE: Terrain hardly matters in this prototype, I was pretty ambitious with my ideas for this assignment but if I try to work it into my concept I won't have enough time for my final, so I'm
    //        instead doing a much more limited version and choosing to invest more time into getting the final done.
    
    
    public TerrainGen[] blocks;
    public GameObject blockPrefab;
    public TerrainGen[] badblocks;
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        blocks = new TerrainGen[4];
        int spacing = 0;
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = transform.position;
            pos.z = pos.z + spacing;
            spacing += 11;
            GameObject blockObj = Instantiate(blockPrefab, pos, transform.rotation);
            blocks[i] = blockObj.GetComponent<TerrainGen>();
        }
        //Rerunning the script for the enemy terrain, might rework into a function that takes an argument and generates terrain based on whether it says enemy or player terrain
        badblocks = new TerrainGen[5];
        int enemySpacing = 0;
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = transform.position;
            pos.z = pos.z + enemySpacing;
            pos.x = pos.x + 25;
            enemySpacing += 11;
            GameObject blockObj = Instantiate(enemyPrefab, pos, transform.rotation);
            badblocks[i] = blockObj.GetComponent<TerrainGen>();
        }
    }

    public void Test()
    {
        Debug.Log("Pressed!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
