using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour
{
    public int frame = 0;
    public int money = 0;
    public int econ = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetMoney()
    {
        return money;
    }

    // Update is called once per frame
    void Update()
    {
        frame += 1;
        if (frame == 300/econ)
        {
            money += 1;
            frame = 0;
            Debug.Log(money);
        }
    }
}
