using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGen : MonoBehaviour
{

    public bool alive = false;
    public color liveCol;
    public color deadCol;
    public int x = -1;
    public int y = -1;
    GameOfLife gol;
    renderer rend;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject golObj = GameObject.Find("GameOfLife");
        gol = golObj.GetComponent<GameOfLife>();
        rend = gameObject.GetComponentInChildren<Renderer>();
        ColorChange();
    }

    public void ColorChange()
    {
        if (alive)
        {
            rend.material.color = liveCol;
        }
        else
        {
            rend.material.color = deadCol;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
