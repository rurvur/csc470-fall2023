using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject Manager;


    public void StartButton()
    {
        Manager.GetComponent<SceneChanger>().ChangeScene("SampleScene");
    }


    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("SceneManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
