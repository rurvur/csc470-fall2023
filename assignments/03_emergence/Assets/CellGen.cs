using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGen : MonoBehaviour
{

    public bool alive = false;
    public Color liveCol;
    public Color deadCol;
    public int x = -1;
    public int y = -1;
    GameOfLife gol;
    Renderer rend;
    
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

    private void OnMouseDown()
    {
        alive = !alive;
        ColorChange();
        Debug.Log(CountLiveNeighbors());
    }

    int CountLiveNeighbors()
    {
        int alive = 0;

        for (int xIndex = x - 1; xIndex <= x + 1; xIndex++)
        {
            for (int yIndex = y - 1; yIndex <= y + 1; yIndex++)
            {
                if (gol.cells[xIndex, yIndex].alive)
                {
                    alive++;
                }
            }
        }

        return alive;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
