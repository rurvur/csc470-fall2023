using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGen : MonoBehaviour
{
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefab = GameObject.Find("PlayerObj");
        Vector3 pos = transform.position;
        Instantiate(PlayerPrefab, pos, transform.rotation);
        Debug.Log("Player spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
