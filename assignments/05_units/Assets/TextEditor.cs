using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{
    public TMP_Text econText;
    private int newmun = 0;
    public GameObject Manager;
    private int econP = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameplayObj");
        econP = 10;
}

    public void EconButton()
    {
        Manager = GameObject.Find("GameplayObj");
        if (Manager.GetComponent<TheGame>().GetMoney() >= econP)
        {
            Debug.Log("Increased econ!");
            Manager.GetComponent<TheGame>().AddEcon();
            Manager.GetComponent<TheGame>().SetMoney(econP);
            newmun = newmun - econP;
            econP = econP * 3;
        }
        else
        {
            Debug.Log("Not enough money!");           
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        newmun = Manager.GetComponent<TheGame>().GetMoney();
        econText.text = "Money: " + newmun.ToString();
        
    }
}
