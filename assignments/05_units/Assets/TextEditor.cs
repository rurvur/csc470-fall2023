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
    public GameObject cowPrefab;
    public TMP_Text price;
    public TMP_Text cowtxt;
    public int cowcount = 0;
    public TMP_Text wintxt;

    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameplayObj");
        econP = 10;
        cowcount = 0;
    }

    //EconP is extremely buggy, not sure why but it doesn't properly reset and different methods read different values for it just making the econbutton a static cost for now
    public void EconButton()
    {
        Manager = GameObject.Find("GameplayObj");
        if (Manager.GetComponent<TheGame>().GetMoney() >= 15)
        {
            Debug.Log("Increased econ!");
            Manager.GetComponent<TheGame>().AddEcon();
            Manager.GetComponent<TheGame>().SetMoney(15);
            newmun = newmun - 15;
            econP = econP * 3;
        }
        else
        {
            Debug.Log("Not enough money!");
        }
        

    }

    public void perished()
    {
        cowcount = cowcount - 1;
    }

    private void CowSpawned()
    {
        cowcount++;
        if (cowcount >= 10)
        {
            wintxt.text = "You Win!";
        }

    }

    public void CowSpawn()
    {
        if (Manager.GetComponent<TheGame>().GetMoney() >= 25)
        {
            Manager.GetComponent<TheGame>();
            Vector3 cowpos = transform.position;
            cowpos.x = -110;
            cowpos.y = -105;
            cowpos.z = Random.Range(400, 440);
            GameObject cowObj = Instantiate(cowPrefab, cowpos, transform.rotation);
            Debug.Log("Cow Spawned!");
            Manager.GetComponent<TheGame>().SetMoney(25);
            CowSpawned();
        }
        else
        {
            Debug.Log("Not enough money for cow!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        newmun = Manager.GetComponent<TheGame>().GetMoney();
        econText.text = "Money: " + newmun.ToString();
        price.text = "Cost: 15";
        cowtxt.text = "Cost: 25";
        
    }
}
