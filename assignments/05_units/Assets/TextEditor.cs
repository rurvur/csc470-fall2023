using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEditor : MonoBehaviour
{
    public TMP_Text econText;
    public int newmun = 0;
    public GameObject Manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newmun = Manager.GetComponent<TheGame>().GetMoney();
        econText.text = "Money: " + newmun.ToString();
    }
}
