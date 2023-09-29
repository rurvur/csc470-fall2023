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
    private Vector3 scaleChange;
    
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
        Debug.Log(CountAliveNeighbors());
    }

    int CountAliveNeighbors()
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
        if (Time.frameCount % 30 == 0)
        {
            if ((CountAliveNeighbors() == 2) && alive)
            {
                alive = true;
                ColorChange();
            }
            else if (CountAliveNeighbors() == 3 && alive)
            {
                alive = true;
                ColorChange();
            }
            else if (CountAliveNeighbors() == 3 && alive == false)
            {
                alive = true;
                ColorChange();
            }
            else
            {
                alive = false;
                ColorChange();
            }
            if (alive)
            {
                scaleChange = new Vector3(0f, 0.1f, 0f);
                transform.localScale += scaleChange;

            }
            else
            {
                scaleChange = new Vector3(0f, -0.1f, 0f);
                transform.localScale += scaleChange;
            }
        }
        
    }
}
