using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text healthText;
    public TMP_Text levelText;
    string health;
    string maxhealth;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerObj");
    }

    // Update is called once per frame
    void Update()
    {
        health = Player.GetComponent<Controller>().getHealth();
        maxhealth = Player.GetComponent<Controller>().getMax();
        healthText.text = "Health: " + health + "/" + maxhealth;
        levelText.text = "Level: " + Player.GetComponent<Controller>().getLevel();
    }
}
